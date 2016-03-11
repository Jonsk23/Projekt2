using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using ViFemWebShopV2.Models;

namespace ViFemWebShopV2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Server=tcp:lzqpwuvj9p.database.windows.net,1433;Database=VIVDTA;User ID=VIVUSER@lzqpwuvj9p;Password=Vivawa2016;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<EshopContext>(options =>
                options.UseSqlServer(connString));


            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
