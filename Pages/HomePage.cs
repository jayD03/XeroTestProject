using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public bool IsVisible => Driver.Title.Contains("Accounting Software – Do Beautiful Business | Xero NZ");
        public IWebElement LoginLink => Driver.FindElement(By.LinkText("Log in"));

        public void Goto()
        {
            Driver.Navigate().GoToUrl(Resources.SiteUrl);
            Assert.IsTrue(IsVisible, "Xero Home page is not visible.");
        }

        public LoginPage NavigateToLoginPage()
        {
            LoginLink.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//h2[contains(text(),'Log in to Xero')]"));
            return new LoginPage(Driver);
        }
    }
}