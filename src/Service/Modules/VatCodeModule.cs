namespace Linn.Products.Service.Modules
{
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;

    using Microsoft.EntityFrameworkCore;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class VatCodeModule : NancyModule
    {
        private readonly IFacadeService<VatCode, string, VatCodeResource, VatCodeResource> vatCodeService;
        private readonly IAuthorisationService authorisationService;

        public VatCodeModule(
            IFacadeService<VatCode, string, VatCodeResource, VatCodeResource> vatCodeService,
            IAuthorisationService authorisationService)
        {
            this.vatCodeService = vatCodeService;
            this.authorisationService = authorisationService;
            this.Get("/products/maint/vat-codes/{code}", parameters => this.GetVatCodeByCode(parameters.code));
            this.Get("/products/maint/vat-codes/", _ => this.GetVatCodes());
            this.Put("/products/maint/vat-codes/{code}", parameters => this.UpdateVatCode(parameters.code));
            this.Post("/products/maint/vat-codes", _ => this.AddVatCode());
        }

        private object AddVatCode()
        {
            var resource = this.Bind<VatCodeResource>();
            this.RequiresAuthentication();
            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();

            if (!this.authorisationService.HasPermissionFor(AuthorisedAction.VatAdmin, privileges))
            {
                return this.Negotiate.WithModel(new UnauthorisedResult<ResponseModel<VatCode>>("You are not authorised to create or edit vat codes"));
            }

            try
            {
                return this.Negotiate.WithModel(this.vatCodeService.Add(resource, privileges)).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                    .WithView("Index");
            }
            catch (DbUpdateException e)
            {
                return new BadRequestResult<VatCode>(e.InnerException.Message);
            }
        }

        private object GetVatCodeByCode(string code)
        {
            var privileges = this.Context.CurrentUser.GetPrivileges();

            var result = this.vatCodeService.GetById(code, privileges);

            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetVatCodes()
        {
            if (this.Context?.CurrentUser == null)
            {
                return this.Negotiate.WithModel(this.vatCodeService.GetAll()).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                    .WithView("Index");
            }

            var privileges = this.Context.CurrentUser.GetPrivileges();

            var result = this.vatCodeService.GetAll(privileges);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateVatCode(string code)
        {
            this.RequiresAuthentication();
            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();

            if (!this.authorisationService.HasPermissionFor(AuthorisedAction.VatAdmin, privileges))
            {
                return this.Negotiate.WithModel(new UnauthorisedResult<ResponseModel<VatCode>>("You are not authorised to create or edit vat codes"));
            }

            var resource = this.Bind<VatCodeResource>();
            try
            {
                var result = this.vatCodeService.Update(code, resource, privileges);

                return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
            }
            catch (DbUpdateException e)
            {
                return new BadRequestResult<VatCode>(e.InnerException.Message);
            }
        }
    }
}
