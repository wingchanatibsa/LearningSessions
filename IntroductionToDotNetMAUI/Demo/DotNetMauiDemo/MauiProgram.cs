namespace DotNetMauiDemo;

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

		builder.Services.AddSingleton<IBreedService>(new BreedService());

		builder.Services.AddSingleton<BreedListViewModel>();
		builder.Services.AddSingleton<BreedListView>();

		builder.Services.AddTransient<BreedDetailViewModel>();
		builder.Services.AddTransient<BreedDetailView>();

		return builder.Build();
	}
}

