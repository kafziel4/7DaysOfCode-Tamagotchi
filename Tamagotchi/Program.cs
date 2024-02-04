using AutoMapper;
using Tamagotchi.Config;
using Tamagotchi.Controllers;
using Tamagotchi.Profiles;
using Tamagotchi.Services;

try
{
    var config = new MapperConfiguration(cfg => cfg.AddProfile<MascotProfile>());
    var mapper = new Mapper(config);
    var pokemonService = new PokemonSerivce();
    var tamagotchiController = new TamagotchiController(pokemonService, mapper, MascotConfig.MascotOptions);

    tamagotchiController.Start();
    await tamagotchiController.Play();
    tamagotchiController.Finish();
}
catch
{
    Console.WriteLine("OCORREU UM ERRO DURANTE A EXECUÇÃO DO PROGRAMA E ELE PRECISOU SER TERMINADO");
    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA SAIR");
    Console.ReadKey();
}