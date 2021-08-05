using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Api.DAO;
using Api.Interfaces;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<IFundsDAO, FundsDAO>();
            }).ConfigureLogging(builder =>
            {
                builder.AddLog4Net("Config/log4net.config");
            })
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();
    }
}
