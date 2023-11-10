// Author:- raj
// Created At:- 06/11/2023/3:07 pm

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class ChildrenCommand
{
    /// <summary>
    /// Works on IChainable's Result and finds all its children <br/>
    /// Throws error if Result does not contain WebElement or Result itself throws error
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="alias"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IChainable<ReadOnlyCollection<IWebElement>> Children(this IChainable<IWebElement> chain,string alias)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        var webElement = chain.GetResult();
        try
        {
            var childrens=webElement.FindElements(By.XPath("*"));
            ActionTaskResult<ReadOnlyCollection<IWebElement>> actionResult = new ActionTaskResult<ReadOnlyCollection<IWebElement>>(ref context,childrens);
            return actionResult;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}