using Onsidaca.Mobile;
using Onsidaca.Mobile.Services;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Maui.Core.Hosting;
using Onsidaca.Mobile.Models;
using CommunityToolkit.Maui;

namespace Onsidaca.MAU;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder.ConfigureSyncfusionCore();

        builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //builder.Services.AddSingleton<Database, Database>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<Pages.StartPage>();
        builder.Services.AddSingleton<DataService, DataService>();
        builder.Services.AddTransient<ConnectionService, ConnectionService>();
        //builder.Services.AddTransient<JsonApiResult, JsonApiResult>();

        return builder.Build();
	}
}
