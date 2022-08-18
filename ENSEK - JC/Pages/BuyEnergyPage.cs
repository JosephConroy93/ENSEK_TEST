using ENSEK.Models;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ENSEK.Pages
{
    public class BuyEnergyPage
    {
        private driverHelper _driverHelper;
        private Energy _energy;

        public BuyEnergyPage(driverHelper driverHelper, Energy energy)
        {
            this._driverHelper = driverHelper;
            this._energy = energy;
        }

        public void inputNumberOfEnergyUnits()
        {
            string locator = $"//td[.='{_energy.EnergyType}']/following-sibling::td/input[@name='energyType.AmountPurchased']";
            Console.WriteLine(locator);
            waitForElementDisplayed(locator);
            _driverHelper.driver.FindElement(By.XPath(locator)).Clear();
            _driverHelper.driver.FindElement(By.XPath(locator)).SendKeys(_energy.NumberUnits.ToString());
        }

        public void clickEnergyBuyUnits()
        {
            string locator = $"//td[.='{_energy.EnergyType}']/following-sibling::td/input[@name='Buy']";
            Console.WriteLine(locator);
            waitForElementDisplayed(locator);
            _driverHelper.driver.FindElement(By.XPath(locator)).Click();
        }

        public void verifyTransactionoSuccess()
        {
            waitForElementDisplayed("//h2[.='Sale Confirmed!']");
            waitForElementDisplayed("//div[@class='well']");
            string transactionConfText = _driverHelper.driver.FindElement(By.XPath("//div[@class='well']")).Text;
            Assert.IsTrue(transactionConfText.Contains(_energy.NumberUnits.ToString()));          
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
