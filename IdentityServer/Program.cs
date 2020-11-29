// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Net;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                       webBuilder.UseKestrel(options => 
                        {
                            options.Listen(IPAddress.Loopback, 5021);
                            options.Listen(IPAddress.Loopback, 5001, listenOptions => 
                            {
                                listenOptions.UseHttps("localhost.pfx", "Mati1995");
                            });
                        })
                        .UseStartup<Startup>();
                });
    }
}