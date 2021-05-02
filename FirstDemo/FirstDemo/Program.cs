using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // amra amn logging hard code na kore confugbuilder diye pass kore standard maintain korchii... jodi amn ta na koree logic diye kortm tahole prottek bar built kore kore deploy kortee hoto 
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                                .AddEnvironmentVariables()
                                .Build(); // eta amader startup e jmn configuration set korchi amn e ekta create korchi jatey logger kothay log write korbe seta bujhee 
            /*nicher purata ekta design pattern*/
            Log.Logger = new LoggerConfiguration() // seriloger object create korechi.
            .MinimumLevel.Debug() //logging er bhivinno level thake sekhane amraa level ta create korchi minimum level debug r o onek level ache jmn debug, warning, error
            .MinimumLevel.Override("Microsoft",     // appsettings.json e gele dekhte pabo microsoft ekta built in level create koreche seta warning seta k ovverride korbe eta
            LogEventLevel.Warning)
            .Enrich.FromLogContext() //must ditee hobe eta logger tar formatting kmn hobe seta bujhaay
            .ReadFrom.Configuration(configBuilder) // configbuilder pass kore diyechi jate logger bujhe amr kothay logger write korbo ki database naki knu file write korbo seta read korbee
            .CreateLogger(); //log create korche finally
            try
            {
                Log.Information("Application Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
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
                          webBuilder.UseUrls("http://*:80");
                   });
           }

}
        
        
 
