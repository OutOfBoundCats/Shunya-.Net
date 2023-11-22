// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 22/11/2023/5:09 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Serilog;
using Serilog.Extensions.Logging;
using Shunya.Selenium;
using Shunya.Selenium.Assertions;
using Shunya.Selenium.Other;
using Shunya.Selenium.Query;
using Shunya.Selenium.Selenium;

namespace Shunya.SeleniumTests;

public class AssertionsTest
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
    public void AndAssertTest()
    {
        string firstElementText =
            "URL Encoder/Decoder is a simple online tool that does exactly what it says, it helps decode from URL encoding as well as encodes to URL quickly, securely and easily. URL Encoder/Decoder encode/decodes your data without hassles or decode it into a human-readable format";
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";

        var Result = snSel.Visit("https://hasare.com/").Execute()
            .GetOne(By.XPath("//*[@id=\\\"products\\\"]/div/dl/div[*]/dd")).Execute()
            .AndAssert(x => x.Text == firstElementText).GetResult();
        logger.LogInformation("Result Value :: "+ Result);
        Assert.AreEqual(true, Result);
            
            
    }
    
}