using OpenQA.Selenium;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver) { }
        public IWebElement AddBankAccountButton => Driver.FindElement(By.XPath("//span[@class = 'text' and contains(text(),'Add Bank Account')]"));

        public AddBankAccountPage ClickAddBankAccount()
        {
            AddBankAccountButton.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//h1[contains(text(),'Add Bank Accounts')]"));
            return new AddBankAccountPage(Driver);
        }
    }
}