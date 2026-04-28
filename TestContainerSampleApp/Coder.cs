namespace TestContainerSampleApp;

public class Coder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public string Architecture { get; set; }
    public bool IsVibeCoder { get; set; }
}

public class AdisCoder : Coder
{
    public AdisCoder()
    {
        IsVibeCoder = true;
    }
}