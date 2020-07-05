using App.Seguro.Infra.Repository;
using App.Seguro.Service;
using App.Seguro.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using teste.Infra.Data;


namespace teste
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<SeguroDbContext>(options =>
               options.UseOracle(Configuration.GetConnectionString("SeguroDataConnection")));

            services.AddScoped<IContext, SeguroDbContext>();
            services.AddTransient<ISeguroVeiculoService, SeguroVeiculoService>();
            services.AddTransient<ICalculoSeguroVeiculoRepository, CalculoSeguroVeiculoRepository>();


            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
