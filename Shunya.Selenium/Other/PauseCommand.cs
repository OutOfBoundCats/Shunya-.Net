// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/2:26 pm

using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Other;

public static class PauseCommand
{

    /// <summary>
    /// Pauses execution indefinitely pause browser window is closed. </br>
    /// Only For debugging purpose
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="skip"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<T> Pause<T>(this IChainable<T> chain,bool skip=false)
    {
        bool stop = false;
        ILogger l = chain.GetLogger();
        var driver = chain.GetDriver();
        l.LogInformation("Paused execution.Waiting for window close");
        string originalWindow = driver.CurrentWindowHandle;
        driver.SwitchTo().NewWindow(WindowType.Window);
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("document.body.innerHTML='<div>Execution is paused.Please close this window to continue execution.</div>'");
        string pauseWindow = driver.CurrentWindowHandle;
        bool isClosed = false;
        while (!isClosed)
        {
            var a =driver.WindowHandles.Where(x => x == pauseWindow);
            if (a.Count() == 0)
            {
                isClosed = true;
            }
        }
        driver.SwitchTo().Window(originalWindow);
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(),chain.GetResult());
        return actionResult;
    }
}