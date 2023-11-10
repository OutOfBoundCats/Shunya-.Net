// Author:- raj
// Created At:- 09/11/2023/4:27 pm

using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class ClosestCommand
{
    private static ILogger logger;
    /// <summary>
    /// Gets the closest element satisfying the options <br/>
    /// Throws error if it reaches body tag without finding element.
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="searchText"></param>
    /// <returns>IRunnable&lt;IWebElement&gt;</returns>
    public static IRunnable<IWebElement> Closest(this IChainable<IWebElement> chain,string searchText)
    {
        IWebElement result = chain.GetResult();
        logger = chain.GetLogger();
        var context = chain.GetContext();
        var findClosest = GetClosest;
        var functionTask =
            new FunctionTaskOne<IWebElement, ClosestInput>(findClosest, new ClosestInput(result,searchText),ref context);
        return functionTask;
    }

    public static IWebElement GetClosest(ClosestInput input)
    {
        bool found = false;
        while (!found)
        {
            IWebElement parentElement = input.webElement.FindElement(By.XPath("./.."));
            logger.LogInformation("Prent element tag is "+parentElement.TagName);
            if (parentElement.TagName == "body")
            {
                break;
            }
            if (input.searchText.Substring(0, 1) == ".")
            {
                //search by class
                var elementClassName=parentElement.GetAttribute("class");
                if (elementClassName == input.searchText)
                {
                    return parentElement;
                }
            }
            else
            {
                //search by html tag
                string tagName = parentElement.TagName;
                if (tagName == input.searchText)
                {
                    return parentElement;
                }
            }
        }
        //if we havent found the closest satisfying condition till now throw an error
        throw new SnException(ErrorCodes.ElementNotFound);
    }
}

public class ClosestInput
{
    public IWebElement webElement;
    public string searchText;

    public ClosestInput(IWebElement webElement, string searchText)
    {
        this.webElement = webElement;
        this.searchText = searchText;
    }
}