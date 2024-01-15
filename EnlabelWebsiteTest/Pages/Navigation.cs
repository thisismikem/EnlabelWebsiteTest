using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EnlabelWebsiteTest.Pages
{
    public class Navigation
    {
        [FindsBy(How = How.LinkText, Using = "About Us")]
        public IWebElement AboutUs { get; set; }

        [FindsBy(How = How.LinkText, Using = "Media/Events")]
        public IWebElement MediaEvents { get; set; }

        [FindsBy(How = How.LinkText, Using = "Platform")]
        public IWebElement Platform { get; set; }

        [FindsBy(How = How.LinkText, Using = "Services")]
        public IWebElement Services { get; set; }

        [FindsBy(How = How.LinkText, Using = "Compliance")]
        public IWebElement Compliance { get; set; }

        [FindsBy(How = How.LinkText, Using = "Partners")]
        public IWebElement Partners { get; set; }

        [FindsBy(How = How.LinkText, Using = "Resources")]
        public IWebElement Resources { get; set; }
    }
}
