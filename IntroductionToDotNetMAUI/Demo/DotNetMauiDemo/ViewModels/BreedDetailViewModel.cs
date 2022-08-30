namespace DotNetMauiDemo.ViewModels
{
    [QueryProperty(nameof(Breed), nameof(Breed))]
    public partial class BreedDetailViewModel : BaseViewModel
    {
        private IBreedService _breedService;

        public BreedDetailViewModel(IBreedService breedService)
        {
            _breedService = breedService;
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            Title = Breed.Name;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                ImageUrl = await _breedService.GetRandomDogImageUrl(Breed.Name);
            });
        }

        [ObservableProperty]
        Breed _breed;

        [ObservableProperty]
        string _title;

        [ObservableProperty]
        string _imageUrl;
    }
}

