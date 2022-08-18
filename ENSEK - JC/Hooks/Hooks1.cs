using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ENSEK.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private driverHelper _driverHelper;

        public Hooks1(driverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArgument("start-maximized");
            _driverHelper.driver = new ChromeDriver(options);
            _driverHelper.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.driver.Quit();
        }


    }
}