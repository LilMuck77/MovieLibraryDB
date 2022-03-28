﻿using MovieLibraryDB.Interfaces;
using MovieLibraryDB.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MovieLibraryDB;

/// <summary>
///     Used for registration of new interfaces
/// </summary>
internal class Startup
{
    public IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddFile("app.log");
        });

        // Add new lines of code here to register any interfaces and concrete services you create
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<IService, FileService>();
        //services.AddTransient<IService, JsonService>();
        services.AddTransient<IOrchestrator, OrchestratorService>();

        return services.BuildServiceProvider();
    }
}