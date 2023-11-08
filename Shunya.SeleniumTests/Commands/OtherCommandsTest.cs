// Author:- raj
// Created At:- 04/11/2023/8:36 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Shunya.Selenium;
using Shunya.Selenium.Other;
using Shunya.Selenium.Query;
using Shunya.Selenium.Selenium;
using ILogger = Serilog.ILogger;


namespace Shunya.SeleniumTests;

public class OtherCommandsTest
{
    private ILogger<OtherCommandsTest> logger;
    private SnSelenium snSel;
    
    [SetUp]
    public void Setup()
    {
        var serilogLogger = new LoggerConfiguration().WriteTo.NUnitOutput().CreateLogger();
         this.logger = new SerilogLoggerFactory(serilogLogger)
            .CreateLogger<OtherCommandsTest>(); 
         snSel = new SnSelenium(Constants.SupportedBrowsers.CHROME,logger);
        logger.LogInformation("Setup Finished");
    }
    
    [TearDown]
    public void GlobalTeardown()
    {
        // Do logout here
        logger.LogError("DOne error");
        snSel.Close();
    }

    [Test]
    public void VisitTest()
    {
        snSel.Visit("https://www.youtube.com/").Execute();
        Assert.Pass();
    }
    
    [Test]
    public void VisitTest2()
    {
        snSel.Visit("https://www.google.com/").Execute();
        Assert.Pass();
    }
}