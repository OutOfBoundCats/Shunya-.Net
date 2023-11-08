// Author:- raj
// Created At:- 02/11/2023/4:05 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Selenium;

public class SnSelenium:IChainable<Exception>
{
    
    public SnContext _context;
    public ILogger _logger;
    public WebDriver _webDriver;
  


    /// <summary>
    /// Initialise Shunya Selenium 
    /// </summary>
    /// <param name="browser">Browser for selenium</param>
    /// <param name="logger">Optional logger for logging</param>
    /// <exception cref="SnException"></exception>
    public SnSelenium(Constants.SupportedBrowsers browser, ILogger? logger)
    {
       
        switch (browser)
        {
            case Constants.SupportedBrowsers.CHROME:
                _webDriver = new ChromeDriver();
                break;
            case Constants.SupportedBrowsers.FIREFOX:
                _webDriver = new FirefoxDriver();
                break;
            case Constants.SupportedBrowsers.IE:
                _webDriver = new InternetExplorerDriver();
                break;
            default:
                throw new SnException(ErrorCodes.UnSupportedBrowser);
        }

        _logger = logger;
        _context = new SnContext(_logger);
        _context.Add(Constants.snWebDriver,  _webDriver);
    }

    /// <summary>
    /// DO NOT USE
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Exception IChainable<Exception>.GetResult()
    {
        throw new Exception("Not valid on instance of SnSelenium");
    }

    /// <summary>
    /// Get instance of webdriver stored in context
    /// </summary>
    /// <returns></returns>
    public WebDriver GetDriver()
    {
        var driver=_context.GetValue(Constants.snWebDriver);
        return driver;
    }

    /// <summary>
    /// Get instance of ILogger stored in context
    /// </summary>
    /// <returns></returns>
    public ILogger GetLogger()
    {
        var driver=_context.GetValue(Constants.snLoggerr);
        return driver;
    }

    public ref SnContext GetContext()
    {
        return ref _context;
    }

    public void Close()
    {
        WebDriver driver=_context.GetValue(Constants.snWebDriver);
        driver.Quit();
    }
}