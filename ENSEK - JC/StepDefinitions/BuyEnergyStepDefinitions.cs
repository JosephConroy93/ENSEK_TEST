using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ENSEK.Models;
using ENSEK.Pages;

namespace ENSEK.StepDefinitions
{
    [Binding]
    public class BuyEnergyStepDefinitions
    {
        private driverHelper _driverHelper;
        private Energy _energy;
        private HomePage _HomePage;
        private BuyEnergyPage _BuyEnergyPage;
        
        public BuyEnergyStepDefinitions(driverHelper driverHelper, Energy energy)
        {
            _driverHelper = driverHelper;
            _energy = energy;
            _HomePage = new HomePage(_driverHelper, _energy);
            _BuyEnergyPage = new BuyEnergyPage(_driverHelper, _energy);
        }


        [Given(@"I Have Logged In To The ENSEK URL ""([^""]*)""")]
        public void GivenIHaveLoggedInToTheENSEKURL(string url)
        {
            _driverHelper.driver.Navigate().GoToUrl(url);
        }

        [Given(@"I Want To Purchase Energy")]
        public void GivenIWantToPurchaseEnergy(Table table)
        {
            dynamic energyData = table.CreateDynamicInstance();
            _energy.EnergyType = energyData.EnergyType;
            _energy.NumberUnits = energyData.Units;

        }

        [When(@"I Click Buy Energy")]
        public void WhenIClickBuyEnergy()
        {
            _HomePage.ClickHomePageButton("Buy energy");
        }

        [Then(@"And I Input Number of Units")]
        public void ThenAndIInputNumberOfUnits()
        {
            _BuyEnergyPage.inputNumberOfEnergyUnits();
        }

        [Then(@"Click The Buy Button")]
        public void ThenClickTheBuyButton()
        {
            _BuyEnergyPage.clickEnergyBuyUnits();
        }

        [Then(@"My Transaction Is Confirmed")]
        public void ThenMyTransactionIsConfirmed()
        {
            _BuyEnergyPage.verifyTransactionoSuccess();
        }
    }
}
