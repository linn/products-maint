namespace Linn.Products.Domain.Linnapps.Tests.SernosNoteSpecs
{
    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosNote Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SernosNote("note")
                           {
                               SernosGroup = "group",
                               SernosNumber = 1,
                               TransCode = "code",
                               SernosNoteId = 1,
                               SernosTRef = 1
                           };
        }
    }
}