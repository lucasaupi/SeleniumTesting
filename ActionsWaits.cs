using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestsProject
{
    public static partial class Actions
    {
        public static IWebElement WaitUntilClickable(this By locator, int timeout = 10)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            try
            {
                var element = Waiting(timeout).Until(driver =>
                {
                    try
                    {
                        var el = driver.FindElement(locator);
                        return (el.Displayed && el.Enabled) ? el : null;
                    }
                    catch (NoSuchElementException) { return null; }
                    catch (StaleElementReferenceException) { return null; }
                });
                if (element == null) throw new WebDriverTimeoutException($"Timed out after {timeout}s waiting for element {locator} to be clickable.");
                return element;
            }
            catch (WebDriverTimeoutException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while waiting for element {locator} to be clickable.", ex);
            }
        }

        public static IWebElement WaitUntilClickable(this IWebElement element, int timeout = 10)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            try
            {
                var result = Waiting(timeout).Until(driver =>
                {
                    try
                    {
                        return (element.Displayed && element.Enabled) ? element : null;
                    }
                    catch (StaleElementReferenceException) { return null; }
                });
                if (result == null) throw new WebDriverTimeoutException($"Timed out after {timeout}s waiting for provided IWebElement to be clickable.");
                return result;
            }
            catch (WebDriverTimeoutException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while waiting for provided IWebElement to be clickable.", ex);
            }
        }

        public static IWebElement WaitUntilVisible(this By locator, int timeout = 10)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            try
            {
                var element = Waiting(timeout).Until(driver =>
                {
                    try
                    {
                        var el = driver.FindElement(locator);
                        return el.Displayed ? el : null;
                    }
                    catch (NoSuchElementException) { return null; }
                    catch (StaleElementReferenceException) { return null; }
                });
                if (element == null) throw new WebDriverTimeoutException($"Timed out after {timeout}s waiting for element {locator} to be visible.");
                return element;
            }
            catch (WebDriverTimeoutException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while waiting for element {locator} to be visible.", ex);
            }
        }

        public static bool IsElementVisible(this By locator, int timeout = 10)
        {
            if (locator == null) throw new ArgumentNullException(nameof(locator));
            try
            {
                return Waiting(timeout).Until(driver =>
                {
                    try
                    {
                        var el = driver.FindElement(locator);
                        return el != null && el.Displayed;
                    }
                    catch (NoSuchElementException) { return false; }
                    catch (StaleElementReferenceException) { return false; }
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while checking visibility of {locator}.", ex);
            }
        }
    }
}