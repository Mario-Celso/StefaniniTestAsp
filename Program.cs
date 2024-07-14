using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using StefaniniTestAsp.Data;

namespace StefaniniTestAsp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura��o do DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionString)
            );

            // Adi��o de servi�os adicionais
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configura��o do pipeline de requisi��o HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // Configura��es adicionais de seguran�a e performance (ex.: app.UseHsts(), app.UseHttpsRedirection(), etc.)
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Mapeamento das p�ginas Razor
            app.MapRazorPages();

            app.Run();

            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
