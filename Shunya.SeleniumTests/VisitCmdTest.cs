// Author:- raj
// Created At:- 04/11/2023/8:36 pm

using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Shunya.Selenium;
using Shunya.Selenium.Other;
using Shunya.Selenium.Selenium;
using ILogger = Serilog.ILogger;


namespace Shunya.SeleniumTests;

public class VisitCmdTest
{
    [SetUp]
    public void Setup()
    {
        // var loggers = new LoggerConfiguration()
        //     .MinimumLevel.Verbose()
        //     .Enrich.FromLogContext();
        //
        // loggers.WriteTo.Logger(logger => logger
        //     .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Verbose));

        // Log.Logger = loggers.CreateLogger();
        
        var serilogLogger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Verbose()
            .WriteTo.Debug() // Serilog.Sinks.Debug
            .CreateLogger();

        var microsoftLogger = new SerilogLoggerFactory(serilogLogger)
            .CreateLogger<VisitCmdTest>(); 
        
        
        Log.Logger.Information("Logger is initialized");
    }

    [Test]
    public void Test1()
    {
        var serilogLogger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Verbose()
            .WriteTo.Debug() // Serilog.Sinks.Debug
            .CreateLogger();

        var microsoftLogger = new SerilogLoggerFactory(serilogLogger)
            .CreateLogger<VisitCmdTest>(); 
        
        //private static ILogger log = Log.ForContext(typeof(VisitCmdTest));
        
        SnSelenium sn = new SnSelenium(Constants.SupportedBrowsers.CHROME,microsoftLogger);
        sn.Visit("https://www.youtube.com/").Execute();
        
        Assert.Pass();
    }
}