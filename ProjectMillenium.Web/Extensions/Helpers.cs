using ProjectMillenium.Core.Helpers;
using ProjectMillenium.Data.Implements;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Web.Extensions
{
        public static class Helpers 
        {/// <summary>
        /// Password hashing islemlerini containera ekler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

           public static IServiceCollection AddHelpers(this IServiceCollection services)
            {
                services.AddTransient<IPasswordHasher, PasswordHasher>();

                return services;
            }


        }

    
}
