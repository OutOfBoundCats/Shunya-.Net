namespace Shunya.Selenium;

public class SnException:Exception
{
    public SnException(string message, int code, string title)
    {
        Message = message;
        Code = code;
        Title = title;
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

public class ErrorCodes
{
    public static SnError ElementNotFound = new SnError("The element not found", "The html element is not present in webpage requested", 1);
    public static SnError NavigationFailed = new SnError("Navigation Failed", "Failed to navigate to requested URL", 2);
}