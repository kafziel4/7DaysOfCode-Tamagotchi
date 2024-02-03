using AutoMapper;
using Tamagotchi.Entites;
using Tamagotchi.Services;
using Tamagotchi.Views;

namespace Tamagotchi.Controllers;

public class TamagotchiController
{
    private readonly PokemonSerivce _pokemonSerivce;
    private readonly IMapper _mapper;
    private readonly List<MascotOption> _mascotOptions;
    private readonly User _user = new();
    private readonly List<Mascot> _mascots = [];

    public TamagotchiController(
        PokemonSerivce pokemonSerivce,
        IMapper mapper,
        IEnumerable<MascotOption> mascotOptions)
    {
        _pokemonSerivce = pokemonSerivce;
        _mapper = mapper;
        _mascotOptions = mascotOptions.ToList();
    }

    public void Start()
    {
        TamagotchiView.DisplayHeader();

        var username = string.Empty;
        while (string.IsNullOrWhiteSpace(username))
        {
            TamagotchiView.DisplayUsernameQuestion();
            username = Console.ReadLine();
        }

        _user.Name = username;
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
        bool? isPokemonAdopted = false;
        while (isPokemonAdopted.HasValue && !isPokemonAdopted.Value)
        {
            TamagotchiView.DisplayChoosePokemonMenu(_user, _mascotOptions);
            var option = Console.ReadLine();

            if (int.TryParse(option, out var parsedOption) &&
                parsedOption > 0 &&
                parsedOption <= _mascotOptions.Count)
            {
                var pokemonChoice = _mascotOptions[parsedOption - 1];
                isPokemonAdopted = await AdoptPokemon(pokemonChoice);
            }
            else
            {
                TamagotchiView.DisplayInvalidOptionMessage();
            }
        }
    }

    private async Task<bool?> AdoptPokemon(MascotOption pokemonChoice)
    {
        var pokemon = await _pokemonSerivce.GetPokemon(pokemonChoice.Id);
        if (pokemon == null)
        {
            TamagotchiView.DisplayGetPokemonErrorMessage();
            return null;
        }

        while (true)
        {
            TamagotchiView.DisplayAdoptionMenu(_user, pokemonChoice);
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    TamagotchiView.DisplayPokemon(pokemon);
                    break;
                case "2":
                    var mascot = _mapper.Map<Mascot>(pokemon);
                    _mascots.Add(mascot);
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
