using OpenQA.Selenium;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class AuthenticationPage : BasePage
    {
        public AuthenticationPage(IWebDriver driver) : base(driver) { }

        public IWebElement SecurityQuestionButton=> Driver.FindElement(By.XPath("//button[contains(text(),'Security questions')]"));

        public SecurityQuestionPage ClickSecurityQuetions()
        {
            SecurityQuestionButton.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//h1[contains(text(),'Answer your security questions to authenticate')]"));            
            return new SecurityQuestionPage(Driver);
        }
    }
}