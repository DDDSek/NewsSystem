namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;

    public class CategorySpecs
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            // Act
            Action act = () => new Category("Valid name", "Valid description text");

            // Assert
            act.Should().NotThrow<InvalidArticleException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new Category("", "Valid description text");

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }
    }
}
