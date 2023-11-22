// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 22/11/2023/5:07 pm

using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Assertions;

public static class AndAssertion
{
    /// <summary>
    /// Perform assertion on result
    /// </summary>
    /// <param name="func">Function against which result will be checked</param>
    /// <returns></returns>
    public static IChainable<bool> AndAssert(this IChainable<IWebElement> chain, Func<IWebElement , bool> func)
    {
        IWebElement ele = chain.GetResult();
        ActionTaskResult<bool> actionResult = new ActionTaskResult<bool>(ref chain.GetContext(), func(ele));
        return actionResult;
    }
}