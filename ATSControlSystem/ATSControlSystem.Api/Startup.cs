using System.Net;
using System.Reflection;
using ATSControlSystem.Api.Middleware;
using ATSControlSystem.Api.Models;
using ATSControlSystem.Application.Contract;
using ATSControlSystem.Application.Extensions;
using ATSControlSystem.Application.Service;
using ATSControlSystem.Domain.Contract.Infrastruture.Repository;
using ATSControlSystem.Domain.Entity;
using AutoMapper;
using FluentValidation;
using ATSControlSystem.Infrastructure.Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ATSControlSystem.Api
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
            services.AddSwaggerGen();

            var settings = new ApiSettings();
            Configuration.GetSection("ApiSettings").Bind(settings);

            SetupAutoMapper(services);
            SetupRepository(services, settings.MongoSettings);
            SetupServices(services);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private static void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IJobAppService, JobAppService>();
            services.AddScoped<ICandidateAppService, CandidateAppService>();
        }

        private static void SetupAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var sp = services.BuildServiceProvider();
            GlobalMapper.Mapper = sp.GetService<IMapper>() ?? throw new Exception("error loading globalMapper");
        }

        private static void SetupRepository(IServiceCollection services, MongoSettings mongoSettings)
        {
            var connectionString = $"{mongoSettings.ConnectionString}/{mongoSettings.DatabaseName}?maxIdleTimeMS=30000";
            var client = new MongoClient(connectionString);

            var collection = client.GetDatabase(mongoSettings.DatabaseName);

            BsonClassMap.RegisterClassMap<Candidate>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty("FirstName").SetElementName("FirstName");
                cm.MapProperty("LastName").SetElementName("LastName");
                cm.MapProperty("BirthDate").SetElementName("BirthDate");
            });

            services.AddSingleton<IMongoCollection<Job>>(collection.GetCollection<Job>("Job"));
            services.AddSingleton<IJobRepository, JobRepository>();

            services.AddSingleton<IMongoCollection<Candidate>>(collection.GetCollection<Candidate>("Candidate"));
            services.AddSingleton<ICandidateRepository, CandidateRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseMiddleware<RequestResponseLogMiddleware>();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
                var response = new { exception?.Message };

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}