using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{
    public class UserPage
    {
        public IWebDriver driver;
        public UserPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[2]/div[2]/div/div[3]/div/a")]
        private IWebElement photoProfile;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[5]/div/div/div[1]/div[1]/div/span[2]")]
        private IWebElement penaltySum;

        public System.Drawing.Size GetProfilePhotoSize()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[1]/div/div[1]/div[2]/div[2]/div/div[3]/div/a")));
            return photoProfile.Size;
        }

        public double GetPenaltySum()
        {
            string penaltySumTrim = penaltySum.Text.Replace(" ", "");
            return double.Parse(penaltySumTrim, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
