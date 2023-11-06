// Author:- raj
// Created At:- 06/11/2023/5:35 pm

namespace Shunya.Selenium.Query;

public class GetCommand
{
    /// <summary>
    /// Saves result of current operation with alias in context
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="alias"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IChainable<bool> As(this IChainable<Exception> chain,string alias)
    {
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();
        if (alias.Substring(0, 1) != "@")
        {
            throw new SnException(ErrorCodes.InvalidAliasName, alias);
        }
        try
        {
            context.Add(alias, chain.GetResult());
            ActionTaskResult<bool> actionResult = new ActionTaskResult<bool>(ref context,true);
            return actionResult;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}