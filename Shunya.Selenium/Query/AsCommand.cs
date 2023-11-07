// Author:- raj
// Created At:- 06/11/2023/2:36 pm

using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;
using Shunya.Selenium.Other;

namespace Shunya.Selenium.Query;

/// <summary>
/// Cannonical to https://docs.cypress.io/api/commands/as
/// </summary>
public static class AsCommand
{
    /// <summary>
    /// Saves result of current operation with alias in context
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="alias"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IChainable<bool> As<T>(this IChainable<T> chain,string alias)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        if (alias.Substring(0, 1) != "@")
        {
            throw new SnException(ErrorCodes.InvalidAliasName, alias);
        }
        try
        {
            context.Add(alias, chain.GetResult());
            ActionTaskResult<bool> actionResult = new ActionTaskResult<bool>(ref context,true);
            return actionResult;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

}