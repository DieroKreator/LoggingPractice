using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPractice
{
    public class BaseTest
    {
        public IWebDriver? Driver { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}