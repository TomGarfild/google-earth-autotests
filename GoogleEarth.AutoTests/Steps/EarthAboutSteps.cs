using ATFramework2._0;
using ATFramework2._0.Driver;
using ATFramework2._0.Verifications;
using GoogleEarth.AutoTests.Pages;
using TechTalk.SpecFlow;

namespace GoogleEarth.AutoTests.Steps;

[Binding]
public class EarthAboutSteps(IMainPage mainPage, IVerificationPage verificationPage, ITourPage tourPage, IWebDriverManager webDriver)
{
    private void Log(string message, LogLevel level = LogLevel.Info, string feature = "Search")
    {
        webDriver.LogWorker.Log(message, level, feature, ScenarioContext.Current.ScenarioInfo.Title);
    }

    private void LogException(Exception ex, string action)
    {
        Log($"Exception during '{action}': {ex.Message}\n{ex.StackTrace}", LogLevel.Error);
    }

    [Given("Navigate to the main page of the app")]
    public void GivenNavigateToTheApp()
    {
        try
        {
            Log("Navigate to the main page of the app");
        }
        catch (Exception ex)
        {
            LogException(ex, "Navigating to the start page");
            throw;
        }
    }

    [Given(@"Click on the ""(.*)"" ""(.*)""")]
    [When(@"Click on the ""(.*)"" ""(.*)""")]
    public void ClickOnTheSearch(string type, string name)
    {
        try
        {
            Log($"Clicking on the {type} {name}.");

            switch (type, name)
            {
                case ("MainPage", "EarthTour"):
                    mainPage.ClickTour();
                    break;
                case ("TourPage", _):
                    tourPage.ClickOnTour(name);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        catch (Exception ex)
        {
            LogException(ex, $"Clicking on the {type} {name}");
            throw;
        }
    }

    [When(@"Select More ""(.*)""")]
    public void GivenSelectSalutation(string moreName)
    {
        try
        {
            Log($"Selecting more: {moreName}.");
            mainPage.SelectMore(moreName);
        }
        catch (Exception ex)
        {
            LogException(ex, $"Selecting more '{moreName}'");
            throw;
        }
    }

    [Then(@"Header ""(.*)"" is displayed")]
    public void ThenSuccessMessageIsDisplayed(string expText)
    {
        try
        {
            Log($"Verifying header: '{expText}'.");

            Func<string> verAct = expText switch
            {
                "Earth Outreach" => verificationPage.GetOutreachHeader,
                "Take a tour in Google Earth" => verificationPage.GetEarthNight,
                _ => throw new ArgumentOutOfRangeException(nameof(expText), expText, null)
            };
            
            VerifyWorker.Equals(
                exp: expText,
                act: verAct,
                message: $"Current header should be '{expText}'"
            );
        }
        catch (Exception ex)
        {
            LogException(ex, $"Verifying headere '{expText}'");
            throw;
        }
    }
}