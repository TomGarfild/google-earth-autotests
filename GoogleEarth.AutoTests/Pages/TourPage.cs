using ATFramework2._0.Driver;
using ATFramework2._0.ElementHandle;
using OpenQA.Selenium.Support.UI;

namespace GoogleEarth.AutoTests.Pages;

public interface ITourPage
{
    void ClickOnTour(string name);
}

public class TourPage(IWebDriverManager webDriver) : ITourPage
{
    private Element Tour(string name) => webDriver.ElementFinder.XPath($"//a[contains(text(), '{name}')]");
    
    public void ClickOnTour(string name)
    {
        Tour(name).Click();
        webDriver.OpenAnotherWindow();
    }
}