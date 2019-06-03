namespace Linn.Products.Service.Tests.SernosNoteModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource> SernosNoteService { get; private set; }

        protected IAuthorisationService AuthorisationService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SernosNoteService = Substitute.For<IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource>>();
            this.AuthorisationService = Substitute.For<IAuthorisationService>();
            this.AuthorisationService.HasPermissionFor(
                AuthorisedAction.SerialNumberAdmin,
                Arg.Any<IEnumerable<string>>()).Returns(true);

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SernosNoteService);
                        with.Dependency(this.AuthorisationService);
                        with.Dependency<IResourceBuilder<ResponseModel<SernosNote>>>(new SernosNoteResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<SernosNote>>>(new SernosNotesResourceBuilder());
                        with.Module<SernosNoteModule>();
                        with.ResponseProcessor<SernosNoteResponseProcessor>();
                        with.ResponseProcessor<SernosNotesResponseProcessor>();
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
