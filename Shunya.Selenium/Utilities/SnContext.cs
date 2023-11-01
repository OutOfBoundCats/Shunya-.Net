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
         if (objectName.Substring(0, 1) == "Sn")
         {
              throw new SnException(ErrorCodes.NameNotPermited,objectName);
         }

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

     public void SetAction(Action action)
     {
         try
         {
             hash.Add("SnAction",action);
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
             throw;
         }
     }

}