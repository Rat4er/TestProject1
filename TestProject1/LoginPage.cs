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
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[3]/div/div/div/div[2]/div[1]/div/div[1]/a")]
        private IWebElement DemoButton;

        public void ClickDemoButton()
        {
            DemoButton.Click();
        }
    }
}
