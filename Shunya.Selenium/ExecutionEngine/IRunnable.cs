// Author:- raj
// Created At:- 03/11/2023/5:59 pm

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// All tasks that needs to use execution interface needs to implement this interface <br/>
/// </summary>
public interface IRunnable
{
    public IExecutorResult Execute(int? intervalInMilliseconds, int? maxAttempts);
    
}