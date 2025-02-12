using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CreatingReports.Tests;

[TestCategory("CreatingReports")]
[TestClass]
public class BaseTest
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    protected IWebDriver? Driver { get; private set; }
    public TestContext TestContext { get; set; }
    private ScreenshotTaker ScreenshotTaker { get; set; }

    [TestInitialize]
    public void SetupForEverySingleTestMethod()
    {
        Logger.Debug("*************************************** TEST STARTED");
        Logger.Debug("*************************************** TEST STARTED");
        Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
        Driver = GetChromeDriver();
        ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
    }

    [TestCleanup]
    public void CleanUpAfterEveryTestMethod()
    {
        Logger.Debug(GetType().FullName + " started a method tear down");
        try
        {
            TakeScreenshotForTestFailure();
        }
        catch (Exception e)
        {
            Logger.Error(e.Source);
            Logger.Error(e.StackTrace);
            Logger.Error(e.InnerException);
            Logger.Error(e.Message);
        }
        finally
        {
            StopBrowser();
            Logger.Debug(TestContext.TestName);
            Logger.Debug("*************************************** TEST STOPPED");
            Logger.Debug("*************************************** TEST STOPPED");
        }
    }

    private void TakeScreenshotForTestFailure()
    {
        if (ScreenshotTaker != null)
        {
            ScreenshotTaker.CreateScreenshotIfTestFailed();
            Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
        }
        else
        {
            Reporter.ReportTestOutcome("");
        }
    }

    private void StopBrowser()
    {
        if (Driver == null)
            return;
        Driver.Quit();
        Driver = null;
        Logger.Trace("Browser stopped successfully.");
    }

    private IWebDriver GetChromeDriver()
    {
        var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        return new ChromeDriver(outPutDirectory);
    }
}
