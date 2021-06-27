using OpenQA.Selenium;
using XeroTestProject.Models;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class AddBankAccountPage : BasePage
    {
        public AddBankAccountPage(IWebDriver driver) : base(driver) { }
        public IWebElement ANZFromPopularNZBanks => Driver.FindElement(By.XPath("//li[contains(text(),'ANZ (NZ)')]"));
        public IWebElement AccountName => Driver.FindElement(By.XPath("//span[contains(text(),'Account Name')]/following::input[1]"));
        public IWebElement AccountNumber1 => Driver.FindElement(By.XPath("//input[@id='accountnumber-1068-inputEl']"));
        public IWebElement AccountNumber => Driver.FindElement(By.XPath("//input[@id='accountnumber-1068-inputEl']"));
        public IWebElement AccountTypeList => Driver.FindElement(By.XPath("//span[contains(text(),'Account Type')]/following::input[1]"));
        public IWebElement AccountType => Driver.FindElement(By.XPath("//li[@class='ba-combo-list-item' and contains(text(),'Everyday (day-to-day)')]"));
        public IWebElement ContinueButton => Driver.FindElement(By.XPath("//span[contains(text(),'Continue')]"));
        public IWebElement GotAFormButton => Driver.FindElement(By.XPath("//span[contains(text(),'got a form')]"));
        public IWebElement SkipUploadformButton => Driver.FindElement(By.XPath("//span[contains(text(),'do it later')]"));
        public IWebElement GotoDashboardButton => Driver.FindElement(By.XPath("//span[contains(text(),'Go to dashboard')]"));

        public IWebElement IsLoaded => Driver.FindElement(By.XPath("//header[@class='xui-pageheading']"));

        public void ClickANZFromPopularNZBanks()
        {
            Helper.WaitUntilElementVisible(Driver, By.XPath("//li[contains(text(),'ANZ (NZ)')]"));
            ANZFromPopularNZBanks.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//h1[contains(text(),'Enter your ANZ (NZ) account details')]"));

        }

        public void AddAcountDetails(TestAccount tesTestAccount)
        {
            
            AccountName.SendKeys(tesTestAccount.AccountName);//need to add a wait
            AccountTypeList.Click();
            AccountType.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//input[@id='accountnumber-1068-inputEl']"));
            AccountNumber.SendKeys(tesTestAccount.AccountNumber);
            AccountNumber.Click();

        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//span[contains(text(),'Let your bank send transactions to Xero')]"));            
        }

        public void ClickGotAFormButton()
        {
            GotAFormButton.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//span[contains(text(),'Upload your completed form')]"));
            
        }

        public void ClickSkipUploadformButton()
        {
            SkipUploadformButton.Click();
        }
    }
}