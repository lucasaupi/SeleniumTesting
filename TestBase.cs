using DotNetEnv;
using OpenQA.Selenium.Chrome;
using Selenium;

namespace TestsProject
{
    public class TestBase
    {
        private ChromeDriver driver;
        protected Locators locators;
        private readonly string path = @"C:\Users\lucas\source\repos\TestsProject\EnvironmentVariables\Variables.env";

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            //options.AddArguments("--blink-settings=imagesEnabled=false");
            //options.AddArguments("--headless");
            driver = new ChromeDriver(options);
            Actions.driver = driver;
            locators = new Locators(driver);
            driver.Manage().Window.Maximize();
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
