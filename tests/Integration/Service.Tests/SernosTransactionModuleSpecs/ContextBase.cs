namespace Linn.Products.Service.Tests.SernosTransModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;
    using Linn.Products.Service.Tests;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SernosTransaction, string, SernosTransactionResource, SernosTransactionResource> SernosTransactionService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SernosTransactionService = Substitute.For<IFacadeService<SernosTransaction, string, SernosTransactionResource, SernosTransactionResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.SernosTransactionService);
                    with.Dependency<IResourceBuilder<SernosTransaction>>(new SernosTransactionResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<SernosTransaction>>>(new SernosTransactionsResourceBuilder());
                    with.Module<SernosTransactionModule>();
                    with.ResponseProcessor<SernosTransactionResponseProcessor>();
                    with.ResponseProcessor<SernosTransactionsResponseProcessor>();
                    with.RequestStartup(
                        (container, pipelines, context) =>
                        {
                            var claims = new List<Claim>
                                                 {
                                                     new Claim(ClaimTypes.Role, "employee"),
                                                     new Claim(ClaimTypes.NameIdentifier, "test-user")
                                                 };

                            var user = new ClaimsIdentity(claims, "jwt");

                            context.CurrentUser = new ClaimsPrincipal(user);
                        });
                });

            this.Browser = new Browser(bootstrapper);
        }
    }
}