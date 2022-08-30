namespace DotNetMauiDemo.Views;

public partial class BreedDetailView : ContentPage
{
	public BreedDetailView(BreedDetailViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((BreedDetailViewModel)BindingContext).OnAppearing();
    }
}
