using System;
using System.Configuration;
using System.Collections.Generic;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using EnlabelWebsiteTest.Pages;
using EnlabelWebsiteTest.Utils;
using OpenQA.Selenium;
using NUnit.Framework;


namespace EnlabelWebsiteTest.Test
{
    [TestFixture]
    public class MenuTests
    {
        private IWebDriver driver;

        public static ExtentTest extentTest;
        public static ExtentReports extentReports;

        [SetUp]
        public void Setup()
        {
            driver = CustomMethods.InitDriver(ConfigurationManager.AppSettings["browser"]);
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extentReports = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(ConfigurationManager.AppSettings["report_folder"] + "Report" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + @"\index.html");
            extentReports.AttachReporter(htmlreporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extentReports.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        [Repeat(3)]
        public void MenuClickTest()
        {
            extentTest = extentReports.CreateTest("enlabel Website Test").Info("Navigation Test");

            HomePage homePage = new HomePage(driver);

            driver.Url = homePage.URLproperty;
            extentTest.Log(Status.Info, "Go to URL " + homePage.URLproperty);

            driver.Manage().Window.Maximize();

            var primaryNavigations = new List<IWebElement>
            {
                homePage.AboutUs,
                homePage.MediaEvents,
                homePage.Platform,
                homePage.Services,
                homePage.Compliance,
                homePage.Partners,
                homePage.Resources
            };

            int count = 0;

            try
            {
                foreach (var primaryNavigation in primaryNavigations)
                {
                    CustomMethods.MousemovePrimaryNavigation(driver, primaryNavigation);
                    extentTest.Log(Status.Info, "Click Primary Navigation - " + primaryNavigation.Text);

                    var bySecondary = By.XPath("//a[text()='" + primaryNavigation.Text + "']/../ul/li/a");
                    var secondaryNavigations = driver.FindElements(bySecondary);
                    extentTest.Log(Status.Info, "Get " + secondaryNavigations.Count + " secondary elements");

                    //Click primary navigation
                    primaryNavigation.Click();
                    driver.WaitForLoad();
                    extentTest.Log(Status.Info, "Page " + driver.Title + " is loaded successfully");

                    driver.Navigate().Back();
                    driver.WaitForLoad();
                    count++;

                    //Click secondary navigation
                    foreach (var secondaryNavigation in secondaryNavigations)
                    {
                        extentTest.Log(Status.Info, "Click Seccondary Navigation - " + secondaryNavigation.Text);

                        CustomMethods.ClickSecondaryNavigation(driver, primaryNavigation, secondaryNavigation, bySecondary);
                        driver.WaitForLoad();
                        extentTest.Log(Status.Info, "Page " + driver.Title + " is loaded successfully");

                        driver.Navigate().Back();
                        driver.WaitForLoad();
                        count++;
                    }
                }

                //Loaded all 28 pages
                Assert.AreEqual(28, count);
            }
            catch (Exception e)
            {
                extentTest.Log(Status.Fail, "Test Fail");
                throw;
            }

            extentTest.Log(Status.Pass, "Test Pass");
        }
    }
}