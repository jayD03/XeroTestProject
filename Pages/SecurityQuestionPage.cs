using OpenQA.Selenium;
using System.Collections.Generic;
using XeroTestProject.Models;
using XeroTestProject.Util;

namespace XeroTestProject.Pages
{
    public class SecurityQuestionPage : BasePage
    {
        public SecurityQuestionPage(IWebDriver driver) : base(driver) { }
        
        public IWebElement ConfirmAnswers => Driver.FindElement(By.XPath("//button[@type='submit' and contains(text(),'Confirm')]"));

        public IWebElement BankAccountsPage => Driver.FindElement(By.Id("title"));

        public DashboardPage ClickConfirm(List<SecurityQuestion> questions)
        {
            foreach(var question in questions)
            {
                string str = $"//label[contains(text(),'{question.Question}')]/following::input[1]";
                if (Driver.FindElements(By.XPath(str)).Count > 0)
                {
                    IWebElement element = Driver.FindElement(By.XPath(str));
                    element.Click();
                    element.SendKeys(question.Answer);
                }
            }

            ConfirmAnswers.Click();
            Helper.WaitUntilElementVisible(Driver, By.XPath("//span[contains(text(),'Get paid faster with online invoices')]"));
            return new DashboardPage(Driver);
        }
    }
}
