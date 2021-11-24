using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServisesBL
{
     public static class IServiceCollectionExtention
    {
        public static IServiceCollection AddDependencies(this IServiceCollection collection)
        {
            // collection.AddScoped<IUserRepository, UserRepository>();

           
            collection.AddDbContext<easyPlan>(opt =>
             opt.UseSqlServer("Data Source=DESKTOP-AATM9US;Initial Catalog=EeasyPlan;Integrated Security=True"));

            return collection;
        }




    }
}
