using ATFramework2._0.Driver;
using OpenQA.Selenium.Support.UI;

namespace GoogleEarth.AutoTests.Pages;

public static class WebDriverExtensions
{
    public static void OpenAnotherWindow(this IWebDriverManager webDriver)
    {
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