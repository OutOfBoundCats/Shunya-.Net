// Author:- raj
// Created At:- 01/11/2023/3:30 pm

using Microsoft.Extensions.Logging;

namespace Shunya.Selenium;

/// <summary>
/// It stores execution context
/// </summary>
public  class SnContext
{
    public Dictionary<string, object> hash;

     private ILogger? _logger;

     public SnContext(ILogger? logger)
     {
         _logger = logger;
     }

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
             _logger.LogError(ErrorCodes.NameNotPermited.Message);
              throw new SnException(ErrorCodes.NameNotPermited,objectName);
         }

         try
         {
             object obj = hash[objectName];
             return obj;
         }
         catch (Exception e)
         {
             _logger.LogError(ErrorCodes.ObjNotFoundContext.Message);
             throw new SnException(ErrorCodes.ObjNotFoundContext,objectName);
         }
     }

     public bool SetKey(string keyName, object keyValue)
     {
         try
         {
             hash[keyName] = keyValue;
         }
         catch (Exception e)
         {
             _logger.LogError("Error setting context for "+keyName);
             throw new SnException(ErrorCodes.ErrorSettingContext,keyName);
         }
         return true;
     }

     /// <summary>
     /// Set action to be executed by execution engine
     /// </summary>
     /// <param name="action"></param>
     public void SetAction(Action action)
     {
         try
         {
             hash.Add("SnAction",action);
         }
         catch (Exception e)
         {
             _logger.LogError("Error setting action for "+e.Message);
             throw e;
         }
     }

}