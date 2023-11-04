// Author:- raj
// Created At:- 04/11/2023/8:36 pm

using Microsoft.Extensions.Logging;
using Shunya.Selenium;
using Shunya.Selenium.Other;
using Shunya.Selenium.Selenium;

namespace Shunya.SeleniumTests;

public class VisitCmdTest
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {

        SnSelenium sn = new SnSelenium(Constants.SupportedBrowsers.CHROME,null);
        sn.Visit("loggernow.com");
        
        Assert.Pass();
    }
}