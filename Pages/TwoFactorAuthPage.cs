using OpenQA.Selenium;

namespace XeroTestProject.Pages
{
    public class TwoFactorAuthPage : BasePage
    {
        public TwoFactorAuthPage(IWebDriver driver) : base(driver) { }
        public IWebElement UseAnotherAuthLink => Driver.FindElement(By.XPath("//button[@type='submit' and contains(.,'Use another authentication method')]"));

        public AuthenticationPage ClickAnotherAuthOptionLink()
        {
            UseAnotherAuthLink.Click();
            return new AuthenticationPage(Driver);
        }
    }
}