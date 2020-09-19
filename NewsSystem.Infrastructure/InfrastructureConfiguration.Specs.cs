namespace NewsSystem.Infrastructure
{
    using System;
    using System.Reflection; 
    using AutoMapper; 
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using NewsSystem.Application.ArticleCreation.Articles;
    using NewsSystem.Infrastructure.Common.Persistence;
    using Xunit;

    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<NewsSystemDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddTransient(_ => A.Fake<IDealershipDbContext>());

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
