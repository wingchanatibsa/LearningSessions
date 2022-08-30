namespace DotNetMauiDemo.ViewModels
{
    public partial class BreedListViewModel : BaseViewModel
    {
        IBreedService _breedService;

        public BreedListViewModel(IBreedService breedService)
        {
            _breedService = breedService;
            _breeds = new ObservableCollection<Breed>();

            Title = "Breeds";

            Task.Run(async() => await GetBreedsAsync());
            
        }

        [ObservableProperty]
        ObservableCollection<Breed> _breeds;

        [ObservableProperty]
        Breed _selectItem;

        [ObservableProperty]
        bool _isRefreshing;

        [RelayCommand]
        public async Task GetBreedsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var breeds = await _breedService.GetBreedsAsync();

                if (Breeds.Count != 0)
                {
                    Breeds.Clear();
                }

                foreach (var breed in breeds)
                {
                    Breeds.Add(breed);
                }
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
            
        }

        public async Task GoToDetailAsync(Breed breed)
        {
            if (breed == null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(BreedDetailView), true, new Dictionary<string, object> {
                { nameof(Breed), breed}
            });
        }

    }
}

