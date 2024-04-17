using BeSocial.Services.Interfaces;
using BeSocial.Web.Infrastructure;

using Microsoft.AspNetCore.Mvc;

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

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            //Add Services to the app
            builder.Services.AddApplicationServices(typeof(IPostService));
            //builder.Services.AddApplicationServices(typeof(IUserService));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
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
                app.MapDefaultControllerRoute();
                app.MapRazorPages();
            });


            await app.CreateAdminRoleAsync();

            await app.RunAsync();
        }
    }
}