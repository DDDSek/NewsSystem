namespace NewsSystem.Domain.Common.Models
{
    using FluentAssertions;
    using NewsSystem.Domain.ArticleCreation.Models.Journalists;
    using Xunit;

    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new PhoneNumber("Sechko");
            var second = new PhoneNumber("Sechko");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new PhoneNumber("Sechko");
            var second = new PhoneNumber("Bechko");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}
