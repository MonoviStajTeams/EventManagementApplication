﻿using EventManagementApplication.MAUI.Models.ViewModels;
using EventManagementApplication.MAUI.Pages;
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
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();

            builder.Services.AddSingleton<EventSinglePage>();
            builder.Services.AddSingleton<EventList>();
            builder.Services.AddSingleton<EventViewModel>();
            builder.Services.AddSingleton<InvitationViewModel>();
            builder.Services.AddSingleton<InvitationList>();


            return builder.Build();
        }
    }
}