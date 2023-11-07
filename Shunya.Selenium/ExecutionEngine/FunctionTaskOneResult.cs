// Author:- raj
// Created At:- 07/11/2023/2:12 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// Class for output of function delegate taking in one input parameter
/// </summary>
public class FunctionTaskOneResult<TResult>:IChainable<TResult>
{
    private SnContext context;
    private TResult result;

    public FunctionTaskOneResult(ref SnContext context, TResult result)
    {
        this.context = context;
        this.result = result;
    }

    public TResult GetResult()
    {
        return this.result;
    }

    public WebDriver GetDriver()
    {
        WebDriver lg = this.context.GetValue(Constants.snWebDriver);
        return lg;
    }

    public ILogger GetLogger()
    {
        ILogger lg = this.context.GetValue(Constants.snLoggerr);
        return lg;
    }

    public SnContext GetContext()
    {
        return this.context;
    }
}