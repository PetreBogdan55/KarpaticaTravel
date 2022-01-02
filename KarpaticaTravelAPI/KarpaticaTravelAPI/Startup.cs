using FluentValidation.AspNetCore;
using KarpaticaTravelAPI.Infrastructure;
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.Mapping;
using KarpaticaTravelAPI.Processors.ActivityProcessor;
using KarpaticaTravelAPI.Processors.CityProcessor;
using KarpaticaTravelAPI.Processors.CountryProcessor;
using KarpaticaTravelAPI.Processors.ReviewProcessor;
using KarpaticaTravelAPI.Processors.UserProcessor;
using KarpaticaTravelAPI.Repositories.ActivityRepository;
using KarpaticaTravelAPI.Repositories.CityRepository;
using KarpaticaTravelAPI.Repositories.CountryRepository;
using KarpaticaTravelAPI.Repositories.ReviewRepository;
using KarpaticaTravelAPI.Repositories.UserRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using KarpaticaTravelAPI.Processors.LocationProcessor;
using KarpaticaTravelAPI.Repositories.LocationRepository;

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

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("JwtKey").ToString())),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAutoMapper(typeof(MapperProfile));

            services.TryAddScoped<IUserRepository, UserRepository>();
            services.TryAddScoped<ICityRepository, CityRepository>();
            services.TryAddScoped<ICountryRepository, CountryRepository>();
            services.TryAddScoped<IActivityRepository, ActivityRepository>();
            services.TryAddScoped<IReviewRepository, ReviewRepository>();
            services.TryAddScoped<ILocationRepository, LocationRepository>();

            services.TryAddScoped<IUserProcessor, UserProcessor>();
            services.TryAddScoped<ICityProcessor, CityProcessor>();
            services.TryAddScoped<IActivityProcessor, ActivityProcessor>();
            services.TryAddScoped<ICountryProcessor, CountryProcessor>();
            services.TryAddScoped<IReviewProcessor, ReviewProcessor>();
            services.TryAddScoped<ILocationProcessor, LocationProcessor>();

            services.AddScoped<ITokenManager, TokenManager>();

            services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KarpaticaTravelAPI", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

                c.AddSecurityRequirement(securityRequirement);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KarpaticaTravelAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();


            app.UseAuthorization();

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