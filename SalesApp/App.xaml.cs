using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesApp.Contexts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesApp
{

    public partial class App : Application
    {
        public static IHost? app { get; private set; } // lek4 1h

        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\perno\Documents\Nackademin\2-databasteknik\inlUppgift\assignment_db.mdf;Integrated Security=True;Connect Timeout=30"));
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e) // lek4 1:15
        {
            await app!.StartAsync();
            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
