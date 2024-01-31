using Tamagotchi.Services;
using Tamagotchi.Views;

MainView.DisplayHeader();

while (string.IsNullOrEmpty(MainView.Username))
{
    MainView.GetUsername();
}

while (true)
{
    Console.WriteLine();
    var mainMenuOption = MainView.GetMainMenuOption();
    Console.WriteLine();

    switch (mainMenuOption)
    {
        case "1":
            await AdoptionMenuAsync();
            break;
        case "2":
            MainView.DisplayAdoptedPokemon();
            break;
        case "3":
            MainView.DisplayEndOfProgram();
            return;
    }
}

static async Task AdoptionMenuAsync()
{
    while (true)
    {
        var adoptionMenuOption = MainView.GetAdoptionMenuOption();
        Console.WriteLine();

        if (adoptionMenuOption > 0 && adoptionMenuOption <= MainView.PokemonOptions.Count)
        {
            var id = MainView.PokemonOptions[adoptionMenuOption - 1].Id;
            await ChoosePokemonMenuAsync(id);
            return;
        }
    }
}

static async Task ChoosePokemonMenuAsync(int id)
{
    while (true)
    {
        var choosePokemonMenuOption = MainView.GetChoosePokemonMenuOption(id);
        Console.WriteLine();

        switch (choosePokemonMenuOption)
        {
            case "1":
                var pokemon = await PokeApiSerivce.GetPokemon(id);
                Console.WriteLine(pokemon);
                break;
            case "2":
                MainView.AdoptPokemon(id);
                return;
            case "3":
                await AdoptionMenuAsync();
                return;
        }
    }
}

