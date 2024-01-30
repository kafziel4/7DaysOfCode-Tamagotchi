using System.Text;

namespace Tamagotchi.Models;

public class Pokemon
{
    public string Name { get; set; } = string.Empty;
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonType> Types { get; set; } = [];
    public List<PokemonAbility> Abilities { get; set; } = [];

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Nome: {Name}");
        stringBuilder.AppendLine($"Altura: {Height}");
        stringBuilder.AppendLine($"Peso: {Weight}");

        stringBuilder.AppendLine("Tipo:");
        foreach (var pokemonType in Types)
        {
            stringBuilder.AppendLine($"  {pokemonType.Type.Name}");
        }

        stringBuilder.AppendLine("Habilidades:");
        foreach (var pokemonAbility in Abilities)
        {
            stringBuilder.AppendLine($"  {pokemonAbility.Ability.Name}");
        }

        return stringBuilder.ToString();
    }
}