using System;
using System.Configuration;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace EnlabelWebsiteTest.Utils
{
    public class CustomMethods
    {
        public static void MousemovePrimaryNavigation(IWebDriver driver, IWebElement primaryNavigation)
        {
            driver.WaitForLoad();
            Actions action = new Actions(driver);
            action.MoveToElement(primaryNavigation).Perform();
        }

        public static void ClickSecondaryNavigation(IWebDriver driver, IWebElement primaryNavigation, IWebElement secondaryNavigation, By bySecondary)
        {
            MousemovePrimaryNavigation(driver, primaryNavigation);

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(bySecondary));

            secondaryNavigation.Click();
        }

        public static IWebDriver InitDriver(String browser)
        {
            if ("grid".Equals(ConfigurationManager.AppSettings["web_driver_type"]))
            {
                //TODO Get remote driver
                return null;
            }
            else
            {
                switch (browser)
                {
                    case "firefox":
                        return new FirefoxDriver();
                    case "edge":
                        return new EdgeDriver();
                    default:
                        return new ChromeDriver();
                }
            }
            
        }
    }
}
