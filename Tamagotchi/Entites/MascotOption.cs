namespace Tamagotchi.Entites;

public class MascotOption
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public MascotOption(int id, string name)
    {
        Id = id;
        Name = name.ToUpper();
    }

    public override string ToString()
    {
        return Name;
    }
}
