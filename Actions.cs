using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestsProject
{
    public static partial class Actions
    {
        public static IWebDriver? driver;
        private static readonly Dictionary<By, IWebElement> elementCache = new Dictionary<By, IWebElement>();
        private static readonly object cacheLock = new object();

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
            var wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            return wait;
        }

        public static void Refresh()
        {
            GetDriver().Navigate().Refresh();
        }

        public static void WaitLoadFullPage(int wait = 30)
        {
            Waiting(wait).Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void Sleep(int timeout = 1)
        {
            Thread.Sleep(timeout * 1000);
        }

        public static IWebElement FindElement(By locator)
        {
            lock (cacheLock)
            {
                if (elementCache.TryGetValue(locator, out var cached) && cached != null)
                {
                    try
                    {
                        if (cached.Displayed) return cached;
                    }
                    catch (StaleElementReferenceException) { }
                }

                var found = GetDriver().FindElement(locator);
                elementCache[locator] = found;
                return found;
            }
        }

        public static void ViewTheElement(IWebElement element)
        {
            ((IJavaScriptExecutor)GetDriver()).ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center', inline: 'nearest' });", element);
        }
        public static void ViewTheElement(By locator)
        {
            ArgumentNullException.ThrowIfNull(locator);
            var element = WaitUntilVisible(locator);
            ViewTheElement(element);
        }
        public static void SelectOptionByText(this By locator, string text)
        {
            new SelectElement(WaitUntilVisible(locator)).SelectByText(text);
        }

        public static void SwitchToFrame(string id, int timeout = 10)
        {
            Waiting(timeout).Until(driver =>
            {
                try
                {
                    driver.SwitchTo().Frame(id);
                    return true;
                }
                catch (NoSuchFrameException)
                {
                    return false;
                }
            });
        }

        public static void SwitchToFrame(By id, int timeout = 10)
        {
            Waiting(timeout).Until(driver =>
            {
                try
                {
                    var frameElement = driver.FindElement(id);
                    driver.SwitchTo().Frame(frameElement);
                    return true;
                }
                catch (NoSuchElementException) { return false; }
                catch (NoSuchFrameException) { return false; }
                catch (StaleElementReferenceException) { return false; }
            });
        }

        public static void WaitForAlertsAndConfirm(int cant = 1, int timeout = 10)
        {
            for (int i = 0; i < cant; i++)
            {
                var alert = Waiting(timeout).Until(driver =>
                {
                    try
                    {
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        return null;
                    }
                });
                alert.Accept();
            }
        }
    }
}