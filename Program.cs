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

            // Configuração do DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(connectionString)
            );

            // Adição de serviços adicionais
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configuração do pipeline de requisição HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // Configurações adicionais de segurança e performance (ex.: app.UseHsts(), app.UseHttpsRedirection(), etc.)
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Mapeamento das páginas Razor
            app.MapRazorPages();

            app.Run();

            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
