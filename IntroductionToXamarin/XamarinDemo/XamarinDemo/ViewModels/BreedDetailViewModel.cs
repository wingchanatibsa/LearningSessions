using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinDemo.Models;

namespace XamarinDemo.ViewModels
{
    public class BreedDetailViewModel: BaseViewModel
    {
        private readonly Breed _breed;
        private HttpClient _client;

        public BreedDetailViewModel(Breed breed)
        {
            _breed = breed;

            Title = breed.Name;

            _client = new HttpClient();

            Task.Run(async () => { 
                ImageUrl = await GetRandomDogImageUrl(breed.Name);
            });
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                if (_imageUrl == value)
                {
                    return;
                }
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }

        public async Task<string> GetRandomDogImageUrl(string breedName) {
            var uri = new Uri($"https://dog.ceo/api/breed/{breedName}/images/random");
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var message = JsonConvert.DeserializeObject<RandomImageResponse>(content);
                var imageUrl = message.Message;
               
                return imageUrl;
            }
            return null;
        }
    }
}
