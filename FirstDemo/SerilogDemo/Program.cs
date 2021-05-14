using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace SerilogDemo
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            
           
            var configbuilder = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", false)
                                .AddEnvironmentVariables()
                                .Build();

            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Debug()
                         .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                         .Enrich.FromLogContext()
                         .ReadFrom.Configuration(configbuilder)
                         .WriteTo.Email(new EmailConnectionInfo()
                         {
                             FromEmail = "helloforasp.netcore@gmail.com",
                             ToEmail = "saikatdastushar1997@gmail.com",
                             MailServer = "smtp.gmail.com",
                             NetworkCredentials = new NetworkCredential()
                             {
                                 UserName = "helloforasp.netcore@gmail.com",
                                 Password = "saikatdas10"
                             },
                             EnableSsl = true,
                             IsBodyHtml=true,
                             EmailSubject = "Application Log",
                             Port = 587

                         }, 
                         outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}[{Level}] {Message} {NewLine} {Exception}",batchPostingLimit:1,restrictedToMinimumLevel:LogEventLevel.Error)
                         .CreateLogger();

            try
            {
                Log.Information("Application Starting Up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application Starting Failed");

            }
            finally
            {
                Log.CloseAndFlush();
            }

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http//*:80");
                });
    }
}
