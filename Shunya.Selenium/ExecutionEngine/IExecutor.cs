// Author:- raj
// Created At:- 01/11/2023/3:30 pm

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// Interface for Execution engine to execute delegates according to the options specified
/// </summary>
/// <typeparam name="Out"></typeparam>
public interface IExecutor<Out>
{
    ExecutionResult<Out> Execute();
}