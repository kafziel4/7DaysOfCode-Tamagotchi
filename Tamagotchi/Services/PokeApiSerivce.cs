using RestSharp;
using System.Text.Json;
using Tamagotchi.Models;

namespace Tamagotchi.Services;

public static class PokeApiSerivce
{
    public static async Task<Pokemon?> GetPokemon(int id)
    {
        var client = new RestClient("https://pokeapi.co/api/v2/");
        var request = new RestRequest($"pokemon/{id}");
        var response = await client.ExecuteAsync(request);

        if (response.Content is null)
            return null;

        return JsonSerializer.Deserialize<Pokemon>(
            response.Content, new JsonSerializerOptions(JsonSerializerDefaults.Web));
    }
}
