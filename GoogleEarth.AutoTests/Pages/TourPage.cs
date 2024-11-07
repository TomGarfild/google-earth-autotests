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
        
        var originalWindow = webDriver.Driver.CurrentWindowHandle;

        var wait = new WebDriverWait(webDriver.Driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.WindowHandles.Count > 1);

        foreach (var windowHandle in webDriver.Driver.WindowHandles)
        {
            if (windowHandle == originalWindow) continue;
            
            webDriver.Driver.SwitchTo().Window(windowHandle);
            break;
        }
    }
}