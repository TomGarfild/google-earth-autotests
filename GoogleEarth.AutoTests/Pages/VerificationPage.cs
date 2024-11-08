using ATFramework2._0.Driver;
using ATFramework2._0.ElementHandle;

namespace GoogleEarth.AutoTests.Pages;

public interface IVerificationPage
{
    string GetOutreachHeader();
    string GetEarthNight();
    string GetSignIn();
}

public class VerificationPage(IWebDriverManager webDriver) : IVerificationPage
{
    public string GetOutreachHeader() => webDriver.ElementFinder.Css("h1[class='header__logo__text']").Text;
    
    public string GetEarthNight() => webDriver.ElementFinder.Css("div[class='ge-chapter__title ge-chapter__title--large-hero']").Text;
    public string GetSignIn()  => webDriver.ElementFinder.XPath("//span[text() = 'Sign in']").Text;
}