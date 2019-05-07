namespace Linn.Products.Facade.Tests.SernosTransactionServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSernosTrans : ContextBase
    {
        private IResult<SernosTrans> result;

        private SernosTransactionResource resource;

        private SernosTrans sernosTrans;

        [SetUp]
        public void SetUp()
        {
            this.sernosTrans = new SernosTrans { TransCode = "t" };
            this.resource = new SernosTransactionResource
                                {
                                    TransDescription = "d",
                                    ManualPost = "Y"
                                };
            this.SerialNumberTransactionRepository.FindById("t").Returns(this.sernosTrans);
            this.result = this.Sut.Update(this.sernosTrans.TransCode, this.resource);
        }

        [Test]
        public void ShouldGetSerialNumberTransaction()
        {
            this.SerialNumberTransactionRepository.Received().FindById(this.sernosTrans.TransCode);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SernosTrans>>();
            var dataResult = ((SuccessResult<SernosTrans>)this.result).Data;
            dataResult.TransCode.Should().Be("t");
            dataResult.TransDescription.Should().Be(this.resource.TransDescription);
            dataResult.ManualPost.Should().Be(this.resource.ManualPost);
        }
    }
}
