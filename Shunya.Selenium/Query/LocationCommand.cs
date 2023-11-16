// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/2:02 pm

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class LocationCommand
{
    /// <summary>
    /// Get current browser url
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<string> Location<T>(this IChainable<T> chain)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        ActionTaskResult<string> actionResult = new ActionTaskResult<string>(ref chain.GetContext(),webdriver.Url);
        return actionResult;
    }
}