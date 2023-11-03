// Author:- raj
// Created At:- 03/11/2023/4:59 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// All things on which the command is worked on should implement this interface<br/>
/// </summary>
public interface IChainable<Result>
{
    public Result GetResult();
    public WebDriver GetDriver();
    public ILogger GetLogger();
    public SnContext GetContext();
}