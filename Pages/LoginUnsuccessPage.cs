using OpenQA.Selenium;

namespace XeroTestProject.Pages
{
    public class LoginUnsuccessPage : BasePage
    {
        public LoginUnsuccessPage(IWebDriver driver) : base(driver) { }
        public IWebElement InvalidLogin => Driver.FindElement(By.XPath("//*[@id='xl-validation-message']"));
    }
}