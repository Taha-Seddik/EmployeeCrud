﻿using EmployeeCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(config.GetConnectionString("SQLDatabase"))
            );
        }

    }
}