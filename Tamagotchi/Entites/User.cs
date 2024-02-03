namespace Tamagotchi.Entites;

public class User
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = value.ToUpper();
    }

    public override string ToString()
    {
        return Name;
    }
}
