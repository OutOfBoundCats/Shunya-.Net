// Author:- raj
// Created At:- 03/11/2023/6:09 pm

using Microsoft.Extensions.Logging;

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// Function task which takes input as one argument
/// </summary>
public class FunctionTaskOne<TResult, TFunctionInput> : IRunnable<TResult>
{
    private Func<TFunctionInput, TResult> _function;
    private TFunctionInput functionInput;
    private SnContext context;

    public FunctionTaskOne(Func<TFunctionInput, TResult> function, TFunctionInput functionInput, SnContext context)
    {
        _function = function;
        this.functionInput = functionInput;
        this.context = context;
    }

    public IChainable<TResult> Execute(int intervalInMilliseconds = 0, int maxAttempts = 1)
    {
        ILogger logger = context.GetValue(Constants.snLoggerr);

        if (maxAttempts < 1)
        {
            maxAttempts = 1;
            logger.LogError("Less than 1 attempt specified the function will run 1 time");
        }

        var success = false;
        var attempts = 0;
        while (!success && attempts < maxAttempts)
        {
            attempts++;
            try
            {
                var resullt = _function(functionInput);
                success = true;
                //put result along with context in some class obj that implemnts IExecutorResult and return
            }
            catch (Exception e)
            {
                var errMsg = string.Format("Retry attempt {0} experienced the following exception: {1} | ", attempts,
                    e.Message);
                logger.LogError(errMsg);
                if (attempts >= maxAttempts)
                {
                    errMsg += string.Format(
                        "{0} Maximum retry count of {1} with an interval of {2} milliseconds was met. {3}", maxAttempts,
                        intervalInMilliseconds, e.Message);

                    logger.LogError(errMsg);

                    throw new Exception(errMsg);
                }

                
            }
        }

        throw new NotImplementedException();
    }
}