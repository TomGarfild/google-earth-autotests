using ATFramework2._0.Driver;

namespace GoogleEarth.AutoTests.Pages;

public interface IOutreachPage
{
    string GetHeader();
}

public class OutreachPage(IWebDriverManager webDriver) : IOutreachPage
{
    public string GetHeader() => webDriver.ElementFinder.Css("h1[class='header__logo__text']").Text;
}