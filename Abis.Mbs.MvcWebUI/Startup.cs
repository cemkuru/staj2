
using Abis.Mbs.Business.Abstract;
using Abis.Mbs.Business.Concrete;
using Abis.Mbs.DataAccess.Abstract;
using Abis.Mbs.DataAccess.Concrete.EntityFramework;
using Abis.Mbs.MvcWebUI.Entities;
using Abis.Mbs.MvcWebUI.Middlewares;
using Abis.Mbs.MvcWebUI.Services;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace Abis.Mbs.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            // Job Service and job data acess layers
            services.AddScoped<IJobService, JobManager>();
            services.AddScoped<IJobDal, EfJobDal>();

            //Application job form

            services.AddScoped<IJobFormService, JobFormManager>();
            services.AddScoped<IJobFormDal, EfJobFormDal>();
            
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddScoped<ICartService, CartService>();
            services.AddDbContext<CustomIdentityDbContext>
            (options => options.UseSqlServer("Data Source=abisstaj2019.database.windows.net;Database=mbs_2019;User ID=Abisstaj2019;Password=Chha4773;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();

            // Facebook and Google authentication login 7/30/2019
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
            }).AddGoogle(options =>
            {
                options.ClientId = "279391159521-jddnprd07bnk2tp8l2u2fkivrj9ul7sp.apps.googleusercontent.com";
                options.ClientSecret = "0GDZGnuTfrQKAmAwi53SRDjO";
            }).AddFacebook(options =>
            {
                options.AppId = "695158094276594";
                options.AppSecret = "7fd60c3070e548a0d71ed4b6b4b1708c";
            });
            // 8/1/2019
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure
            (IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            RoleManager<CustomIdentityRole> roleManager
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseSession();
            app.UseMvc(ConfigureRoutes);
            RoleInitializer.Initialize(roleManager);
        }
        private void ConfigureRoutes(IRouteBuilder routeBuilder)

        {

            routeBuilder.MapRoute(name:"areaRoute", template:"{area:exists}/{controller=Admin}/{action=Index}/{id?}");

            routeBuilder.MapRoute(name: "UserareaRoute", template: "{area:exists}/{controller=User}/{action=Job}/{id?}");



            routeBuilder.MapRoute(
                name: "default",
                template:"{controller=HomePage}/{action=Index}/{id?}");
            
        }

    }
}





