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
        public string url { get; set; }
        public IWebDriver driver { get; set; }
        [SetUp]
        public void Setup()
        {
            this.url = "https://www.nalog.ru";
            this.driver = new FirefoxDriver();
        }

        [Test]
        public void OpenDemo()
        {
            driver.Navigate().GoToUrl(url);
            var element = driver.FindElement(By.XPath("/html/body/form/div[3]/div[1]/div[3]/div/div/div/div[1]/div/div[1]/a[2]/span[3]"));
            element.Click();
            element = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div[1]/a"));
            element.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var waitForElement = new Func<IWebDriver, bool>((IWebDriver web) =>
                {
                    var elementToFind = web.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div[2]/div/div[3]/div/a"));
                    if (elementToFind.GetAttribute("title").Contains("Профиль"))
                        return true;
                    return false;
            }
                );
            wait.Until(waitForElement);
            var photoProfile = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div[2]/div/div[3]/div/a"));
            Assert.True(photoProfile.Size == new System.Drawing.Size(31, 31), $"Expected 31x31, but {photoProfile.Size}");
            var rubleElement = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[5]/div/div/div[1]/div[1]/div/span[2]"));
            string ruble = rubleElement.Text;
            ruble = ruble.Replace(" ", "");
            double sum = double.Parse(ruble, System.Globalization.CultureInfo.InvariantCulture);
            Assert.True(sum < 200000.00, $"Expexted sum < 200000, but was {sum}");
            driver.Close();
            driver.Quit();
        }
    }
}