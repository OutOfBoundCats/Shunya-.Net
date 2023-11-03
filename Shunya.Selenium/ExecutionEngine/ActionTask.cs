// Author:- raj
// Created At:- 03/11/2023/6:08 pm

using Microsoft.Extensions.Logging;

namespace Shunya.Selenium.ExecutionEngine;

public class ActionTask<ActionInput>:IRunnable
{
    private Action<ActionInput> action;
    private ActionInput input;
    private SnContext context;

    public ActionTask(Action<ActionInput> action , ActionInput input,ref SnContext context )
    {
        this.action = action;
        this.input = input;
        this.context = context;
    }
    
    /// <summary>
    /// Execute the action with option
    /// </summary>
    /// <param name="intervalInMilliseconds"></param>
    /// <param name="maxAttempts"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IExecutorResult Execute(int? intervalInMilliseconds=0, int? maxAttempts=1)
    {
             
             ILogger logger = context.GetValue("SnLogger");

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
                     action(input);
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
             throw new NotImplementedException();
    }

   
}