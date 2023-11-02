// Author:- raj
// Created At:- 02/11/2023/4:37 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Shunya.Selenium.Selenium;

namespace Shunya.Selenium.Other;

public static class VisitCommand
{
    /// <summary>
    /// Navigate to given url
    /// </summary>
    /// <param name="snSelenium"></param>
    /// <param name="url"></param>
    /// <exception cref="Exception"></exception>
    public static SnSelenium Visit(this SnSelenium snSelenium,string url)
    {
        SnContext context = snSelenium._context;
        WebDriver webdriver = snSelenium._webDriver;
        try
        {
            Action action=NavigateToUrl;
            context.SetKey("SnAction", action);
            context.SetKey("SnFunctionData", url);
            context.SetKey("SnExecutionType", "Action");
            return snSelenium;
        }
        catch (Exception e)
        {
            snSelenium._logger.LogError("Failed to navigate to " + url);
            throw e;
        }

        void NavigateToUrl()
        {
            webdriver.Navigate().GoToUrl(url);
        }
    }
}