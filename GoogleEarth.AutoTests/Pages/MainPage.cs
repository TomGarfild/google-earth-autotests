using ATFramework2._0.Driver;
using ATFramework2._0.ElementHandle;

namespace GoogleEarth.AutoTests.Pages;

public interface IMainPage
{
    void SelectMore(string name);
    void ClickPage(string name);
}

public class MainPage : IMainPage
{
    private readonly IWebDriverManager _webDriver;
    
    public MainPage(IWebDriverManager webDriver)
    {
        _webDriver = webDriver;
        _webDriver.OpenApplicationStartPage();
    }

    private Element More => _webDriver.ElementFinder.XPath("//div[text() = 'More from Earth']");
    public Element OptionMore(string optionName) => _webDriver.ElementFinder.XPath($"//ul/li/a[text() = '{optionName}']");
    
    private Element Page(string name) => _webDriver.ElementFinder.XPath($"//a[contains(text(), '{name}')]");

    public void SelectMore(string name)
    {
        More.Click();
        OptionMore(name).Click();
    }

    public void ClickPage(string name)
    {
        Page(name).Click();
    }
}