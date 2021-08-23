using NUnit.Framework;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1
{
    public class Tests
    {
        public static string url;
        public static MainPage mainPage;
        public static LoginPage loginPage;
        public static UserPage userPage;
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            url = "https://www.nalog.ru";
            driver = new FirefoxDriver();
            driver.Url = url;
            mainPage = new MainPage(driver);
            loginPage = new LoginPage(driver);
            userPage = new UserPage(driver);
        }

        [Test]
        public void OpenDemo()
        {
            mainPage.ClickHref();
            loginPage.ClickDemoButton();
            var size = userPage.GetProfilePhotoSize();
            var penalty = userPage.GetPenaltySum();
            Assert.True(size == new System.Drawing.Size(31, 31), $"Expected 31x31, but {size}");
            Assert.True(penalty < 200000.00, $"Expexted sum < 200000, but was {penalty}");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}