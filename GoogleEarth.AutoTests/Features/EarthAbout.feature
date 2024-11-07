Feature: EarthAbout

Scenario: Open Earth Outreach
    Given Navigate to the main page of the app
    When Select More "Earth Outreach"
    Then Header "Earth Outreach" is displayed

Scenario: Open Earth at Night
    Given Navigate to the main page of the app
    When Click on the "MainPage" "EarthTour"
    # When Click on the "TourPage" "Earth at Night"
    Then Header "Take a tour in Google Earth" is displayed