// Author:- raj
// Created At:- 07/11/2023/5:06 pm

using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Actions;

public static class ClickAction
{
    /// <summary>
    /// Click on the webelement
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="alias"></param>
    /// <returns></returns>
    public static IChainable<bool> Click(this IChainable<IWebElement> chain)
    {
        SnContext context = chain.GetContext();
        var webElement=chain.GetResult();
        
        webElement.Click();
        ActionTaskResult<bool> actionResult = new ActionTaskResult<bool>(ref context,true);
        return actionResult;
    }
}