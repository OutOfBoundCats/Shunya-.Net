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
    public static IChainable<T> Request<T>(this IChainable<T> chain,string url,HttpOptions options)
    {
        var httpClient=new HttpClient();
        throw new NotImplementedException();
    }
}

public class HttpOptions
{
    public HttpOptions(HttpMethod? method, Dictionary<string, string>? httpHeaders, Dictionary<string, string>? queryStrings)
    {
        _method = method;
        _httpHeaders = httpHeaders;
        _queryStrings = queryStrings;
    }

    public Constants.RestApiTypes _apiType { get; set; }
    public HttpMethod? _method { get; set; }
    public Dictionary<string,string>? _httpHeaders { get; set; }
    public Dictionary<string,string>? _queryStrings { get; set; }
    
    
}