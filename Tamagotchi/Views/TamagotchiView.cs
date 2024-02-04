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
  |___|  |__| |__||_|   |_||__| |__||_______||_______|  |___|  |_______||__| |__||___| ";

        DisplayWithColor(header, ConsoleColor.Blue);
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

        Console.WriteLine($"{mascotOptions.Count + 1} - VOLTAR");
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

    public static void DisplayErrorMessage(string error)
    {
        Console.WriteLine();
        DisplayWithColor(error, ConsoleColor.Red);
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
          ████████          ";

        DisplayWithColor(egg, ConsoleColor.Yellow);
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

        Console.WriteLine($"{mascots.Count + 1} - VOLTAR");
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
          ████████          ";

        DisplayWithColor(hatchedEgg, ConsoleColor.Yellow);
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

    public static void DisplayFeedMessage(User user, Mascot mascot) =>
        DisplayInteractionMessage("\\(^O^)/", $"{user}, VOCÊ ALIMENTOU O {mascot.Name}!");

    public static void DisplayPlayMessage(User user, Mascot mascot) =>
        DisplayInteractionMessage("\\(^-^)/", $"{user}, VOCÊ BRINCOU COM O {mascot.Name}!");

    public static void DisplaySleepMessage(User user, Mascot mascot) =>
        DisplayInteractionMessage("<(^_^)>", $"{user}, VOCÊ COLOCOU O {mascot.Name} PARA DORMIR!");

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
        DisplayWithColor("OPÇÃO INVÁLIDA, TENTE NOVAMENTE!", ConsoleColor.Red);
    }

    private static void DisplayWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    private static void DisplayInteractionMessage(string emoticon, string message)
    {
        Console.WriteLine();
        DisplayWithColor(emoticon, ConsoleColor.Green);
        Console.WriteLine(message);
    }

    private static string PadCenter(string text = "", int length = 60)
    {
        var paddingChar = '-';
        int spaces = length - text.Length;
        int padLeft = spaces / 2 + text.Length;
        return text.PadLeft(padLeft, paddingChar).PadRight(length, paddingChar);
    }
}
