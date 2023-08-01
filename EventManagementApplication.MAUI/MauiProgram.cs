﻿using EventManagementApplication.MAUI.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace EventManagementApplication.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterViewModel>();

            builder.Services.AddSingleton<EventSinglePage>();
            builder.Services.AddSingleton<EventViewModel>();

            return builder.Build();
        }
    }
}