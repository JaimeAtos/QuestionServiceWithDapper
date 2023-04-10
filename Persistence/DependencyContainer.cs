using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyContainer
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddSingleton(new QuestionDbContextDapper(connectionString));
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        return services;
    }
}
