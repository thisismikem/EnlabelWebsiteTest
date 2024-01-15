using System;

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace EnlabelWebsiteTest.Utils
{
    public static class WebDriverExtension
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By locator)
        {
            var wait = new DefaultWait<IWebDriver>(driver)
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
                Timeout = TimeSpan.FromSeconds(30),
                Message = $"My element timedout"
            };
            //Retry every 200 milliseconds upto 30 seconds. 
            return wait.Until(e =>
            {
                var element = e.FindElement(locator);
                return (element.Displayed || element.Enabled) ? element : throw new NoSuchElementException(wait.Message);
            });
        }

        public static void WaitForLoad(this IWebDriver driver, int timeoutSec = 30)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));

            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
