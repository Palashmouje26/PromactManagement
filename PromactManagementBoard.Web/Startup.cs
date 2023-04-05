using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PromactManagement.DomainModel.ApplicationClass.Mapper;
using PromactManagement.DomainModel.DbContexts;
using PromactManagement.Repository.CompanyRegistration;
using PromactManagement.Repository.Data;
using PromactManagement.Repository.OrganizationModuleRegistration;
using PromactManagement.Repository.OrganizationRegistration;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PromactManagementBoard.Web
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
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IOrganizationRegistration, OrganizationRegistration>();
            services.AddScoped<ICompanyRegistrationRepository, CompanyRegistrationRepository>();
            services.AddDbContext<OrganizationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WEB API",
                    Version = "v1"
                });
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API");
                c.DocumentTitle = "WEB API";
                c.DocExpansion(DocExpansion.List);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
