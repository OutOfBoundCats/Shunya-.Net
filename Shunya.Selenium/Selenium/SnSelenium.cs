// Author:- raj
// Created At:- 02/11/2023/4:05 pm

using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Shunya.Selenium.Selenium;

public class SnSelenium
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
        _context.SetKey("SnWebDriver",  _webDriver);
        _context.SetKey("SnLogger", _logger);
    }
}