using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFluentValidation.Domain.Entidades.Validations;
using ProjetoFluentValidation.Domain.Intefaces;
using ProjetoFluentValidation.Infra.Context;
using ProjetoFluentValidation.Infra.Repositories;
using System.Reflection;

namespace ProjetoFluenteValidation.API;

public static class Startup
{
    public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppContextDB>(options => options.UseSqlServer(connectionString));
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryUsuario, RepostitoryUsuario>();
    }

    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }

    public static void ConfigureMediator(this IServiceCollection services)
    {
        //var assembliesComHandlers = Assembly.GetExecutingAssembly()
        //    .GetReferencedAssemblies()
        //    .Select(Assembly.Load)
        //    .Where(x => x.GetTypes().Any(t => t.IsAssignableTo(typeof(IRequestHandler<,>))));

        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembliesComHandlers.ToArray()));

        var assemblyComHandlers = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "ProjetoFluentValidation.Domain.dll"));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblyComHandlers));
    }
}
