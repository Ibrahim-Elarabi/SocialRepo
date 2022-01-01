using BlogTask.Models;
using BlogTask.Repository;
using BlogTaskDB.DAL.Repository.ClassRepo;
using BlogTaskDB.DAL.Repository.InterfaceRepo;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask
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
            //services.AddDbContext<BlogDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("BlogCOnnection")));
            services.AddAutoMapper(x => x.AddProfile(new DomianProfile()));

            services.AddControllersWithViews();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IGroupReository, GroupRepository>();

            services.AddScoped<IGroupUserRepository, GroupUserRepository>();

            #region Using Genrics Repositort

            services.AddScoped<IGroupReositoryG, GroupRepositoryG>();
            services.AddScoped<IGroupUserRepositoryG, GroupUserRepositoryG>();
            services.AddScoped<IPostRepositoryG, PostRepositoryG>();
            #endregion
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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
