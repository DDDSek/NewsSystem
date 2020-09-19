namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using System;
    using Exceptions;
    using FluentAssertions; 
    using Xunit;

    public class ArticleFactorySpecs
    {
        //[Fact]
        //public void BuildShouldThrowExceptionIfCommentIsNotSet()
        //{
        //    // Assert
        //    var articleFactory = new ArticleFactory();

        //    // Act
        //    Action act = () => articleFactory
        //        .WithCategory("TestCategory", "TestDescription")
        //        .WithOptions(true, 2, TransmissionType.Automatic)
        //        .Build();

        //    // Assert
        //    act.Should().Throw<InvalidArticleException>();
        //}

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryIsNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithManufacturer("TestManufacturer")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfOptionsAreNotSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            Action act = () => articleFactory
                .WithManufacturer("TestManufacturer")
                .WithCategory("TestCategory", "TestDescription")
                .Build();

            // Assert
            act.Should().Throw<InvalidArticleException>();
        }

        [Fact]
        public void BuildShouldCreateArticleIfEveryPropertyIsSet()
        {
            // Assert
            var articleFactory = new ArticleFactory();

            // Act
            var article = articleFactory
                .WithManufacturer("TestManufacturer")
                .WithCategory(CategoryFakes.ValidCategoryName, "TestCategoryDescription")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .WithImageUrl("http://test.image.url")
                .WithModel("TestModel")
                .WithPricePerDay(10)
                .Build();

            // Assert
            article.Should().NotBeNull();
        }
    }
}
