using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpContextAccessor();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });



        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.IsEssential = true;
                options.LoginPath = "/MyAccountMVC/Login"; // Set the login page path
            });
        
        builder.Services.AddSession(options =>
        {
            // Configure session options as needed
            options.Cookie.IsEssential = true; // Make the session cookie essential
        });



        builder.Services.AddDistributedMemoryCache();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }




        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("AllowSpecificOrigin");



        app.MapControllerRoute(
            name: "AccountCreated",
            pattern: "Created",
            defaults: new { controller = "MyAccountMVC", action = "Created" });

        app.MapControllerRoute(
            name: "Dashboard",
            pattern: "Dashboard/{AccName}/{Id}",
            defaults: new { controller = "MyAccountMVC", action = "Index" });

        app.MapControllerRoute(
            name: "Dashboard",
            pattern: "Dashboard",
            defaults: new { controller = "MyAccountMVC", action = "Index" });

        app.MapControllerRoute(
            name: "CreateAccount",
            pattern: "/Tasks/Edit/{id?}",
            defaults: new { controller = "Task", action = "Edit" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
             name: "LoginAttempt",
             pattern: "LoginAttempt/{AccName}/{Id}",
             defaults: new { controller = "MyAccountMVC", action = "LoginAttempt" });


        app.UseSession();

        app.Run();
    }
}
