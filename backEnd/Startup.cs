using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.Repositories;
using ServisesBL;
using ServisesBL.Profiles;

namespace backEnd
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRpository>();
            services.AddScoped<IUserServise, UserServise>();
            services.AddScoped<IAdminRepository, AdminRepository>();           
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<IProgramRepositort, ProgramRepositort>();
            services.AddScoped<IGlobalInterface, Global>();

            services.AddDependencies();

            services.AddCors();
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers();
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(AdminProfile));
            services.AddAutoMapper(typeof(ProgramProfile));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseRouting();
                app.UseCors();
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                app.UseMvc();

            }
        }
    }
}

