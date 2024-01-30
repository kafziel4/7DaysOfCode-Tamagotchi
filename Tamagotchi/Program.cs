using RestSharp;
using System.Text.Json;
using Tamagotchi.Models;

var id = 0;

while (id == 0)
{
    DisplayChoosePokemonMenu();

    var choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
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
            DisplayErrorMessage();
            break;
    }

    if (id == 0)
        continue;

    var pokemon = await GetPokemon(id);

    if (pokemon is null)
    {
        DisplayErrorMessage("Erro ao obter Pokémon");
        id = 0;
        continue;
    }

    Console.WriteLine(pokemon);

    var confirmation = "";

    while (confirmation != "s" && confirmation != "n")
    {
        Console.Write("Escolher outro Pokémon? [S/N] ");

        confirmation = Console.ReadLine()?.ToLower();
        Console.WriteLine();

        switch (confirmation)
        {
            case "s":
                id = 0;
                break;
            case "n":
                DisplayEndOfProgram();
                return;
            default:
                DisplayErrorMessage();
                break;
        }
    }
}

static void DisplayChoosePokemonMenu()
{
    Console.WriteLine("1. Bulbasaur");
    Console.WriteLine("2. Charmander");
    Console.WriteLine("3. Squirtle");
    Console.WriteLine("4. Pikachu");
    Console.WriteLine();
    Console.Write("Escolha um Pokémon: ");
}

static void DisplayErrorMessage(string message = "Escolha inválida")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.WriteLine();
    Console.ResetColor();
}

static async Task<Pokemon?> GetPokemon(int id)
{
    var client = new RestClient("https://pokeapi.co/api/v2/");
    var request = new RestRequest($"pokemon/{id}");
    var response = await client.ExecuteAsync(request);

    if (response.Content is null)
        return null;

    return JsonSerializer.Deserialize<Pokemon>(
            response.Content, new JsonSerializerOptions(JsonSerializerDefaults.Web));
}

static void DisplayEndOfProgram()
{
    Console.WriteLine("Pressione qualquer tecla para continuar.");
    Console.ReadKey();
}