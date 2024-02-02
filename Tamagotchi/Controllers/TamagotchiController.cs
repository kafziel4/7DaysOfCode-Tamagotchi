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
    private readonly List<Mascot> _mascots = [];

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
                    ChooseMascot();
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
                    _mascots.Add(new Mascot(pokemonChoice.Name));
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

    private void ChooseMascot()
    {
        while (true)
        {
            if (_mascots.Count == 0)
            {
                TamagotchiView.DisplayNoAdoptedMascotMessage(_user);
                return;
            }

            TamagotchiView.DisplayAdoptedMascotMenu(_mascots);
            var option = Console.ReadLine();

            if (int.TryParse(option, out var parsedOption) &&
                    parsedOption > 0 &&
                    parsedOption <= _mascots.Count)
            {
                var mascotChoice = _mascots[parsedOption - 1];
                InteractWithMascot(mascotChoice);
                return;
            }
            else
            {
                TamagotchiView.DisplayInvalidOptionMessage();
            }
        }
    }

    private void InteractWithMascot(Mascot mascot)
    {
        if (!mascot.Hatched)
        {
            mascot.Hatch();
            TamagotchiView.DisplayHatchMessage(_user, mascot);
        }

        while (true)
        {
            TamagotchiView.DisplayInteractionMenu(_user, mascot);
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TamagotchiView.DisplayMascotStatus(mascot);
                    break;
                case "2":
                    mascot.Feed();
                    TamagotchiView.DisplayFeedMessage(mascot);
                    break;
                case "3":
                    mascot.Play();
                    TamagotchiView.DisplayPlayMessage(mascot);
                    break;
                case "4":
                    mascot.Sleep();
                    TamagotchiView.DisplaySleepMessage(mascot);
                    break;
                case "5":
                    return;
                default:
                    TamagotchiView.DisplayInvalidOptionMessage();
                    break;
            }
        }
    }
}
