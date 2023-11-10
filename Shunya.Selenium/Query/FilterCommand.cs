// Author:- raj
// Created At:- 10/11/2023/2:51 pm

using System.Collections.ObjectModel;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class FilterCommand
{
    /// <summary>
    /// Filter DOM elements that match a specific condition.
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<List<T>> Filter<T>(this IChainable<ReadOnlyCollection<T>> chain,Func<T,bool> func)
    {
        List<T> filteredList = new List<T>();
        foreach (var item in chain.GetResult())
        {
            if (func(item))
            {
                filteredList.Add(item);
            }
        }
        ActionTaskResult<List<T>> actionResult = new ActionTaskResult<List<T>>(ref chain.GetContext(),filteredList);
        return actionResult;
    }
}