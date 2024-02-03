using Tamagotchi.Entites;
using Tamagotchi.Models;

namespace Tamagotchi.Views;

public static class TamagotchiView
{
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
        Console.Write(header);
    }

    public static void DisplayUsernameQuestion()
    {
        Console.WriteLine();
        Console.WriteLine("HEY! QUAL É O SEU NOME?");
    }

    public static void DisplayWelcomeMessage(User user)
    {
        Console.WriteLine();
        Console.WriteLine($"BEM-VINDO, {user}!");
    }

    public static void DisplayMainMenu(User user)
    {
        Console.WriteLine();
        Console.WriteLine(PadCenter(" MENU PRINCIPAL "));
        Console.WriteLine($"{user}, VOCÊ QUER:");
        Console.WriteLine("1 - ADOTAR UM POKÉMON");
        Console.WriteLine("2 - VER SEUS MASCOTES");
        Console.WriteLine("3 - SAIR");
    }

    public static void DisplayChoosePokemonMenu(User user, IList<MascotOption> mascotOptions)
    {
        Console.WriteLine();
        Console.WriteLine(PadCenter(" ESCOLHER POKÉMON "));
        Console.WriteLine($"{user}, ESCOLHA UM POKÉMON:");

        for (int i = 0; i < mascotOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {mascotOptions[i]}");
        }
    }

    public static void DisplayAdoptionMenu(User user, MascotOption mascotOption)
    {
        Console.WriteLine();
        Console.WriteLine(PadCenter(" ADOTAR POKÉMON "));
        Console.WriteLine($"{user}, VOCÊ QUER:");
        Console.WriteLine($"1 - SABER MAIS SOBRE O {mascotOption}");
        Console.WriteLine($"2 - ADOTAR O {mascotOption}");
        Console.WriteLine("3 - VOLTAR");
    }

    public static void DisplayGetPokemonErrorMessage()
    {
        Console.WriteLine();
        Console.WriteLine("ERRO AO OBTER DADOS DO POKEMON!");
    }

    public static void DisplayPokemon(Pokemon pokemon)
    {
        Console.WriteLine();
        Console.WriteLine(pokemon);
    }

    public static void DisplayAdoptionMessage(User user, MascotOption mascotOption)
    {
        Console.WriteLine();
        Console.WriteLine($"{user}, {mascotOption} ADOTADO COM SUCESSO!");
        Console.WriteLine("O OVO ESTÁ CHOCANDO:");
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
        Console.Write(egg);
    }

    public static void DisplayNoAdoptedMascotMessage(User user)
    {
        Console.WriteLine();
        Console.WriteLine($"{user}, VOCÊ AINDA NÃO TEM NENHUM POKÉMON!");
    }

    public static void DisplayAdoptedMascotMenu(IList<Mascot> mascots)
    {
        Console.WriteLine();
        Console.WriteLine(PadCenter(" ESCOLHER MASCOTE "));

        for (int i = 0; i < mascots.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {mascots[i].Name}");
        }
    }

    public static void DisplayHatchMessage(User user, Mascot mascot)
    {
        Console.WriteLine();
        Console.WriteLine($"{user}, {mascot.Name} SAIU DO OVO!");
        var hatchedEgg =
@"
          ████████          
        ██        ██        
      ██            ██      
    ██                ██    
    ██                ██    
  ██                    ██  
  ██      ██      ██    ██  
    ██  ██  ██  ██  ██  ██  
      ██      ██      ██    
  ██      ██      ██        
██  ██  ██  ██  ██  ██  ████
██    ██      ██      ██  ██
██                        ██
██                        ██
  ██                    ██  
  ██                    ██  
    ██                ██    
      ████        ████      
          ████████          
";
        Console.Write(hatchedEgg);
    }

    public static void DisplayInteractionMenu(User user, Mascot mascot)
    {
        Console.WriteLine();
        Console.WriteLine(PadCenter(" INTERAGIR COM MASCOTE "));
        Console.WriteLine($"{user}, VOCÊ QUER:");
        Console.WriteLine($"1 - SABER COMO O {mascot.Name} ESTÁ");
        Console.WriteLine($"2 - ALIMENTAR O {mascot.Name}");
        Console.WriteLine($"3 - BRINCAR COM O {mascot.Name}");
        Console.WriteLine($"4 - COLOCAR O {mascot.Name} PARA DORMIR");
        Console.WriteLine("5 - VOLTAR");
    }

    public static void DisplayMascotStatus(Mascot mascot)
    {
        Console.WriteLine();
        Console.WriteLine(mascot);
    }

    public static void DisplayFeedMessage(Mascot mascot)
    {
        Console.WriteLine();
        Console.WriteLine("\\(^O^)/");
        Console.WriteLine($"{mascot.Name} COMEU!");
    }

    public static void DisplayPlayMessage(Mascot mascot)
    {
        Console.WriteLine();
        Console.WriteLine("\\(^-^)/");
        Console.WriteLine($"{mascot.Name} BRINCOU!");
    }

    public static void DisplaySleepMessage(Mascot mascot)
    {
        Console.WriteLine();
        Console.WriteLine("<(^_^)>");
        Console.WriteLine($"{mascot.Name} DORMIU!");
    }

    public static void DisplayEndOfProgram(User user)
    {
        Console.WriteLine();
        Console.WriteLine($"ATÉ A PRÓXIMA, {user}!");
        Console.WriteLine("PRESSIONE QUALQUER TECLA PARA SAIR");
        Console.ReadKey();
    }

    public static void DisplayInvalidOptionMessage()
    {
        Console.WriteLine();
        Console.WriteLine("ESCOLHA INVÁLIDA!");
    }

    private static string PadCenter(string text = "", int length = 60)
    {
        var paddingChar = '-';
        int spaces = length - text.Length;
        int padLeft = spaces / 2 + text.Length;
        return text.PadLeft(padLeft, paddingChar).PadRight(length, paddingChar);
    }
}
