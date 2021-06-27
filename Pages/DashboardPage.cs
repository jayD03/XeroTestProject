using OpenQA.Selenium;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver){ }
        public IWebElement Dashboard => Driver.FindElement(By.XPath("//*[@data-name='navigation-menu/dashboard']"));
        public IWebElement AccountingButton => Driver.FindElement(By.XPath("//button[@type='button' and contains(text(),'Accounting')]"));
        public IWebElement BankAccountsButton => Driver.FindElement(By.LinkText("Bank accounts"));


        public AccountPage ClickAccountingTab()
        {
            AccountingButton.Click();
            BankAccountsButton.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//span[contains(text(),'Bank accounts')]"));
            return new AccountPage(Driver);
        }

        public bool CheckAddedAccount(string accountNumber)
        {
            var TEst12 = Driver.FindElement(By.XPath($"//span[contains(text(),'{accountNumber}')]"));
            return TEst12.Displayed;
        }

    }
}