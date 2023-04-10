using Application.Features.Questions.Commands.CreateQuestionCommand;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System.Reflection;

namespace Application;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateQuestionCommand>());
        services.AddTransient<IQuestionRepository, QuestionRepository>();
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));  //???

        return services;
    }
}
