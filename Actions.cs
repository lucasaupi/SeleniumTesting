using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace TestsProject
{
    public static partial class Actions
    {
        public static IWebDriver? driver;
        private static Dictionary<By, IWebElement> elementCache = new Dictionary<By, IWebElement>();

        public static IWebDriver GetDriver()
        {
            if (driver == null) throw new InvalidOperationException("Driver has not been initialized.");
            return driver;
        }
        public static void GoToPage(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }
        public static WebDriverWait Waiting(int timeout = 10)
        {
            return new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(timeout));
        }

        public static IWebElement FindElement(By locator)
        {
            if (elementCache.ContainsKey(locator))
            {
                return elementCache[locator];
            }
            var element = WaitUntilVisible(locator);
            elementCache[locator] = element;
            return element;
        }
        public static void ViewTheElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetDriver();
            js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center', inline: 'nearest' });", element);
        }
        public static void ViewTheElement(By locator)
        {
            IWebElement element = WaitUntilVisible(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetDriver();
            js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center', inline: 'nearest' });", element);
        }
        public static bool IsElementVisible(this By locator, int timeout = 10)
        {
            bool result = false;
            try
            {
                Waiting(timeout).Until(ExpectedConditions.ElementIsVisible(locator));
                result = true;
            }
            catch (WebDriverTimeoutException) { Debug.WriteLine($"Timeout exception: Element with selector {locator} was not visible after {timeout} seconds."); }
            return result;
        }

        public static void SwitchToFrame(string id, int timeout = 10)
        {
            WebDriverWait wait = Waiting(timeout);
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(id));
        }

        public static void SwitchToFrame(By id, int timeout = 10)
        {
            WebDriverWait wait = Waiting(timeout);
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(id));
        }

        public static void SelectOptionByText(this By locator, string text)
        {
            new SelectElement(WaitUntilVisible(locator)).SelectByText(text);
        }
        public static void Refresh()
        {
            GetDriver().Navigate().Refresh();
            WaitLoadFullPage();

        }
        public static void WaitLoadFullPage(int wait = 30)
        {
            Waiting(wait).Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
