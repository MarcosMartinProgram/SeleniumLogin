using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLoginTest;

public class Tests
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void TestLogin()
    {
        driver.Navigate().GoToUrl("file:///C:/Users/cotom/OneDrive/Escritorio/SeleniumLogin/SeleniumLoginTest/login.html");

        IWebElement usernameField = driver.FindElement(By.Id("username"));
        IWebElement passwordField = driver.FindElement(By.Id("password"));
        IWebElement loginButton = driver.FindElement(By.Id("loginButton"));

        usernameField.SendKeys("testuser");
        passwordField.SendKeys("testpassword");// se puede reemplazar por un valor real
        loginButton.Click();

        System.Threading.Thread.Sleep(2000); // Espera para ver el resultado

        Assert.That(driver.Url, Is.EqualTo("file:///C:/Users/cotom/OneDrive/Escritorio/SeleniumLogin/SeleniumLoginTest/success.html"));
        Assert.That(driver.PageSource.Contains("Formulario completado exitosamente"), Is.True);
    }
    [TearDown]
    public void Teardown()
    {
        if(driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }   
        
    }
}
