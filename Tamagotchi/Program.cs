using Tamagotchi.Controllers;
using Tamagotchi.Services;

var pokemonService = new PokemonSerivce();
var tamagotchiController = new TamagotchiController(pokemonService);

tamagotchiController.Start();
await tamagotchiController.Play();
tamagotchiController.Finish();
