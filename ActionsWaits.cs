﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestsProject
{
    public static partial class Actions
    {
        public static IWebElement WaitUntilClickeable(this By locator, int timeout = 10)
        {
            IWebElement element = Waiting(timeout).Until(ExpectedConditions.ElementToBeClickable(locator));
            ViewTheElement(element);
            return element;
        }
        public static IWebElement WaitUntilClickeable(this IWebElement element, int timeout = 10)
        {
            IWebElement clickeableElement = Waiting(timeout).Until(ExpectedConditions.ElementToBeClickable(element));
            ViewTheElement(clickeableElement);
            return clickeableElement;
        }
        public static IWebElement WaitUntilVisible(this By locator, int timeout = 10)
        {
            IWebElement element = Waiting(timeout).Until(ExpectedConditions.ElementIsVisible(locator));
            ViewTheElement(element);
            return element;
        }

        public static void Sleep(int timeout = 1)
        {
            Thread.Sleep(timeout * 1000);
        }
        public static void Sleep(double timeout)
        {
            Thread.Sleep(Convert.ToInt32(timeout * 1000));
        }
        public static void WaitForAlertsAndConfirm(int cant = 1)
        {
            for (int i = 0; i < cant; i++)
            {
                try
                {
                    WebDriverWait wait = Waiting();
                    wait.Until(ExpectedConditions.AlertIsPresent());
                    IAlert alert = GetDriver().SwitchTo().Alert();
                    alert.Accept();
                }
                catch (NoAlertPresentException) { }
            }
        }
    }
}
