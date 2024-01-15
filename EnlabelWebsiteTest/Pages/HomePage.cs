using OpenQA.Selenium;
using System.Configuration;


namespace EnlabelWebsiteTest.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            URLproperty = ConfigurationManager.AppSettings["host"];
        }
    }
}
