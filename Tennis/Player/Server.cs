namespace Tennis.Player;

public class Server: IPlayer
{
    private readonly string _name;

    public Server(string name)
    {
        _name = name;
    }
}