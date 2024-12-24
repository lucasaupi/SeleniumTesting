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
            locators = new Locators();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
