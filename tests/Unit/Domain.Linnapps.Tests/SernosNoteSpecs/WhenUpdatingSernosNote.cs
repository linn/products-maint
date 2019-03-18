namespace Linn.Products.Domain.Linnapps.Tests.SernosNoteSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenUpdatingSernosNote : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.Update("new note", "new sernos group", 2, 2, "new trans code");
        }

        [Test]
        public void ShouldUpdateSernosNote()
        {
            this.Sut.SernosNotes.Should().Be("new note");
            this.Sut.SernosGroup.Should().Be("new sernos group");
            this.Sut.SernosNumber.Should().Be(2);
//            this.Sut.SernosTref.Should().Be(2);
            this.Sut.TransCode.Should().Be("new trans code");
        }
    }
}