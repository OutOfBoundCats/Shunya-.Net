// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/2:26 pm

using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Other;

public static class PauseCommand
{
    /// <summary>
    /// Pauses execution untill input is provided 
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<T> Pause<T>(this IChainable<T> chain)
    {
        bool stop = false;
        ILogger l = chain.GetLogger();
        Console.WriteLine("Paused execution.Waiting for any keyboard input");
        l.LogInformation("Paused execution.Waiting for any keyboard input");
        //string a = Console.ReadLine();
        //detect os and open terminal or cmd 
        string programName;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            // Do something
            programName="/bin/bash";
        }else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            programName="cmd.exe";
        }
        else
        {
            throw new SnException(ErrorCodes.OsNotSupported);
        }
        
        ProcessStartInfo pro = new ProcessStartInfo();
        //Setting the FileName to be Started like in our
        //Project we are just going to start a CMD Window.
        pro.FileName = programName;
        pro.RedirectStandardInput = true;
        pro.RedirectStandardOutput = true;
        pro.UseShellExecute = false;
        
        Process proStart = new Process();
        proStart.StartInfo = pro;
        proStart.Start ();

        StreamWriter streamWriter = proStart.StandardInput;
        String inputText="";
        int numLines = 0;
        do
        {
            inputText = "raj";
            Thread.Sleep(10000);
            //inputText=streamWriter.
        } while (inputText.Length == 0);
        
        
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(),chain.GetResult());
        return actionResult;
    }
}