using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XeroTestProject.Models;
using XeroTestProject.Pages;

namespace XeroTestProject.Tests
{
    [TestClass]
    [TestCategory("Login")]
    public class LoginTest
    {
        private IWebDriver Driver { get; set; }
        public HomePage XeroHomePage { get; private set; }
        public TestUser TheTestUser { get; private set; }
        public TestUser TheTestInvalidUser { get; private set; } 

        [Description("This is to verify that user can be logged in successfully.")]
        [TestMethod]
        public void LoginWithValidCredentials_Test1()
        {

            //XeroHomePage
            HomePage xeroHomePage = new HomePage(Driver);
            xeroHomePage.Goto();//XeroHomepage

            LoginPage loginPage = xeroHomePage.NavigateToLoginPage();

            TwoFactorAuthPage twoFactorAuthPage = loginPage.ClickLoginButtonWithValidCred(TheTestUser);

            AuthenticationPage AuthenticationPage = twoFactorAuthPage.ClickAnotherAuthOptionLink();

            SecurityQuestionPage securityQuestionPage = AuthenticationPage.ClickSecurityQuetions();


            var qlist = new List<SecurityQuestion>()
            {
                new SecurityQuestion() { Question = "What is your dream job?", Answer = "xero1" },
                new SecurityQuestion() { Question = "What is your dream car?", Answer = "xero2" },                
                new SecurityQuestion() { Question = "Who is your favourite painter?", Answer = "xero3" }
            };

            //after auth page will navogate to here need to add a wait
            DashboardPage dashboardPage = securityQuestionPage.ClickConfirm(qlist);
            //Assert.IsTrue(dashboardPage.IsVisible, "Dashboard page is not visible.");
        }

        [Description("This is to verify that user cannot login with invaslid credentials.")]
        [TestMethod]
        public void LoginWithInvalidCredentials_Test2()
        {
            HomePage xeroHomePage = new HomePage(Driver);
            xeroHomePage.Goto();

            LoginPage loginPage = xeroHomePage.NavigateToLoginPage();

            LoginUnsuccessPage LoginUnsuccessPage = loginPage.ClickLoginButtonWithInValidCred(TheTestInvalidUser);
        }

        private IWebDriver GetChromeDriver()
        {
           var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
           return new ChromeDriver(outPutDirectory);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            XeroHomePage = new HomePage(Driver);

            TheTestUser = new TestUser();
            TheTestUser.Username = "xerocodingexercise@gmail.com";
            TheTestUser.Password = "Test*0102";

            TheTestInvalidUser = new TestUser();
            TheTestInvalidUser.Username = "invalid@gmail.com";
            TheTestInvalidUser.Password = "invalidPassword";
        }

    }
}
