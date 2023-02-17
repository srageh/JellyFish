using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace JellyFishTest
{
    public class Tests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void StartChrom()
        {
            driver = new ChromeDriver(".");
        }

        [Test]
        public void RegisterEmployee()
        {
            driver.Url = "https://localhost:7143/Identity/Account/Register";
            RegisterAsEmployer();
            Assert.Pass();
        }

        [Test]
        public void RegisterApplicant()
        {
            driver.Url = "https://localhost:7143/Identity/Account/Register";
            RegisterAsApplicant();
            Assert.Pass();
        }

        [Test]
        public void LoginApplicant()
        {
            driver.Url = "https://localhost:7143/Identity/Account/Login";
            loginAsApplicant();
            Assert.Pass();
        }

        [Test]
        public void LoginEmployer()
        {
            driver.Url = "https://localhost:7143/Identity/Account/Login";
            loginAsEmployer();
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
            driver.Close();
        }


        private void RegisterAsEmployer()
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys("Srageh6202@conestogac.on.ca");

            WebElement element = (WebElement)driver.FindElement(By.Id("option2"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click()", element);

          //driver.FindElement(By.Id("option2")).Click();

            // click second element 
            
            //driver.FindElement(By.Id("Input_UserType")).SendKeys("2");
            driver.FindElement(By.Id("Input_Password")).SendKeys("Test123@");
            driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("Test123@");
            driver.FindElement(By.Id("registerSubmit")).Click();
        }

        private void RegisterAsApplicant()
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys("ragehsuhaib@gmail.com");
            WebElement element = (WebElement)driver.FindElement(By.Id("option1"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click()", element);

            driver.FindElement(By.Id("Input_Password")).SendKeys("Test123@");
            driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("Test123@");
            driver.FindElement(By.Id("registerSubmit")).Click();
        }

        private void loginAsEmployer()
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys("Srageh6202@conestogac.on.ca");
            driver.FindElement(By.Id("Input_Password")).SendKeys("Test123@");
            driver.FindElement(By.Id("login-submit")).Click();
        }

        private void loginAsApplicant()
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys("ragehsuhaib@gmail.com");
            driver.FindElement(By.Id("Input_Password")).SendKeys("Test123@");
            driver.FindElement(By.Id("login-submit")).Click();
        }
    }
}