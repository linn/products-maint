namespace Linn.Products.Domain.Tests.CartonDetailsReportServiceSpecs
{
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;
    using Linn.Products.Domain.Repositories;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected CartonDetailsReportService Sut { get; private set; }

        protected ICartonRepository CartonRepository { get; private set; }

        protected ResultsModel Results { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.CartonRepository = Substitute.For<ICartonRepository>();

            this.Sut = new CartonDetailsReportService(this.CartonRepository);
        }
    }
}
