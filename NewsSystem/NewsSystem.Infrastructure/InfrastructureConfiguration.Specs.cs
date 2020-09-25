namespace NewsSystem.Infrastructure
{
    using System;
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;
    using FakeItEasy;
    using FluentAssertions;
    using AutoMapper;

    using Application.ArticleCreation.Articles;
    using Infrastructure.ArticleCreation;
    using Infrastructure.Common.Persistence;



    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<NewsSystemDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddTransient(_ => A.Fake<IArticleCreationDbContext>());

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IArticleRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
