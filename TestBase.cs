using DotNetEnv;
using OpenQA.Selenium.Chrome;
using Selenium;

namespace TestsProject
{
    public class TestBase
    {
        private ChromeDriver driver;
        protected Locators locators;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            Actions.driver = driver;
            locators = new Locators(driver);
            driver.Manage().Window.Maximize();
            var path = @"C:\Users\lucas\source\repos\TestsProject\EnvironmentVariables\Variables.env";
            Env.Load(path);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
