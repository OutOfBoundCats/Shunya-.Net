// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/1:53 pm

using System.Collections.ObjectModel;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class LastCommand
{
    /// <summary>
    /// Returns last element from read only collection
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<T> Last<T>(this IChainable<ReadOnlyCollection<T>> chain)
    {
        var result = chain.GetResult();
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(),result.ElementAt(result.Count()-1));
        return actionResult;
    }
}