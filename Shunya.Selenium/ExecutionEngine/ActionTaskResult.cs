// Author:- raj
// Created At:- 04/11/2023/6:19 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Shunya.Selenium.ExecutionEngine;

public class ActionTaskResult<TResult>:IChainable<TResult>
{
    private SnContext context;
    private TResult result;


    public ActionTaskResult(ref SnContext context, TResult result)
    {
        this.context = context;
        this.result = result;
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

    public TResult GetResult()
    {
        return this.result;
    }

    public WebDriver GetDriver()
    {
        WebDriver lg = this.context.GetValue(Constants.snWebDriver);
        return lg;
    }
}