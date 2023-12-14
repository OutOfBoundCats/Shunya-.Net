// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/3:51 pm

using System.Text;
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
    public static IChainable<T> Request<T>(this IChainable<T> chain,string url,HttpOptions options,String? body)
    {
        var httpClient=new HttpClient();
        //httpClient.BaseAddress=new Uri(url);
        
        //process query params
        Uri newUrl=new Uri(url);
        if (options._queryParameters != null)
        {
            newUrl=new Uri(QueryStringBuilder.GetUriWithQueryString("https://localhost:12345/movies/search", options._queryParameters));
        }
        // add headers to request
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, newUrl);
        foreach (var header in options._httpHeaders)
        {
            requestMessage.Headers.Add(header.Key,header.Value);
        }
        //attach body to the request
        requestMessage.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}", Encoding.UTF8, "application/json");;

        var response=httpClient.Send(requestMessage);
        
        throw new NotImplementedException();
    }
}

public class HttpOptions
{
    public HttpOptions(HttpMethod? method, Dictionary<string, string>? httpHeaders, Dictionary<string, string>? queryParameters)
    {
        _method = method;
        _httpHeaders = httpHeaders;
        _queryParameters = queryParameters;
    }

    public Constants.RestApiTypes _apiType { get; set; }
    public HttpMethod? _method { get; set; }
    public Dictionary<string,string> _httpHeaders { get; set; }
    public Dictionary<string,string>? _queryParameters { get; set; }
    
    
}


public class HttpBody
{
    public FormUrlEncodedContent _urlEncodedForm { get; set; }
    //public 
}