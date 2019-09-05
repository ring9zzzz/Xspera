using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xspera.BAL.Services;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;

namespace Xspera
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<XsperaContext>
            (
                 //option => option.UseInMemoryDatabase()
                 option => option.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"),
                 d => d.MigrationsAssembly("Application"))

            );
            services.AddMvcCore(options =>
                 {
                     options.RequireHttpsPermanent = true; // does not affect api requests
                     options.RespectBrowserAcceptHeader = true; // false by default
                 });
            services.AddMvc()
                  .AddJsonOptions(
                      options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                           );
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IRepository, MainRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}