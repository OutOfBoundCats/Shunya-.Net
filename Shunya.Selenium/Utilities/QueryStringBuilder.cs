// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 23/11/2023/3:39 pm

using System.Text;

namespace Shunya.Selenium;

public class QueryStringBuilder
{
    public static string GetUriWithQueryString(string requestUri, 
        Dictionary<string, string>? queryStringParams)
    {
        bool startingQuestionMarkAdded = false;
        var sb = new StringBuilder();
        sb.Append(requestUri);
        foreach (var parameter in queryStringParams)
        {
            if (parameter.Value == null)
            {
                continue;
            }

            sb.Append(startingQuestionMarkAdded ? '&' : '?');
            sb.Append(parameter.Key);
            sb.Append('=');
            sb.Append(parameter.Value);
            startingQuestionMarkAdded = true;
        }
        return sb.ToString();
    }
}