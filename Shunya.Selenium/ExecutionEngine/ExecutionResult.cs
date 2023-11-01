// Author:- raj
// Created At:- 01/11/2023/3:44 pm

using OpenQA.Selenium;

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// Execution Engine returns this after execution of delegate.
/// Has filed  Result to get direct access to execution result
/// </summary>
/// <typeparam name="Out"></typeparam>
public class ExecutionResult<Out>
{
    public SnContext context { get; set; }
    public Out Result { get; set; }
}