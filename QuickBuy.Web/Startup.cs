using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickBuy.repositorio.Contexto;
using QuickBuy.repositorio.Repositorios;
using QuyckBuy.Dominio.contrato;

namespace QuickBuy.Web
{
	public class Startup
    {
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
        {
			var build = new ConfigurationBuilder();

			// arquivo criado para adicionar as informa��es de conex�o do banco de dados.
			build.AddJsonFile("config.json",optional: false, reloadOnChange:true);

            Configuration = build.Build();

        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// A linha AddJsonOptions serve para evitar referencia circular, evitando que d� erro de m� forma��o de JSON ao retornar o JSON da API.
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
				.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			// Utilizado para pegar o contexto da requisi��o
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			var connectionString = Configuration.GetConnectionString("QuickBuyDb");
			services.AddDbContext<QuickBuycontexto>(option =>
														option.UseLazyLoadingProxies()
														.UseMySql(connectionString, 
																			m => m.MigrationsAssembly("QuickBuy.repositorio")));

			// fazer esse mapeamento para todas as classes que possuem interface com sua classe pr�pria.
			services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
			services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
			services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
                }
            });
        }
    }
}
