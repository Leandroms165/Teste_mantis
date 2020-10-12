using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TesteMantis.Page_Object;

namespace ST01Mantis
{
    [TestFixture]
    public class CT01ValidandoLayout
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://mantis-prova.base2.com.br/my_view_page.php";
            verificationErrors = new StringBuilder();
        }
        
        
        
        [Test]
        public void TheCT01ValidandoLayoutTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("9087");
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("leandro.matias");
            driver.FindElement(By.CssSelector("input.button")).Click();
            new SelectElement(driver.FindElement(By.Name("project_id"))).SelectByText("Leandro Matias´s Project");
            
            ValidandoLayout validandoLayout = new ValidandoLayout();
            PageFactory.InitElements(driver, validandoLayout);

            // Verificando presença de elementos
            Assert.IsTrue(validandoLayout.MyView.Displayed);
            Assert.IsTrue(validandoLayout.ViewIssues.Displayed);
            Assert.IsTrue(validandoLayout.ReportIssue.Displayed);
            Assert.IsTrue(validandoLayout.ChangeLog.Displayed);
            Assert.IsTrue(validandoLayout.Roadmap.Displayed);
            Assert.IsTrue(validandoLayout.MyAccount.Displayed);


            // Verificando elementos tela reportar problemas
            driver.FindElement(By.LinkText("Report Issue")).Click();
            Assert.IsTrue(validandoLayout.category_id.Displayed);
            Assert.IsTrue(validandoLayout.reproducibility.Displayed);
            Assert.IsTrue(validandoLayout.severity.Displayed);
            Assert.IsTrue(validandoLayout.priority.Displayed);
            Assert.IsTrue(validandoLayout.profile_id.Displayed);
            Assert.IsTrue(validandoLayout.summary.Displayed);
            Assert.IsTrue(validandoLayout.description.Displayed);
            Assert.IsTrue(validandoLayout.steps_to_reproduce.Displayed);
            Assert.IsTrue(validandoLayout.additional_info.Displayed);
            Assert.IsTrue(validandoLayout.InputButton.Displayed);

            
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
