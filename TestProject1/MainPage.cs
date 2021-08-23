using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;


namespace TestProject1
{
    public class MainPage
    {

        public IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "/html/body/form/div[3]/div[1]/div[3]/div/div/div/div[1]/div/div[1]/a[2]/span[3]")]
        private IWebElement lkElement;

        public void ClickHref()
        {
            lkElement.Click();
        }
    }
}
