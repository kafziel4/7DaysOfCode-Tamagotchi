
namespace Tamagotchi.Views;

public static class MainView
{
    public static List<PokemonOption> PokemonOptions { get; set; } =
        [
            new PokemonOption { Id = 1, Name = "BULBASAUR" },
            new PokemonOption { Id = 4, Name = "CHARMANDER" },
            new PokemonOption { Id = 7, Name = "SQUIRTLE" },
            new PokemonOption { Id = 25, Name = "PIKACHU" },
        ];

    public static List<string> AdoptedPokemon { get; set; } = [];
    public static string? Username { get; set; }

    public static void DisplayHeader()
    {
        var header =
@"
 _______  _______  __   __  _______  _______  _______  _______  _______  __   __  ___  
|       ||   _   ||  |_|  ||   _   ||       ||       ||       ||       ||  | |  ||   | 
|_     _||  |_|  ||       ||  |_|  ||    ___||   _   ||_     _||       ||  |_|  ||   | 
  |   |  |       ||       ||       ||   | __ |  | |  |  |   |  |       ||       ||   | 
  |   |  |       ||       ||       ||   ||  ||  |_|  |  |   |  |      _||       ||   | 
  |   |  |   _   || ||_|| ||   _   ||   |_| ||       |  |   |  |     |_ |   _   ||   | 
  |___|  |__| |__||_|   |_||__| |__||_______||_______|  |___|  |_______||__| |__||___| 
";
        Console.WriteLine(header);
    }

    public static void GetUsername()
    {
        Console.WriteLine("QUAL É O SEU NOME?");
        Username = Console.ReadLine()?.ToUpper();
    }

    public static string? GetMainMenuOption()
    {
        Console.WriteLine(PadCenter(" MENU "));
        Console.WriteLine($"{Username}, VOCÊ DESEJA:");
        Console.WriteLine("1 - ADOTAR UM POKÉMON");
        Console.WriteLine("2 - VER SEUS POKÉMON");
        Console.WriteLine("3 - SAIR");

        return Console.ReadLine();
    }

    public static void DisplayAdoptedPokemon()
    {
        if (AdoptedPokemon.Count == 0)
            Console.WriteLine("VOCÊ AINDA NÃO TEM NENHUM POKÉMON");
        else
            Console.WriteLine(string.Join(", ", AdoptedPokemon));
    }

    public static int GetAdoptionMenuOption()
    {
        Console.WriteLine(PadCenter(" ADOTAR UM POKÉMON "));
        Console.WriteLine($"{Username}, ESCOLHA UM POKÉMON:");

        for (int i = 0; i < PokemonOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {PokemonOptions[i].Name}");
        }

        int.TryParse(Console.ReadLine(), out var parsedOption);
        return parsedOption;
    }

    public static string? GetChoosePokemonMenuOption(int id)
    {
        var pokemonName = PokemonOptions.First(p => p.Id == id).Name;
        Console.WriteLine(PadCenter());
        Console.WriteLine($"{Username}, VOCÊ DESEJA:");
        Console.WriteLine($"1 - SABER MAIS SOBRE O {pokemonName}");
        Console.WriteLine($"2 - ADOTAR O {pokemonName}");
        Console.WriteLine("3 - VOLTAR");

        return Console.ReadLine();
    }

    public static void AdoptPokemon(int id)
    {
        var pokemonName = PokemonOptions.First(p => p.Id == id).Name;
        AdoptedPokemon.Add(pokemonName);

        Console.WriteLine($"{Username}, MASCOTE ADOTADO COM SUCESSO!");
        Console.WriteLine("O OVO ESTÁ CHOCANDO");
        var egg =
@"
          ████████          
        ██        ██        
      ██            ██      
    ██                ██    
    ██                ██    
  ██                    ██  
  ██                    ██  
██                        ██
██                        ██
██                        ██
██                        ██
  ██                    ██  
  ██                    ██  
    ██                ██    
      ████        ████      
          ████████          
";
        Console.WriteLine(egg);
    }

    public static void DisplayEndOfProgram()
    {
        Console.WriteLine("PRESSIONE QUALQUER TECLA PARA SAIR");
        Console.ReadKey();
    }

    private static string PadCenter(string source = "", int length = 60)
    {
        var paddingChar = '-';
        int spaces = length - source.Length;
        int padLeft = spaces / 2 + source.Length;
        return source.PadLeft(padLeft, paddingChar).PadRight(length, paddingChar);

    }
}
