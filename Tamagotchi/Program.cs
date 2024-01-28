using RestSharp;
using System.Text.Json;

var id = 0;

while (id == 0)
{
    Console.WriteLine("Escolha um Pokémon:");
    Console.WriteLine("1. Bulbasaur");
    Console.WriteLine("2. Charmander");
    Console.WriteLine("3. Squirtle");
    Console.WriteLine("4. Pikachu");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            id = 1;
            break;
        case "2":
            id = 4;
            break;
        case "3":
            id = 7;
            break;
        case "4":
            id = 25;
            break;
        default:
            Console.WriteLine("Escolha inválida.");
            break;
    }
}

var client = new RestClient("https://pokeapi.co/api/v2/");
var request = new RestRequest($"pokemon/{id}");
var response = await client.ExecuteAsync(request);

if (response.Content is not null)
{
    using var jsonDocument = JsonDocument.Parse(response.Content);
    foreach (var property in jsonDocument.RootElement.EnumerateObject())
    {
        Console.WriteLine($"{property}");
    }
}

Console.WriteLine("Pressione qualquer tecla para continuar.");
Console.ReadKey();