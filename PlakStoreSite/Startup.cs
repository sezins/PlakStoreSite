using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlakStoreBusinessLayer.Abstract;
using PlakStoreBusinessLayer.Concrete;
using PlakStoreBusinessLayer.Concrete.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlakStoreSite
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
             //IServiceCollection services, services yazd�g�m�z �c�n metodlar� cag�rab�l�yoruz.
            services.AddControllersWithViews();//
            services.AddScopeBLL();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseRouting();
            app.UseStaticFiles();//stat�c dosyalara er�smem�z� saglar bu da wwwrootun �cer�s�ndek� dosyalard�r stat�c dosylar burada bulunur.css ve js dosyalar�.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute(); // proje cal�s�r cal�smaz HomeController da yer alan Index.cshtml  sayfas�na yonlend�r�l�r
            });
        }
    }
}
