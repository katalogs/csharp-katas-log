namespace Tennis.Player;

public class Receiver: IPlayer
{
    private readonly string _name;

    public Receiver(string name)
    {
        _name = name;
    }
}