namespace Linn.Products.Service.Tests.SernosSequenceModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SernosSequence, string, SernosSequenceResource, SernosSequenceResource> SernosSequenceService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SernosSequenceService = Substitute
                .For<IFacadeService<SernosSequence, string, SernosSequenceResource, SernosSequenceResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SernosSequenceService);
                        with.Dependency<IResourceBuilder<SernosSequence>>(new SernosSequenceResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<SernosSequence>>>(
                            new SernosSequencesResourceBuilder());
                        with.Module<SernosSequenceModule>();
                        with.ResponseProcessor<SernosSequenceResponseProcessor>();
                        with.ResponseProcessor<SernosSequencesResponseProcessor>();
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