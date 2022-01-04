using Blog.Presentation.Controllers;
using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace Blog.Extensions
{
    public static class ServiceExtensions
    {
        //Configuration for CORS (Cross-Origin Resource Sharing) =>> (Should apply restriction later)
        public static void ConfigureCors(this IServiceCollection services) =>
             services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy", builder =>
                 builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithExposedHeaders("X-Pagination"));
             });


        // IIS Configuration For Hosting in IIS (For now Default configuration)
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
             services.Configure<IISOptions>(options =>{});



        //adding the logger service inside the .NET Core’s IOC container 1/2 (See program File)
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();



        //registering RepositoryManager class in the main project
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();


        //registering ServiceManager class in the main project
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config => 
                config.OutputFormatters.Add(new CsvOutputFormatter()));


        //Adding CustumMediaTypes AKA Json/XML
        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var systemTextJsonOutputFormatter = config.OutputFormatters
                    .OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();
                   
                if (systemTextJsonOutputFormatter != null)
                {
                    systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.codemaze.hateoas+json");
                    systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.codemaze.apiroot+json");
                }
                    
                var xmlOutputFormatter = config.OutputFormatters
                .OfType<XmlDataContractSerializerOutputFormatter>()?
                .FirstOrDefault();

                if (xmlOutputFormatter != null)
                {
                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.codemaze.hateoas+xml");
                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.codemaze.apiroot+xml");
                }
            });
        }


        //Adding versionning-service to the service collection

        public static void ConfigureVersioning(this IServiceCollection services)
        {
           
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;

                opt.AssumeDefaultVersionWhenUnspecified = true;

                opt.DefaultApiVersion = new ApiVersion(1, 0);
                
                opt.ApiVersionReader = new QueryStringApiVersionReader("api-version");

                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");

                opt.Conventions.Controller<CategoriesController>()
                .HasApiVersion(new ApiVersion(1, 0));

                opt.Conventions.Controller<CategoriesV2Controller>()
                .HasDeprecatedApiVersion(new ApiVersion(2, 0));
            });

        }

        public static void ConfigureResponseCaching(this IServiceCollection services) => 
            services.AddResponseCaching();


    }
}
