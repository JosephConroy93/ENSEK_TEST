using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENSEK.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ENSEK.Pages
{
    public class HomePage
    {
        private driverHelper _driverHelper;
        private Energy _energy;

        public HomePage(driverHelper driverHelper, Energy energy)
        {
            _driverHelper = driverHelper;
            _energy = energy;
        }

        public void clickNavigationButton(string text)
        {
            string locator = $"//ul[contains(@class,'navbar')]/li/a[.='{text}']";
            waitForElementDisplayed(locator);
            _driverHelper.driver.FindElement(By.XPath(locator)).Click();    
        }

        public void ClickHomePageButton(string text)
        {
            string locator = $"//a[@class='btn btn-default'][contains(.,'{text}')]";
            waitForElementDisplayed(locator);
            _driverHelper.driver.FindElement(By.XPath(locator)).Click();    
        }

        public void waitForElementDisplayed(string locator)
        {
            WebDriverWait wait = new WebDriverWait(_driverHelper.driver, TimeSpan.FromSeconds(15));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.Until(d => d.FindElement(By.XPath(locator)).Displayed);            
        }


    }
}
