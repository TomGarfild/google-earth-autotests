﻿using GoogleEarth.AutoTests.Pages;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using ATFramework2._0;

namespace GoogleEarth.AutoTests;

public class DiSetup : DiSetupBase
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        CreateBaseServices(out var services);

        services
            .AddScoped<IMainPage, MainPage>()
            .AddScoped<IOutreachPage, OutreachPage>();

        return services;
    }
}