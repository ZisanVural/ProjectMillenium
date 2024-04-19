using ProjectMillenium.Business.Implements;
using ProjectMillenium.Business.Interfaces;

namespace ProjectMillenium.Web.Extensions
{
    public static class BusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IClaimService, ClaimService>();

            return services;
        }
    }
}
