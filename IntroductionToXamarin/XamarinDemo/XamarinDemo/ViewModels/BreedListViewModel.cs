using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinDemo.Models;
using System.Linq;

namespace XamarinDemo.ViewModels
{
    public class BreedListViewModel : BaseViewModel
    {
        private List<Breed> _breeds;
        public List<Breed> Breeds
        {
            get { return _breeds; }
            set
            {
                if (_breeds == value)
                    return;
                _breeds = value;
                OnPropertyChanged();
            }
        }

        private Breed _selectItem;
        public Breed SelectItem {
            get { return _selectItem; }
            set {
                if (_selectItem == value) {
                    return;
                }
                _selectItem = value;
                OnPropertyChanged(nameof(SelectItem));
            }
        }

        private HttpClient _client;
        public BreedListViewModel()
        {
            _client = new HttpClient();

            Task.Run(async () =>
            {
                var items = await GetBreedsAsync();

                Breeds = items;
            });

        }

        public async Task<List<Breed>> GetBreedsAsync()
        {
            var uri = new Uri("https://dog.ceo/api/breeds/list/all");
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var message = JsonConvert.DeserializeObject<BreedsListResponse>(content);

                var items = JObject.Parse(message.Message.ToString());
                var breedsList = items.ToObject<Dictionary<string, object>>();
                var breeds = breedsList.Keys.Select(name => new Breed { Name = name }).ToList();
                return breeds;
            }
            return null;
        }
    }
}
