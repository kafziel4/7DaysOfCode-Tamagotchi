using Tamagotchi.Entites;

namespace Tamagotchi.Config;

public static class MascotConfig
{
    public static IEnumerable<MascotOption> MascotOptions { get; private set; } =
        [
            new(1, "bulbasaur"),
            new(4, "charmander"),
            new(7, "squirtle"),
            new(25, "pikachu")
        ];
}
