// Author:- raj
// Created At:- 06/11/2023/5:35 pm

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Query;

public static class GetCommand
{
   /// <summary>
   /// Get one or more elements by provided search details
   /// </summary>
   /// <param name="chain"></param>
   /// <param name="searchDetails"></param>
   /// <returns></returns>
    public static IRunnable<ReadOnlyCollection<IWebElement>> Get<T>(this IChainable<T> chain, By searchDetails)
    {
        var context = chain.GetContext();
        var webdriver = chain.GetDriver();
        Func<By, ReadOnlyCollection<IWebElement>> foundElements = webdriver.FindElements;
        var functionTask =
            new FunctionTaskOne<ReadOnlyCollection<IWebElement>, By>(foundElements, searchDetails, context);
        return functionTask;
    }
   /// <summary>
   /// Get one  element by provided search details
   /// </summary>
   /// <param name="chain"></param>
   /// <param name="searchDetails"></param>
   /// <returns></returns>
   public static IRunnable<IWebElement> GetOne<T>(this IChainable<T> chain, By searchDetails)
   {
       var context = chain.GetContext();
       var webdriver = chain.GetDriver();
       Func<By, IWebElement> foundElements = webdriver.FindElement;
       var functionTask =
           new FunctionTaskOne<IWebElement, By>(foundElements, searchDetails, context);
       return functionTask;
   }
}