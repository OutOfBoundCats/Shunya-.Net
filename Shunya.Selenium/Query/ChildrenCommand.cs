// Author:- raj
// Created At:- 06/11/2023/3:07 pm

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
    public static IChainable<bool> Children(this IChainable<IWebElement> chain,string alias)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        var webElement = chain.GetResult();
        try
        {
            var childrens=webElement.FindElements(By.XPath("*"));
            ActionTaskResult<bool> actionResult = new ActionTaskResult<bool>(ref context,true);
            return actionResult;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}