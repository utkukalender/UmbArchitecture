using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umb.Application.Services.User;
using Umb.Persistance.Context;
using Umb.Persistance.Repositories;

namespace Umb.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                                                     options.UseSqlServer("Server=UTKU\\SQLEXPRESS; Initial Catalog=UmbDb; Trusted_Connection = True; TrustServerCertificate = True; Encrypt = True; MultipleActiveResultSets = true;"));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
