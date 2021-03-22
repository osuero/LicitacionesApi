using Api.Business.EntidadRepositorio;
using Api.Data;
using Licitaciones.Helper;
using Licitaciones.Helper.Iservices;
using Licitaciones.Mappers.MapperPerfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Licitaciones
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<ApiDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IUserServices, UserService>();
            services.AddAutoMapper(typeof(MapperPerfil));
            services.AddTransient<NegocioRepositorio, NegocioRepositorio>();
            services.AddTransient<RepresentanteRepositorio, RepresentanteRepositorio>();
            services.AddTransient<UsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<ArchivoRepositorio, ArchivoRepositorio>();
            services.AddTransient<InstitucionesRepositorio, InstitucionesRepositorio>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<JwtMiddleware>();

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
