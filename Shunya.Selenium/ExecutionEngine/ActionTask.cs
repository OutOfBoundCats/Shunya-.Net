// Author:- raj
// Created At:- 03/11/2023/6:08 pm

using Microsoft.Extensions.Logging;

namespace Shunya.Selenium.ExecutionEngine;

/// <summary>
/// This class obj is returned from command to be executed by executor with execution options<br/>
/// This always contain result as bool indidcating success or failure of action
/// </summary>
/// <typeparam name="TActionInput">TYpe of Input the action expects</typeparam>
public class ActionTask<TActionInput>:IRunnable<bool>
{
    private Action<TActionInput> action;
    private TActionInput input;
    private SnContext context;

    public ActionTask(Action<TActionInput> action , TActionInput input,ref SnContext context )
    {
        this.action = action;
        this.input = input;
        this.context = context;
    }
    
    
    /// <summary>
    /// Execute the action with option
    /// </summary>
    /// <param name="intervalInMilliseconds">Time to stop between attempts</param>
    /// <param name="maxAttempts">No of attempts</param>
    /// <returns >IExecutorResult</returns>
    /// <exception cref="SnException">Throws task not completed exception</exception>
    public IExecutorResult<bool> Execute(int intervalInMilliseconds=0, int maxAttempts=1)
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
                     ActionTaskResult<bool> actionResult = new ActionTaskResult<bool>(ref this.context,true);
                     return actionResult;
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

                         throw new SnException(ErrorCodes.TaskNoSuccessful);
                     }
                 }
             }
             throw new SnException(ErrorCodes.TaskNoSuccessful);
    }

   
}