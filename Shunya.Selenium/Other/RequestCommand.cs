// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/3:51 pm

using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Other;

public static class RequestCommand
{
    /// <summary>
    /// make request to url
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IChainable<T> Request<T>(this IChainable<T> chain,string url,HttpMethod method)
    {
        throw new NotImplementedException();
    }
}

public class HttpOptions
{
    
}