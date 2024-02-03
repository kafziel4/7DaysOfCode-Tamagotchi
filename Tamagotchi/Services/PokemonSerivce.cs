using RestSharp;
using Tamagotchi.Models;

namespace Tamagotchi.Services;

public class PokemonSerivce
{
    private readonly RestClientOptions _restClientOptions = new("https://pokeapi.co/api/v2/");

    public async Task<Pokemon?> GetPokemon(int id)
    {
        try
        {
            using var client = new RestClient(_restClientOptions);
            var request = new RestRequest($"pokemon/{id}");
            var response = await client.ExecuteAsync<Pokemon>(request);

            return response.Data;
        }
        catch
        {
            return null;
        }
    }
}
