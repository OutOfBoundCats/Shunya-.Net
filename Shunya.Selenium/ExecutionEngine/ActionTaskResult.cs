// Author:- raj
// Created At:- 04/11/2023/6:19 pm

namespace Shunya.Selenium.ExecutionEngine;

public class ActionTaskResult<TResult>:IExecutorResult<TResult>
{
    private SnContext context;
    private TResult result;


    public ActionTaskResult(ref SnContext context, TResult result)
    {
        this.context = context;
        this.result = result;
    }

    public SnContext GetContext()
    {
        return this.context;
    }

    public TResult GetResult()
    {
        return this.result;
    }
}