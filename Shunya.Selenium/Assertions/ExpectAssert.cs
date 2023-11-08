// Author:- raj
// Created At:- 07/11/2023/5:07 pm

using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Assertions;

public static class ExpectAssert
{
    /// <summary>
    /// This works on webelement and takes in func delegate and cheks if webelement satisfy the func
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="func"></param>
    /// <typeparam name="T"></typeparam>
    public static void Expect<T>(this IChainable<IWebElement> chain, Func<T> func)
    {
        
    }
    
}