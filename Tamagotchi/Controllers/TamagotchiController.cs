using Tamagotchi.Entites;
using Tamagotchi.Services;
using Tamagotchi.Views;

namespace Tamagotchi.Controllers;

public class TamagotchiController
{
    private readonly PokemonSerivce _pokemonSerivce;

    private readonly List<PokemonMascot> _pokemonMascots =
        [
            new PokemonMascot { Id = 1, Name = "BULBASAUR" },
            new PokemonMascot { Id = 4, Name = "CHARMANDER" },
            new PokemonMascot { Id = 7, Name = "SQUIRTLE" },
            new PokemonMascot { Id = 25, Name = "PIKACHU" },
        ];

    private readonly User _user = new();
    private readonly List<string> _adoptedPokemon = [];

    public TamagotchiController(PokemonSerivce pokemonSerivce)
    {
        _pokemonSerivce = pokemonSerivce;
    }

    public void Start()
    {
        TamagotchiView.DisplayHeader();

        var username = "";
        while (string.IsNullOrWhiteSpace(username))
        {
            TamagotchiView.DisplayUsernameQuestion();
            username = Console.ReadLine();
        }

        _user.Username = username.ToUpper();
        TamagotchiView.DisplayWelcomeMessage(_user);
    }

    public async Task Play()
    {
        while (true)
        {
            TamagotchiView.DisplayMainMenu(_user);
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ChoosePokemon();
                    break;
                case "2":
                    TamagotchiView.DisplayAdoptedPokemon(_user, _adoptedPokemon);
                    break;
                case "3":
                    return;
                default:
                    TamagotchiView.DisplayInvalidOptionMessage();
                    break;
            }
        }
    }

    public void Finish()
    {
        TamagotchiView.DisplayEndOfProgram(_user);
    }

    private async Task ChoosePokemon()
    {
        var isPokemonAdopted = false;
        while (!isPokemonAdopted)
        {
            TamagotchiView.DisplayChoosePokemonMenu(_user, _pokemonMascots);
            var option = Console.ReadLine();

            if (int.TryParse(option, out var parsedOption) &&
                parsedOption > 0 &&
                parsedOption <= _pokemonMascots.Count)
            {
                var pokemonChoice = _pokemonMascots[parsedOption - 1];
                isPokemonAdopted = await AdoptPokemon(pokemonChoice);
            }
            else
            {
                TamagotchiView.DisplayInvalidOptionMessage();
            }
        }
    }

    private async Task<bool> AdoptPokemon(PokemonMascot pokemonChoice)
    {
        while (true)
        {
            TamagotchiView.DisplayAdoptionMenu(_user, pokemonChoice);
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var pokemon = await _pokemonSerivce.GetPokemon(pokemonChoice.Id);
                    TamagotchiView.DisplayPokemon(pokemon);
                    break;
                case "2":
                    _adoptedPokemon.Add(pokemonChoice.Name);
                    TamagotchiView.DisplayAdoptionMessage(_user, pokemonChoice);
                    return true;
                case "3":
                    return false;
                default:
                    TamagotchiView.DisplayInvalidOptionMessage();
                    break;
            }
        }
    }
}
