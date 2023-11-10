// Author:- raj
// Created At:- 10/11/2023/1:14 pm

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class EqCommand
{
    /// <summary>
    /// Get A DOM element at a specific index in an array of elements.
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static IChainable<IWebElement> Eq(this IChainable<ReadOnlyCollection<IWebElement>> chain,int index)
    {
        var a = chain.GetResult();
        int finalIndex = 0;
        if (index >= 0)
        {
            finalIndex = index;
        }else if (index < 0)
        {
            finalIndex=a.Count+index;
        } 
        ActionTaskResult<IWebElement> actionResult = new ActionTaskResult<IWebElement>(ref chain.GetContext(),a[finalIndex]);
        return actionResult;
    }
}