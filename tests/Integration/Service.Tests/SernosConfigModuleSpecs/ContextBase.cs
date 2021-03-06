﻿namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;
    using Linn.Products.Service.Tests;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    using PagedList.Core;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigResource> SernosConfigService { get; private set; }

        protected IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource> SernosTransactionService { get; private set; }

        protected IFacadeService<SernosCount, string, SernosCountResource, SernosCountResource> SernosCountService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SernosConfigService = Substitute.For<IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigResource>>();
            this.SernosTransactionService = Substitute.For<IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource>>();
            this.SernosCountService = Substitute.For<IFacadeService<SernosCount, string, SernosCountResource, SernosCountResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.SernosConfigService);
                    with.Dependency(this.SernosTransactionService);
                    with.Dependency(this.SernosCountService);
                    with.Dependency<IResourceBuilder<SernosConfig>>(new SernosConfigResourceBuilder());
                    with.Dependency<IResourceBuilder<SernosTrans>>(new SernosTransactionResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<SernosConfig>>>(new SernosConfigsResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<SernosTrans>>>(new SernosTransactionsResourceBuilder());
                    with.Dependency<IResourceBuilder<IPagedList<SernosTrans>>>(new SernosTransactionsPaginatedResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<SernosCount>>>(new SernosCountsResourceBuilder());
                    with.Module<SernosConfigModule>();
                    with.ResponseProcessor<SernosConfigResponseProcessor>();
                    with.ResponseProcessor<SernosTransactionResponseProcessor>();
                    with.ResponseProcessor<SernosConfigsResponseProcessor>();
                    with.ResponseProcessor<SernosTransactionsResponseProcessor>();
                    with.ResponseProcessor<SernosTransactionsPaginatedResponseProcessor>();
                    with.ResponseProcessor<SernosCountsResponseProcessor>();
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