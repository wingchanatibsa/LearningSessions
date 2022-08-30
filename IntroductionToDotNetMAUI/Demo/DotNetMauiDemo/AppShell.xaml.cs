namespace DotNetMauiDemo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(BreedDetailView), typeof(BreedDetailView));
	}
}

