using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ST01Mantis
{
    [TestFixture]
    public class CT02ReportandoProblema
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
        
        [Test]
        public void TheCT02ReportandoProblemaTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");

            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("leandro.matias");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("9087");
          
            
            driver.FindElement(By.CssSelector("input.button")).Click();
            // Seelcionando projeto
            new SelectElement(driver.FindElement(By.Name("project_id"))).SelectByText("Leandro Matias´s Project");
            // Reportando problema
            driver.FindElement(By.LinkText("Report Issue")).Click();
            // Reportanto detalhes
            new SelectElement(driver.FindElement(By.Name("category_id"))).SelectByText("[All Projects] Teste");
            new SelectElement(driver.FindElement(By.Name("reproducibility"))).SelectByText("always");
            new SelectElement(driver.FindElement(By.Name("severity"))).SelectByText("major");
            new SelectElement(driver.FindElement(By.Name("priority"))).SelectByText("urgent");
            new SelectElement(driver.FindElement(By.Name("profile_id"))).SelectByText("Desktop Windows 10");
            driver.FindElement(By.Name("summary")).Clear();
            driver.FindElement(By.Name("summary")).SendKeys("teste");
            driver.FindElement(By.Name("description")).Clear();
            driver.FindElement(By.Name("description")).SendKeys("teste teste");
            driver.FindElement(By.Name("steps_to_reproduce")).Clear();
            driver.FindElement(By.Name("steps_to_reproduce")).SendKeys("teste > teste");
            driver.FindElement(By.Name("additional_info")).Clear();
            driver.FindElement(By.Name("additional_info")).SendKeys("nenhuma");
            driver.FindElement(By.CssSelector("input.button")).Click();
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
