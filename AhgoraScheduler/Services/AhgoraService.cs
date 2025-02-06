using AhgoraScheduler.Models;
using DotNetEnv;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AhgoraScheduler.Services;

public class AhgoraService
{
    public static void Run()
    {
        Console.Clear();
        var env = GetCredencials();

        if (env == null)
            return;

        using var driver = new ChromeDriver();
        driver.Navigate().GoToUrl(env.SiteUrl);

        // Wait 10 seconds before search for an element
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        var rootButton = driver.FindElement(By.XPath("//button[@type='button' and contains(@class, 'MuiButton-root')]"));
        rootButton.Click();

        var registrationField = driver.FindElement(By.Id("outlined-basic-account"));
        registrationField.SendKeys(env.UserRegistration);

        var passwordField = driver.FindElement(By.Id("outlined-basic-password"));
        passwordField.SendKeys(env.UserPassword);

        IWebElement advanceButton = driver.FindElement(By.XPath("//button[.//p[text()='Advance']]"));
        advanceButton.Click();

        Console.WriteLine("Your point has been registered!");
    }

    private static AhgoraModel? GetCredencials()
    {
        try
        {
            Env.Load();
            var siteUrl = Environment.GetEnvironmentVariable("SITE_URL");
            var userRegistration = Environment.GetEnvironmentVariable("USER_REGISTRATION");
            var userPassword = Environment.GetEnvironmentVariable("USER_PASSWORD");

            if (string.IsNullOrEmpty(siteUrl))
                throw new Exception("Error: The 'SITE_URL' is missing or empty! Please check your .env file.");

            if (string.IsNullOrEmpty(userRegistration))
                throw new Exception("Error: The 'USER_REGISTRATION' is missing or empty! Please check your .env file.");

            if (string.IsNullOrEmpty(userPassword))
                throw new Exception("Error: The 'USER_PASSWORD' is missing or empty! Please check your .env file.");

            return new AhgoraModel(siteUrl, userRegistration, userPassword);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}