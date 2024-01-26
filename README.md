# This Project is an attempt to wrap selenium to expose Api which is somewhere inbetween C# LINQ and Cypress

## Shunya commands can be classified one of the following

- query - commands that read the state of your application
- assertion - command which assert on a given state
- action - interact with your application as a user would
- other - any other command that is useful for writing tests


## Instalation

```
dotnet add package Shunya.Selenium --version 0.1.0
```

## The basic execution flow is shown below

![image description](https://raw.githubusercontent.com/OutOfBoundCats/Shunya-.Net/master/Documentation/Images/ExecutionFlow.png)

We first start by creating Instance of `IChainable` i.e. `SnSelenium` by passing Type of browser and Instance of ILogger.<br/>
This also created context which is then passed by reference to all subsequent commands.
```c#
SnSelenium snSel = new SnSelenium(Constants.SupportedBrowsers.CHROME,logger);
```
Then we can run commands on the `snSel` as `SnSelenium` implements `IChainable` interface.
```c#
snSel.Visit("https://www.youtube.com/").Execute();
```
Here snSel is of type IChainable so we can use command on it.
All failable commands return instance of IRunnable which contains implementation of `Execute` method.<br/>
Such commands can be executed by calling `Execute()` on then.If you want to execute commands with retry meachanism
you can try `.Execute(100,5)` which signifies try 5 times with duration of 500 miliseconds between tries.

<br/>

## All Actions are chainable by default
for example
```c#
SnSelenium snSel = new SnSelenium(Constants.SupportedBrowsers.CHROME,logger);
snSel.Visit("https://hasare.com/").Execute().GetOne({provide x path}).Execute()...(next commmand)
```
as shown in above example we can chain commands together to accomplish the task.<br/>
## Built in retries
Most Action are retryable by default <br/>
So if you want cetail action to execute atmost 3 times with time duration of 100 miliseconds between each rety till it succeds
then you can pass below parameters to `Execute` Method
```c#
Execute(100,3) // wait for 100 miliseconds between each tries, try for almost 3 times
``` 
here 100 is time duration between retries and 3 iss max no of attempt

## Get Result of action
To get result of particular action we can call `GetResult()` on Result returned by `Execute` method
```c#
IWebElement el=snSel.Visit("https://hasare.com/").Execute().GetOne({provide By}).Execute().GetResult()
```
Point to note calling `GetResult` breaks the chaining ability. <br/>

To save the result for later user but to continue execution chain please see below command `As`

## Saving result in context
As shown in diagram above Shunya initiates its own context which is used internally to store bunch of things.You can make use of same context to store result of action execution.<br/>
```c#
snSel.Visit("https://hasare.com/").Execute().GetOne({provide x path}).Execute().As("@elementone")... next actions
``` 
what this allows you do to is save the result of action and continue chaining to achieve objective.But when at later point you want to use the result you can simply call<br/>
```c#
var context = snSel.GetContext();  // Get context
IWebElement a=context.GetTypeValue<IWebElement>("@elementone"); // retrive element from context
```
Get saved IWebElement
<br/>  **!!! One Thing to note here is you should know the type of object you are retrieving fromm context !!!**
<br/>  **!!! You could find the type of object by checking Return Type of Execute method before calling As on it !!!**

# All Actions

**Instantiate Shunya Selenium To begin**
```c#
using Shunya.Selenium;
using Shunya.Selenium.Selenium;

SnSelenium snSel = new SnSelenium(Constants.SupportedBrowsers.CHROME,logger);
```
### Visit 
This is use to navigate top particular page
```c#
var foundElement=snSel.Visit("https://hasare.com").Execute();
```

### GetOne
Get First html element satisfying the requirements.
```c#
 IWebElement foundElement=snSel.Visit("https://hasare.com").Execute()
   .Get(By.XPath("/html/body/div[1]/div[1]/main/div/div[1]/div/h1")).Execute().GetResult();
```
### GetMany
Get all elements satisfying Selenium By object
```c#
ReadOnlyCollection<IWebElement> foundElement=snSel.Visit("https://www.selenium.dev").Execute()
.Get(By.XPath("/html/body/div/main/section[2]/div/div/div[2]/div/div[1]/h4")).Execute().GetResult();
```

### As
Used to save result of earlier action in context. <br/> 
Note- Use string starting with @ as input to As
```c#
var foundElement=snSel.Visit("https://www.selenium.dev").Execute()
.Get(By.XPath("/html/body/div/main/section[2]/div/div/div[2]/div/div[1]/h4")).Execute().As("@save");
var context = snSel.GetContext();
var a=context.GetTypeValue<IReadOnlyCollection<IWebDriver>>("@save");
```

### Wait
This action is used to wait for certain time before executing next action ina action chain.<br/>
Below command will wait till 10 seconds have passed before getting the url.
```c#
 var result = snSel.Visit("https://hasare.com/").Execute().Wait(10000).Location().GetResult();
```

### Pause
This action pauses further execution of actions until user closes additional browser tab opened.<br/>
Use full for debugging purposes where you are not sure how long it will take to fix the issue.

```c#
// Pause takes in optional boolean parameter if you pass the params as True then Pause will be skipped
 var result=snSel.Visit("https://hasare.com/").Execute().Pause().Location().GetResult(); // the pause will stop execution of next actrions till additrional browser window is closed.
```

### Closest
Get the first DOM element that matches the selector (whether it be itself or one of its ancestors).<br/>

```c#
//Takes in ".className" or html tag like "div" as input.
 var foundElement=snSel.Visit("https://hasare.com").Execute()
            .GetOne(By.XPath("/html/body/div/div[1]/main/div/div[1]/div/h1")).Execute()
            .Closest("div").Execute().GetResult();
```
### Eq
Get A DOM element at a specific index in an array of elements.
```c#
var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Eq(0);
```

### Filter
Filters IWebElement collection based on delegate passed.
```c#
ReadOnlyCollection<IWebElement> foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Filter(el=>el.Text=="TEXT").GetResult();
```

### Find
Get the descendent DOM elements of a specific selector.
```c#
ReadOnlyCollection<IWebElement>  foundElement = snSel.Visit("https://hasare.com/").Execute()
         .GetOne(By.XPath("//*[@id=\"products\"]/div/dl")).Execute().Find("div").GetResult();
```

### First
Get the first DOM element within a set of DOM elements.

```c#
IWebElement foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Filter(el=>el.Text=="TEXT").First().GetResult();
```

### Last
Get the last DOM element within a set of DOM elements.
```c#
var foundElement=snSel.Visit("https://hasare.com/").Execute()
            .Get(By.XPath("//*[@id=\"products\"]/div/dl/div[*]/dd")).Execute().Last().GetResult();
```

### Location
Get Current browser Url
```c#
string result=snSel.Visit("https://hasare.com/").Execute().Location().GetResult();
```

## Authors

- [@OutOfBoundCats](https://github.com/OutOfBoundCats)

## Support

For support raise an issue in this repository.

## Contributing

PR's are most welcome to add additional functionality.

## License

[MIT](https://choosealicense.com/licenses/mit/)

