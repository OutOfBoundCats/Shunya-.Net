// Author:- raj
// Created At:- 09/11/2023/4:07 pm

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class ContainsCommand
{
    /// <summary>
    /// Returns IRunnable which return all web elements which contain text.
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="text"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IRunnable<ReadOnlyCollection<IWebElement>> Contains<T>(this IChainable<T> chain,string text)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();

        var searchXPath = By.XPath("//*[text()='" + text + "']");
        Func< By, ReadOnlyCollection< IWebElement>> foundElements= webdriver.FindElements;
        var functionTask =
            new FunctionTaskOne<ReadOnlyCollection<IWebElement>, By>(foundElements, searchXPath, ref context);
        return functionTask;
    }
}