using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STS.Infrastructure.Security;
using System.Diagnostics.CodeAnalysis;

namespace STS.Infrastructure.IoC
{
    [ExcludeFromCodeCoverage]
    public static class ResolveDependencies
    {

        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            TokenGenerator.TokenConfig = configuration.GetSection("Token").Get<Token>();

            return services;
        }
    }
}
