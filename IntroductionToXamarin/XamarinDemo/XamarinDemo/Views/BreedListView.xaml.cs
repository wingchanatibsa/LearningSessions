
using System;
using Xamarin.Forms;
using XamarinDemo.Models;
using XamarinDemo.ViewModels;

namespace XamarinDemo.Views
{
    public partial class BreedListView : ContentPage
    {
        public BreedListView()
        {
            InitializeComponent();

            Title = "Breed List";

            BindingContext = new BreedListViewModel();
        }

        public async void OnItemTapped(object sender, EventArgs args)
        {
            if (((ListView)sender).SelectedItem == null) return;

            var selectedItem = ((ListView)sender).SelectedItem as Breed;

            ((ListView)sender).SelectedItem = null;

            await Navigation.PushAsync(new BreedDetailView() { 
                BindingContext = new BreedDetailViewModel(selectedItem) 
            });

        }
    }
}
