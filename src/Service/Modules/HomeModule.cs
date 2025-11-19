namespace Linn.Products.Service.Modules
{
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.Responses;

    public sealed class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.Get("/", args => new RedirectResponse("/products/maint"));
            this.Get("/", args => new RedirectResponse("/products/maint"));
            this.Get("/products", _ => this.GetApp());
            this.Get("/products/maint", _ => this.GetApp());
            this.Get("/products/reports", _ => this.GetApp());
            this.Get("/products/reports/(.*)/report", _ => this.GetApp());

            this.Get("/products/maint/(.*)/create", _ => this.GetApp());

            this.Get("/products/maint/auth/", _ => this.GetApp());
            this.Get("/products/maint/auth/logged-out", _ => this.GetApp());


            this.Get(@"^(.*)$", _ => this.GetApp());
        }

        private object GetApp()
        {
            return this.Negotiate.WithModel(ApplicationSettings.Get()).WithView("Index");
        }
    }
}