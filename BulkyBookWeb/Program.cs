using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddRazorPages();   

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            /*The pipeline specifies how an application
            should respond to a request that is received.
            When the application receives a request from the browser,
            that request goes through the pipeline.
            The pipline allow to add items that I want.
            Pipeline is made up of different middlewares and MVC is a type
            of middleware itself. Also authentication, authorization, static 
            files and so on are middleware in the pipeline.
            */
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //below are the middleware
            app.UseHttpsRedirection();
            //UseStaticFiles are files defined in wwwRoot
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}