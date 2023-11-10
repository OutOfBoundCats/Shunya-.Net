// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 10/11/2023/3:34 pm

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class FindCommand
{
    /// <summary>
    /// Get the descendent DOM elements of a specific selector. <br/>
    /// Only allows search by classname and tagname and xpaths
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="searchText"></param>
    /// <returns></returns>
    public static IChainable<ReadOnlyCollection<IWebElement>> Find(IChainable<IWebElement> chain, string searchText)
    {
        IWebElement webElement = chain.GetResult();
        SnContext context = chain.GetContext();
        WebDriver webdriver = chain.GetDriver();

        ReadOnlyCollection<IWebElement> result;
        var childrens = webElement.FindElements(By.XPath("*"));
        if (searchText.Substring(0, 1) == ".")
        {
            //search by class
            result = childrens.Filter(el => el.GetAttribute("class") == searchText);
        }
        else if (searchText.Substring(0, 1) == "x")
        {
            //search by xpaths
            result = webElement.FindElements(By.XPath(searchText));
        }
        else
        {
            //search by html tag
            result = childrens.Filter(el => el.TagName == searchText);
        }

        ActionTaskResult<ReadOnlyCollection<IWebElement>> actionResult =
            new ActionTaskResult<ReadOnlyCollection<IWebElement>>(ref context, result);
        return actionResult;
    }
}