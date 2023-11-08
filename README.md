# This Project is an attempt to wrap selenium to expose Api which is somewhere inbetween C# LINQ and Cypress

## Shunya commands can be classified one of the following

- query - commands that read the state of your application
- assertion - command which assert on a given state
- action - interact with your application as a user would
- other - any other command that is useful for writing tests

## The basic execution flow is shown below

![image description](Documentation/Images/ExecutionFlow.png)

We first start by creating Instance of `IChainable` i.e. `SnSelenium` by passing Type of browser and Instance of ILogger.<br/>
This also created context which is then passed by reference to all subsequent commands.

`SnSelenium snSel = new SnSelenium(Constants.SupportedBrowsers.CHROME,logger);`

Then we can run commands on the `snSel` as `SnSelenium` implements `IChainable` interface.


- `snSel.Visit("https://www.youtube.com/").Execute();` <br/>

    Here snSel is of type IChainable so we can use command on it.
    All failable commands return instance of IRunnable which contains implementation of `Execute` method.<br/>
    Such commands can be executed by calling `Execute()` on then.If you want to execute commands with retry meachanism
    you can try `.Execute(100,5)` which signifies try 5 times with duration of 500 miliseconds between tries.

<br/>






