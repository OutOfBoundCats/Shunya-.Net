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
        logger.LogInformation("Done Execution");
        snSel.Close();
    }

    [Test]
    public void VisitTest()
    {
        snSel.Visit("https://www.youtube.com/").Execute();
        Assert.Pass();
    }
    
    [Test]
    public void GetOneTest()
    {
        IWebElement foundElement=snSel.Visit("https://www.selenium.dev").Execute()
            .GetOne(By.XPath("/html/body/div/main/section[2]/1232div/div/div[2]/div/div[1]/h4")).Execute(2,2).GetResult();
        Assert.AreEqual("Selenium IDE",foundElement.Text);
    }
    
    [Test]
    public void GetManyTest()
    {
        var foundElement=snSel.Visit("https://www.selenium.dev").Execute()
            .Get(By.XPath("/html/body/div/main/section[2]/div/div/div[2]/div/div[1]/h4")).Execute().GetResult();
        Assert.AreEqual(1, foundElement.Count());
    }
    
    [Test]
    public void AsTest()
    {
        var foundElement=snSel.Visit("https://www.selenium.dev").Execute()
            .Get(By.XPath("/html/body/div/main/section[2]/div/div/div[2]/div/div[1]/h4")).Execute().As("@save");
        //check if obj was infact stored in context
        var context = snSel.GetContext();
       Assert.NotNull(context.GetValue("@save"));
    }
    
    
    
}