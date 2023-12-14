// Author:- raj
// Created At:- 02/11/2023/4:37 pm

using System.Diagnostics;
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
    public static IRunnable<bool> Visit<T>(this IChainable<T> chain,string url)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        try
        {
            Action<VisitCommandInput> action=NavigateToUrl;
            //action("Raj",webdriver);
            ActionTask<VisitCommandInput> task =
                new ActionTask<VisitCommandInput>(action, new VisitCommandInput(url, webdriver), ref context);

            return task;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static void NavigateToUrl(VisitCommandInput input)
    {
        input.webDriver.Navigate().GoToUrl(input.url);
    }
}

public class VisitCommandInput
{
    public string url { get; set; }
    public WebDriver webDriver { get; set; }

    public VisitCommandInput(string url, WebDriver webDriver)
    {
        this.url = url;
        this.webDriver = webDriver;
    }
}