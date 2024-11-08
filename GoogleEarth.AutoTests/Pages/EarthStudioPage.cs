using ATFramework2._0.Driver;
using ATFramework2._0.ElementHandle;
using OpenQA.Selenium.Support.UI;

namespace GoogleEarth.AutoTests.Pages;

public interface IEarthStudioPage
{
    void ClickSignUp();
}

public class EarthStudioPage(IWebDriverManager webDriver) : IEarthStudioPage
{
    public Element SignUp => webDriver.ElementFinder.XPath("//a[text() = 'Sign up']");
    
    public void ClickSignUp()
    {
        SignUp.Click();
        webDriver.OpenAnotherWindow();
    }
}