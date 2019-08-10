using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupportAPI.Data;

namespace SupportAPI
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            //Configurações
            _config = config;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //Onde vamos colocar os serviços
            string conString = "Data Source = localhost; Initial Catalog = DEV; Integrated Security = true; ";
            //string conString = "server=localhost; uid=sa; pwd=123456; database=DEV";

            services.AddDbContextPool<BaseContext>(options => options.UseSqlServer(conString));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //habilita que as requisições sejam feitas por outros computadores!
            app.UseCors(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}
