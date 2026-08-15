using DotNetEnv;
using OpenQA.Selenium.Chrome;
using Selenium;

namespace TestsProject
{
    public class TestBase
    {
        private ChromeDriver driver;
        protected Locators locators;
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnvironmentVariables", "Variables.env");

        [SetUp]
        public void SetUp()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--start-maximized");
                //options.AddArguments("--blink-settings=imagesEnabled=false");
                //options.AddArguments("--headless");
                driver = new ChromeDriver(options);
                Actions.driver = driver;
                locators = new Locators(driver);

                Env.Load(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR EN SETUP: " + ex.ToString());
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
