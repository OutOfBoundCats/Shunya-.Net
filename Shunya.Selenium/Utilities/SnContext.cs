// Author:- raj
// Created At:- 01/11/2023/3:30 pm

namespace Shunya.Selenium;

/// <summary>
/// It stores execution context
/// </summary>
public  class SnContext
{
     Dictionary<string, object> hash = new Dictionary<string, object>();

     /// <summary>
     /// Store Object in context
     /// </summary>
     /// <param name="objectName"></param>
     /// <returns></returns>
     /// <exception cref="SnException"></exception>
     public object GetValue(string objectName)
     {
         try
         {
             object obj = hash[objectName];
             return obj;
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             throw new SnException(ErrorCodes.ObjNotFoundContext,objectName);
         }
     }
    
}