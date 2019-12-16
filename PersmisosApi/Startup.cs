using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permisos.DAL;
using Permisos.Service;
using Persmisos.Business;

namespace PersmisosApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddDbContext<ApplicationDbContext>();
            services.Configure<ConnectionStringOption>(options =>
            {
                options.ConStr = Configuration["ConnectionStrings:DefaultConnection"];
            });
            services.AddScoped<IPermisoService, PermisoService>();
            services.AddScoped<ITipoPermisoService, TipoPermisoService>();
            services.AddScoped<IPermisoRepository, PermisoRepository>();
            services.AddScoped<ITipoPermisoRepository, TipoPermisoRepository>();
            services.AddScoped<IPermisosBo, PermisosBo>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            };

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}