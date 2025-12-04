namespace Linn.Products.Service.Host
{
    using System.IdentityModel.Tokens.Jwt;

    using Amazon;
    using Amazon.KeyManagementService;
    using Amazon.S3;

    using AspNetCore.DataProtection.Aws.Kms;
    using AspNetCore.DataProtection.Aws.S3;

    using Linn.Common.Authentication.Host.Extensions;
    using Linn.Common.Configuration;
    using Linn.Products.Service.Models;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpOverrides;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Logging;

    using Nancy;
    using Nancy.Owin;
    using static System.Net.WebRequestMethods;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var keysBucketName = ConfigurationManager.Configuration["KEYS_BUCKET_NAME"];
            var kmsKeyAlias = ConfigurationManager.Configuration["KMS_KEY_ALIAS"];

            services.TryAddSingleton<IAmazonS3>(
                new AmazonS3Client(new AmazonS3Config { RegionEndpoint = RegionEndpoint.EUWest1 }));
            services.TryAddSingleton<IAmazonKeyManagementService>(
                new AmazonKeyManagementServiceClient(
                    new AmazonKeyManagementServiceConfig { RegionEndpoint = RegionEndpoint.EUWest1 }));

            services.AddDataProtection().SetApplicationName("auth-oidc")
                .PersistKeysToAwsS3(new S3XmlRepositoryConfig(keysBucketName)).ProtectKeysWithAwsKms(
                    new KmsXmlEncryptorConfig(kmsKeyAlias) { DiscriminatorAsContext = true });

            // 1) legacy (Linn OpenID Connect + Linn JWT)
            services.AddLinnAuthentication(
            options =>
            {
                        options.Authority = "https://www-sys.linn.co.uk/auth/";
                        options.CallbackPath = new PathString("/products/maint/signin-oidc");
                    });

            // 2) new cognito JWT provider
            var appSettings = ApplicationSettings.Get();
            var cognitoIssuer = appSettings.CognitoHost;
            var cognitoClientId = appSettings.CognitoClientId;

            services.AddAuthentication().AddJwtBearer(
                "cognito-provider",
                options =>
                    {
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                                                                {
                                                                    ValidateIssuer = true,
                                                                    ValidIssuer = cognitoIssuer,
                                                                    ValidateAudience = false,
                                                                    ValidAudience = cognitoClientId,
                                                                    ValidateLifetime = true,
                                                                    ValidateIssuerSigningKey = true
                                                                };

                        options.MetadataAddress = $"{cognitoIssuer}/.well-known/openid-configuration";
                    });

            services.AddAuthentication(
                options =>
                    {
                        options.DefaultScheme = "MultiAuth";
                        options.DefaultChallengeScheme = "MultiAuth";
                    }).AddScheme<MultiAuthOptions, MultiAuthHandler>(
                "MultiAuth",
                opts =>
                    {
                        opts.CognitoIssuer = appSettings.CognitoHost;
                        opts.CognitoScheme = "cognito-provider";
                        opts.LegacyScheme = JwtBearerDefaults.AuthenticationScheme;
                    });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(
                new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedProto });

            app.UseAuthentication();

            app.UseOwin(
                x => x.UseNancy(
                    config =>
                        {
                            config.PassThroughWhenStatusCodesAre(HttpStatusCode.Unauthorized, HttpStatusCode.Forbidden);
                        }));
        }
    }
}