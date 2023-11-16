// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/1:41 pm

using System.Collections.ObjectModel;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class FirstCommand
{
    /// <summary>
    /// Returns first element from read only collection
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<T> First<T>(this IChainable<ReadOnlyCollection<T>> chain)
    {
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(),chain.GetResult().ElementAt(0));
        return actionResult;
    }
}