using OpenQA.Selenium;
using XeroTestProject.Models;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        
        public bool IsVisible => Driver.Title.Contains("Login | Xero Accounting Software");

        public IWebElement UserName => Driver.FindElement(By.XPath("//*[@type='email']"));

        public IWebElement Password => Driver.FindElement(By.XPath("//*[@type='password']"));

        public IWebElement Login => Driver.FindElement(By.XPath("//*[@value='login']"));

        public TwoFactorAuthPage ClickLoginButtonWithValidCred(TestUser user)
        {
            UserName.SendKeys(user.Username);
            Password.SendKeys(user.Password);
            Login.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//h1[contains(text(),'Enter the 6-digit code found in your authenticator app')]"));
            return new TwoFactorAuthPage(Driver);
        }

        public LoginUnsuccessPage ClickLoginButtonWithInValidCred(TestUser invaliduser)
        {
            UserName.SendKeys(invaliduser.Username);
            Password.SendKeys(invaliduser.Password);
            Login.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//li[contains(text(),'Your email or password is incorrect')]"));
            return new LoginUnsuccessPage(Driver);
        }
    }
}