using BitsOrchestraTest.Domain;
using BitsOrchestraTest.Domain.Repositories;
using BitsOrchestraTest.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BitsOrchestraTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value));
            builder.Services.AddScoped<IPersonRepository, PersonRepositoryEF>();
            builder.Services.AddAutoMapper(typeof(AppMappingProfile));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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