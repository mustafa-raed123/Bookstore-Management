using Bookstore_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            // Configure the DbContext to use SQL Server with the connection string from configuration
            builder.Services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // Handle errors in non-development environments
                app.UseHsts(); // Add HSTS (HTTP Strict Transport Security)
            }

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
            app.UseStaticFiles(); // Enable serving static files

            app.UseRouting(); // Enable routing

            app.UseAuthorization(); // Enable authorization

            // Configure the default route for controllers
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run(); // Start the application
        }
    }
}
