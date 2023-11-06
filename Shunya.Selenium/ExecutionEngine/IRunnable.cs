// Author:- raj
// Created At:- 03/11/2023/5:59 pm

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// All tasks that needs to use execution interface needs to implement this interface <br/>
/// </summary>
public interface IRunnable<TResult>
{
    public IChainable<TResult> Execute(int intervalInMilliseconds=0, int maxAttempts=1);
    
}