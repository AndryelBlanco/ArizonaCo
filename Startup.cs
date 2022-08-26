﻿using Lancheria.Context;
using Lancheria.Repositories;
using Lancheria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lancheria
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
            //Registrando o Service do DBContext
            //Pegamos a ConecctionString do appsettings.json
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Transient: Cria uma nova instância do servico cada vez que um servico e solicitado do provedor de servicos. Se o servico for descartavel o escopo monitorara todas as instancias e destruira todas quando o servico for descartado
            //Scoped: Uma nova instancia e criada a cada request
            //Singleton: Apenas uma instancia do servico é criada se ainda não estiver registrada como uma instancia


            //Serve para injetar instancias dos repositorios nos controllers
            services.AddTransient<IBurgerRepository, BurgerRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}