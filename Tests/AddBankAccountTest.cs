using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using XeroTestProject.Models;
using XeroTestProject.Pages;
using XeroTestProject.Util;

namespace XeroTestProject.Tests
{
    [TestClass]
    [TestCategory("AddBAnkAcount")]

    public class AddBankAccountTest
    {
        public TestUser TheTestUser { get; private set; }
        private IWebDriver Driver { get; set; }
        public HomePage XeroHomePage { get; private set; }
        public TestAccount TheTestAccount { get; private set; }

        private string _accountNumber;

        [Description("")]
        [TestMethod]
        public void AddBankAccountwithValidDetails_Test1()
        {
            HomePage xeroHomePage = new HomePage(Driver);
            xeroHomePage.Goto();//XeroHomepage

            LoginPage loginPage = xeroHomePage.NavigateToLoginPage();
            Assert.IsTrue(loginPage.IsVisible, "Login Page is not visible.");

            TwoFactorAuthPage twoFactorAuthPage = loginPage.ClickLoginButtonWithValidCred(TheTestUser);
            //Assert.IsTrue(twoFactorAuthPage.IsVisible, "Two Factor Auth Page is not visible.");

            AuthenticationPage authenticationPage = twoFactorAuthPage.ClickAnotherAuthOptionLink();
            //Assert.IsTrue(authenticationPage.IsVisible, "Two Factor Auth Page is not visible.");

            SecurityQuestionPage securityQuestionPage = authenticationPage.ClickSecurityQuetions();
            //Assert.IsTrue(securityQuestionPage.IsVisible, "Security Questions page is not visible.");

            var qlist = new List<SecurityQuestion>()
            {
                new SecurityQuestion() { Question = "What is your dream job?", Answer = "xero1" },
                new SecurityQuestion() { Question = "What is your dream car?", Answer = "xero2" },
                new SecurityQuestion() { Question = "Who is your favourite painter?", Answer = "xero3" }
            };

            //after auth page will navogate to here
            DashboardPage dashboardPage = securityQuestionPage.ClickConfirm(qlist);
            /*Assert.IsTrue(dashboardPage.IsVisible, "Dashboard page is not visible."); *///need to add a wait to load the page

            AccountPage accountPage = dashboardPage.ClickAccountingTab();
            //Assert.IsTrue(accountPage.IsVisible,"Account Page is not visible");

            AddBankAccountPage addbankacount = accountPage.ClickAddBankAccount();            
            //Assert.IsTrue(addbankacount.IsVisible, "Add Bank acoount page is not visible.");

            addbankacount.ClickANZFromPopularNZBanks();//need to add a wait

            addbankacount.AddAcountDetails(TheTestAccount);

            addbankacount.ClickContinueButton(); //need to add a wait

            addbankacount.ClickGotAFormButton();//need to add a wait

            addbankacount.ClickSkipUploadformButton();//need to add a wait

            dashboardPage.ClickAccountingTab();

            var isAccountNumber = dashboardPage.CheckAddedAccount(_accountNumber);//need to add a wait
            Assert.IsTrue(isAccountNumber, "Account number is not visible");

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

            TheTestAccount = new TestAccount();
            _accountNumber = Helper.Get8Digits();
            TheTestAccount.AccountName = $"Test Account {_accountNumber}";
            TheTestAccount.AccountNumber = _accountNumber.ToString();
        }
    }
}
