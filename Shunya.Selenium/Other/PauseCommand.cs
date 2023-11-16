// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/2:26 pm

using Microsoft.Extensions.Logging;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Other;

public static class PauseCommand
{
    /// <summary>
    /// Pauses execution untill input is provided 
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<T> Pause<T>(this IChainable<T> chain)
    {
        bool stop = false;
        ILogger l = chain.GetLogger();
        Console.WriteLine("Paused execution.Waiting for any keyboard input");
        l.LogInformation("Paused execution.Waiting for any keyboard input");
        string a = Console.ReadLine();
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(),chain.GetResult());
        return actionResult;
    }
}