using System.Text;

namespace Tamagotchi.Entites;

public class Mascot
{
    private const int MinAttributeValue = 0;
    private const int MaxAttributeValue = 10;
    private const int AttributeThreshold = 5;

    private static readonly Random _random = new();

    public string Name { get; private set; }
    public double Height { get; private set; }
    public double Weight { get; private set; }
    public List<string> Types { get; private set; } = [];
    public List<string> Abilities { get; private set; } = [];
    public bool Hatched { get; private set; }
    public int Satiety { get; private set; }
    public int Energy { get; private set; }
    public int Mood { get; private set; }

    public Mascot(string name)
    {
        Name = name.ToUpper();
        Satiety = _random.Next(MinAttributeValue, MaxAttributeValue + 1);
        Energy = _random.Next(MinAttributeValue, MaxAttributeValue + 1);
        Mood = _random.Next(MinAttributeValue, MaxAttributeValue + 1);
    }

    public void Hatch()
    {
        Hatched = true;
    }

    public void Feed()
    {
        Satiety = Increase(Satiety);
        Energy = Reduce(Energy);
    }

    public void Sleep()
    {
        Energy = Increase(Energy);
        Mood = Reduce(Mood);
    }

    public void Play()
    {
        Mood = Increase(Mood);
        Satiety = Reduce(Satiety);
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"NOME: {Name}");
        stringBuilder.AppendLine($"ALTURA: {Height / 10:N1} M");
        stringBuilder.AppendLine($"PESO: {Weight / 10:N1} KG");

        stringBuilder.AppendLine("TIPO:");
        stringBuilder.AppendLine($"  {string.Join(", ", Types)}");

        stringBuilder.AppendLine("HABILIDADES:");
        stringBuilder.AppendLine($"  {string.Join(", ", Abilities)}");

        stringBuilder.AppendLine($"{Name} ESTÁ {(Satiety < AttributeThreshold ? "COM FOME" : "ALIMENTADO")}!");
        stringBuilder.AppendLine($"{Name} ESTÁ {(Mood < AttributeThreshold ? "TRISTE" : "FELIZ")}!");
        stringBuilder.Append($"{Name} ESTÁ {(Energy < AttributeThreshold ? "COM SONO" : "DESCANSADO")}!");

        return stringBuilder.ToString();
    }

    private static int Increase(int value) => Math.Min(MaxAttributeValue, value + 2);

    private static int Reduce(int value) => Math.Max(MinAttributeValue, value - 1);
}
