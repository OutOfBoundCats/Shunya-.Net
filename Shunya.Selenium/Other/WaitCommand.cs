// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 22/11/2023/5:02 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Other;

public static class WaitCommand
{
    /// <summary>
    /// Wait for provided miliseconds before continuing execution
    /// </summary>
    /// <param name="milliseconds">Number of milliseconds to wait</param>
    /// <returns></returns>
    public static IChainable<T> Wait<T>(this IChainable<T> chain, int milliseconds)
    {
        WebDriver webdriver = chain.GetDriver();
        ILogger l = chain.GetLogger();
        l.LogInformation("Wait execution.Waiting for " + milliseconds +"ms");
        Thread.Sleep(milliseconds);
        l.LogInformation("Wait execution After " + milliseconds + "ms");
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(), chain.GetResult());
        return actionResult;
    }
}