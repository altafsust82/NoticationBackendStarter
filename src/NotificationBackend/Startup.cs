using AutoMapper;

using NotificationBackend.Services.Abstract;
using NotificationBackend.Services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog.Extensions.Logging;
using NotificationBackend.DAL.NotificationEntities;

namespace NotificationBackend
{
    public class Startup
    {
        //public static IConfigurationRoot Configuration { get; }
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);            ;

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(o => new XmlDataContractSerializerOutputFormatter()).AddJsonOptions
           (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).
                AddJsonOptions(
                    options =>
                    {
                        options.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
                        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                    }
             );
 
            services.AddCors(
                 options => options.AddPolicy("AllowCors",
                 builder =>
                 {
                     builder                
                         .AllowAnyOrigin() 
                         .AllowAnyMethod() 
                       .AllowCredentials()
                    .AllowAnyHeader(); 
                 })
             );

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(
                    new Swashbuckle.Swagger.Model.Info
                    {
                        Title = "Notification Service API",
                        Version = "v1",

                        Description = "Notification Service Api",
                        TermsOfService = "Should not be used without consent from Developer. Contact: http://logisticssoftware.com",
                        Contact = new Swashbuckle.Swagger.Model.Contact { Name = "Logistics Software Corp.", Email = "support@logisticssoftware.com", Url = "http://logisticssoftware.com" },
                        License = new Swashbuckle.Swagger.Model.License { Name = "(c) 2017, Logistics Software Corp.", Url = "http://logisticssoftware.com" },
                    }
                );
            });
            services.AddOptions();

   
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // Use policy auth.
            services.AddAuthorization();

            services.AddDbContext<NotifContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NotifLocalDBConnectionString")));

            // Repositories
            services.AddScoped<IUserRepository, UserRepsository>();
            services.AddAutoMapper();
            services.AddOptions();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();
         
            app.UseCors("AllowCors");

            app.UseMvc();

            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseSwaggerUi("swagger/ui", swaggerUrl: Configuration["SwaggerUrl:DevSwaggerUrl"] + "/swagger/v1/swagger.json");
            }
            else
            {
                app.UseSwaggerUi("swagger/ui", swaggerUrl: Configuration["SwaggerUrl:ProductionSwaggerUrl"] + "/swagger/v1/swagger.json");
            }
        }
    }
}
