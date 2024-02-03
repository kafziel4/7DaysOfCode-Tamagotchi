using Tamagotchi.Entites;

namespace Tamagotchi.Config;

public static class MascotConfig
{
    public static IEnumerable<MascotOption> MascotOptions { get; private set; } =
        [
            new(1, "BULBASAUR"),
            new(4, "CHARMANDER"),
            new(7, "SQUIRTLE"),
            new(25, "PIKACHU")
        ];
}
