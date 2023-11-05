// Author:- raj
// Created At:- 01/11/2023/3:30 pm

namespace Shunya.Selenium;

public class SnException:Exception
{
   
    public SnException(SnError error, string? additonalMsg = null)
    {
        Message = error.Message + " || " + additonalMsg;
        Code = error.Code;
        Title = error.Title;
    }
    public string Message { get; set; }
    public int Code { get; set; }
    public string Title { get; set; }
}

public class SnError
{
    public SnError(string title, string message, int code)
    {
        Title = title;
        Message = message;
        Code = code;
    }

    public string Title { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
}

public static class ErrorCodes
{
    public static SnError ElementNotFound = new SnError("The element not found", "The html element is not present in webpage requested", 1);
    public static SnError NavigationFailed = new SnError("Navigation Failed", "Failed to navigate to requested URL", 2);
    public static SnError ObjNotFoundContext = new SnError("Object Not Found", "Specified object not found in context", 3);
    public static SnError NameNotPermited = new SnError("Name Prohibited", "The Name provided starts with Sn which is prohibited :- ", 4);
    public static SnError ErrorSettingContext = new SnError("Error Settign Context", "Failed to set context :- ", 5);
    public static SnError UnSupportedBrowser = new SnError("Unsupported Browser", "UnSupported Browser :- ", 6);
    public static SnError TaskNoSuccessful = new SnError("Task not successful", "The given task did not execute successfully :- ", 7);
}