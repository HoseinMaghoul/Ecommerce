// // Startup.cs

using Application.Handlers.Login;
using Domain.IServices;
using Infrastructure.DBContext;
using Infrastructure.Identity.Services;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure.Identity;

public static class DependencyInjection
{

    
    public static void AddInfrastructureIdentity(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        // services.AddMediatR(typeof(LoginHandler).Assembly);


    

    }
}


