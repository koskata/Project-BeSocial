using BeSocial.Data;
using BeSocial.Services.Interfaces;
using BeSocial.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BeSocial.Data.Models;
using BeSocial.Web.Infrastructure;

namespace BeSocial.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add DbContext to the app
            builder.Services.AddApplicationDbContext(builder.Configuration);
            //Add Identity to the app
            builder.Services.AddApplicationIdentity(builder.Configuration);
            
            builder.Services.AddControllersWithViews();

            //Add Services to the app
            builder.Services.AddApplicationServices(typeof(IPostService));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            await app.CreateAdminRoleAsync();

            await app.RunAsync();
        }
    }
}