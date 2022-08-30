namespace DotNetMauiDemo.Views;

public partial class BreedListView : ContentPage
{
    public BreedListView(BreedListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
    }

    void OnItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        ((BreedListViewModel)BindingContext).GoToDetailAsync((e.SelectedItem as Breed));

#if ANDROID
        ((ListView)sender).SelectedItem = null;
#endif

    }
}
