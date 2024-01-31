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

        stringBuilder.AppendLine($"NOME: {Name.ToUpper()}");
        stringBuilder.AppendLine($"ALTURA: {Height}");
        stringBuilder.AppendLine($"PESO: {Weight}");

        stringBuilder.AppendLine("TIPO:");
        stringBuilder.AppendLine($"  {string.Join(", ", Types.Select(t => t.Type.Name.ToUpper()))}");

        stringBuilder.AppendLine("HABILIDADES:");
        stringBuilder.AppendLine($"  {string.Join(", ", Abilities.Select(a => a.Ability.Name.ToUpper()))}");

        return stringBuilder.ToString();
    }
}