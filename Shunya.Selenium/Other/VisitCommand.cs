// Author:- raj
// Created At:- 02/11/2023/4:37 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;
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
    public static IRunnable Visit(this IChainable<Exception> chain,string url)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        try
        {
            Action action=NavigateToUrl;
            context.Add("SnAction", action);
            context.Add("SnFunctionData", url);
            context.Add("SnExecutionType", "Action");
            
        }
        catch (Exception e)
        {
            
            throw e;
        }

        void NavigateToUrl()
        {
            webdriver.Navigate().GoToUrl(url);
        }

        throw new NotImplementedException();
    }
}