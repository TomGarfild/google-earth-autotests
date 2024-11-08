Feature: EarthAbout

Scenario: Open Earth Outreach
    Given Navigate to the main page of the app
    When Select More "Earth Outreach"
    Then Header "Earth Outreach" is displayed

Scenario: Open Earth at Night
    Given Navigate to the main page of the app
    When Click on the "MainPage" "tour in Google Earth"
    # When Click on the "TourPage" "Earth at Night"
    Then Header "Take a tour in Google Earth" is displayed

Scenario: Open earth studio
    Given Navigate to the main page of the app
    Given Select More "Earth Studio"
    When Click on the "StudioPage" "SignUp"
    Then Header "Sign in" is displayed