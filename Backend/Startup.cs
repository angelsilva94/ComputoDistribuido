using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Backend
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
	    services.AddCors();
            services.AddMvc();
            // var connection = @"Data Source=localhost;Initial Catalog=Proyecto;User ID=SA;Password=Angel.$ilva;Trusted_Connection=False;";
            var connection = @"server=localhost;database=UAADb;user=root;password=angel.silva";            
            // services.AddDbContext<ProyectoContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<ProyectoContext>(options => options.UseMySQL(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // if (string.IsNullOrWhiteSpace(env.WebRootPath))
            // {
            //     env.WebRootPath = $"/var/www/html/imagenes";
            // }
	        app.UseCors (b => b.WithOrigins ("http:/192.168.88.149")
                .AllowAnyOrigin ()
                .AllowCredentials ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());


            app.UseMvc();
        }
    }
}
