using System;

using EnlabelWebsiteTest.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace EnlabelWebsiteTest.Pages
{
    public class BasePage : Navigation
    {
        private IWebDriver driver;
        
        public String URLproperty { get; set; }

        public BasePage(IWebDriver _driver)
        {
            this.driver = _driver;
            _driver.WaitForLoad();
            PageFactory.InitElements(_driver, this);
        }

        public virtual void Open()
        {
            driver.Navigate().GoToUrl(this.URLproperty);
        }
    }
}
