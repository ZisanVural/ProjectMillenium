using Microsoft.Extensions.DependencyInjection;
using ProjectMillenium.Core.Web;
using ProjectMillenium.Data.Implements;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectMillenium.Core.Extensions
{
    public static class RepositoryServiceExtension
    {/// <summary>
    /// data katmanı repository sınıflarını containera ekler
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)//void dönmemeli
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClaimRepository, ClaimRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IRoleClaimRepository, RoleClaimRepository>();

            return services;
        }
    }

}
