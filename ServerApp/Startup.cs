using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
readonly string MyAllowOrigins="_myAllowOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         // services.AddDbContext<OrderContext>(x=>x.UseSqlServer("Data Source=DESKTOP-S5IA667;database=SOCIAL;Integrated Security=True"));
          services.AddDbContext<OrderContext>(x=>x.UseSqlite("Data Source=test.db"));
            services.AddControllers();
            services.AddCors(options=>options.AddPolicy(
              name:MyAllowOrigins,
              builder=>{
                builder.WithOrigins("http://localhost:4200")
                .WithMethods("GET","POST","PUT");
              }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseCors(MyAllowOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
