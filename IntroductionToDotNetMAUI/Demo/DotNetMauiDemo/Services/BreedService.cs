namespace DotNetMauiDemo.Services
{
    public class BreedService: IBreedService
    {
        private HttpClient _client;

        public BreedService()
        {
            _client = new HttpClient();
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

        public async Task<string> GetRandomDogImageUrl(string breedName)
        {
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

