namespace NewsSystem.Domain
{
    using Common; 
    using Microsoft.Extensions.DependencyInjection;
    using Models.Article;

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
