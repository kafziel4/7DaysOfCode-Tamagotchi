using RestSharp;
using Tamagotchi.Models;

namespace Tamagotchi.Services;

public class PokemonSerivce
{
    private readonly RestClientOptions _restClientOptions = new("https://pokeapi.co/api/v2/");

    public async Task<Result<Pokemon>> GetPokemon(int id)
    {
        using var client = new RestClient(_restClientOptions);
        var request = new RestRequest($"pokemon/{id}");
        var response = await client.ExecuteAsync<Pokemon>(request);

        if (!response.IsSuccessful || response.Data == null)
            return "Erro ao obter dados do Pokémon!";

        return response.Data;
    }
}
