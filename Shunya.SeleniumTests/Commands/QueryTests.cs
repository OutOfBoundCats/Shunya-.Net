// Author:- raj
// Created At:- 09/11/2023/3:57 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Serilog;
using Serilog.Extensions.Logging;
using Shunya.Selenium;
using Shunya.Selenium.Other;
using Shunya.Selenium.Query;
using Shunya.Selenium.Selenium;

namespace Shunya.SeleniumTests;

public class QueryTests
{
    private ILogger<QueryTests> logger;
    private SnSelenium snSel;
    
    [SetUp]
    public void Setup()
    {
        var serilogLogger = new LoggerConfiguration().WriteTo.NUnitOutput().CreateLogger();
        this.logger = new SerilogLoggerFactory(serilogLogger)
            .CreateLogger<QueryTests>(); 
        snSel = new SnSelenium(Constants.SupportedBrowsers.CHROME,logger);
        logger.LogInformation("Setup Finished");
    }
    
    [TearDown]
    public void GlobalTeardown()
    {
        // Do logout here
        logger.LogInformation("Done Execution");
        snSel.Close();
    }
    
        
    [Test]
    public void ClosestTest()
    {
        var foundElement=snSel.Visit("https://hasare.com").Execute()
            .GetOne(By.XPath("/html/body/div/div[1]/main/div/div[1]/div/h1")).Execute()
            .Closest("div").Execute().GetResult();
        logger.LogInformation(foundElement.TagName);
        Assert.Pass();
    }
    
    

}