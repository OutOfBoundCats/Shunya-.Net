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
    
    [Test]
    public void EqTestFirstElement()
    {
        var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Eq(0);
        string firstElementText =
            "URL Encoder/Decoder is a simple online tool that does exactly what it says, it helps decode from URL encoding as well as encodes to URL quickly, securely and easily. URL Encoder/Decoder encode/decodes your data without hassles or decode it into a human-readable format";
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";
        Assert.AreEqual(firstElementText,foundElement.GetResult().Text);
        Assert.AreEqual(firstElementText,foundElement.GetResult().Text);
    }
    
    [Test]
    public void EqTestLastElement()
    {
        var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Eq(-1);
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";
        Assert.AreEqual(lastElemment,foundElement.GetResult().Text);
    }
    
    [Test]
    public void FilterTest()
    {
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";
        var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Filter(el=>el.Text==lastElemment).GetResult();
        Assert.AreEqual(lastElemment,foundElement.ElementAt(0).Text);
    }
    
    [Test]
    public void FindTest()
    {
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";
        var foundElement = snSel.Visit("https://hasare.com/").Execute()
            .GetOne(By.XPath("//*[@id=\"products\"]/div/dl")).Execute().Find("div").GetResult();
        Assert.AreEqual(5,foundElement.Count);
    }
    
    [Test]
    public void FirstTest()
    {
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";
        var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Filter(el=>el.Text==lastElemment).First().GetResult();
        Assert.AreEqual(lastElemment,foundElement.Text);
    }
    
    [Test]
    public void LastTest()
    {
        string lastElemment = "Your Ultimate Text Comparison Tool. Easily compare and analyze differences between two texts with precision and speed. Whether you're a writer, editor, programmer, or student, TextDiffCheck empowers you to identify changes, revisions, and variations effortlessly. Enhance your productivity and accuracy.";
        var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Last().GetResult();
        Assert.AreEqual(lastElemment,foundElement.Text);
    }

    [Test]
    public void LocationTest()
    {
        var result=snSel.Visit("https://hasare.com/").Execute().Location().GetResult();
        Assert.AreEqual("https://hasare.com/",result);
    }
    
}