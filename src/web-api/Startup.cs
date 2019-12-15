using AutoMapper;
using Autofac;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.Extensions.Logging;
using ResilientIntegration.Api;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using ResilientIntegration.Api.Filters;
using ResilientIntegration.Core;

namespace WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IHostingEnvironment env, IConfiguration config, ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ApiExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Resilient Integration API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddMassTransit(MassTransitConfig.Configure);

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ApiModule());
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resilient Integration V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
