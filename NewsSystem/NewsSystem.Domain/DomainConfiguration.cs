namespace NewsSystem.Domain
{
    using Microsoft.Extensions.DependencyInjection;

    using Common;

    using Domain.ArticleCreation.Models.Articles; 

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
                .AddTransient<IInitialData, CategoryData>();
    }
}
