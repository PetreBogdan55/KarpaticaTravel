using FluentValidation.AspNetCore;
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.Mapping;
using KarpaticaTravelAPI.Processors.ActivityProcessor;
using KarpaticaTravelAPI.Processors.CityProcessor;
using KarpaticaTravelAPI.Processors.CountryProcessor;
using KarpaticaTravelAPI.Processors.UserProcessor;
using KarpaticaTravelAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KarpaticaTravelAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc().AddFluentValidation(validationConfig => validationConfig.RegisterValidatorsFromAssemblies(GetAssembliesWithPossibleValidation()));

            services.AddDbContext<KarpaticaTravelContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KarpaticaDbConnectionString")));

            services.AddAutoMapper(typeof(MapperProfile));

            services.TryAddScoped<IUserRepository, UserRepository>();
            services.TryAddScoped<ICityRepository, CityRepository>();
            services.TryAddScoped<ICountryRepository, CountryRepository>();
            services.TryAddScoped<IActivityRepository, ActivityRepository>();

            services.TryAddScoped<IUserProcessor, UserProcessor>();
            services.TryAddScoped<ICityProcessor, CityProcessor>();
            services.TryAddScoped<IActivityProcessor, ActivityProcessor>();
            services.TryAddScoped<ICountryProcessor, CountryProcessor>();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KarpaticaTravelAPI", Version = "v1" });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KarpaticaTravelAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEnumerable<Assembly> GetAssembliesWithPossibleValidation()
        {
            string[] assembliesToIgnore = { "Microsoft.CodeAnalysis.VisualBasic" };

            return AppDomain.CurrentDomain.GetAssemblies().Where(x =>
               !x.IsDynamic && !assembliesToIgnore.Contains(x.GetName().Name, StringComparer.CurrentCultureIgnoreCase));
        }
    }
}