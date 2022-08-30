using DotNetMauiDemo.Models;

namespace DotNetMauiDemo.Interfaces
{
    public interface IBreedService
    {
        Task<List<Breed>> GetBreedsAsync();

        Task<string> GetRandomDogImageUrl(string breedName);
    }

}

