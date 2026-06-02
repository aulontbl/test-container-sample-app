namespace TestContainerSampleApp;

public class Coder
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Language { get; set; }
    public virtual string Architecture { get; set; }
    public virtual bool IsVibeCoder { get; set; }
}

public class AdisCoder : Coder
{
    public AdisCoder()
    {
        IsVibeCoder = true;
    }
}

public record CoderDto(Guid Id, string Name, string Language, string Architecture, bool IsVibeCoder);
public record CreateCoderDto(string Name, string Language, string Architecture, bool IsVibeCoder);
public record UpdateCoderDto(string Language, string Architecture, bool IsVibeCoder);



public static class CoderExtensions
{
    public static CoderDto ToDto(this Coder coder)
    {
        return new CoderDto(coder.Id, coder.Name, coder.Language, coder.Architecture, coder.IsVibeCoder);
    }
    
    public static Coder ToEntity(this CoderDto coderDto)
    {
        return new Coder
        {
            Id = coderDto.Id,
            Name = coderDto.Name,
            Language = coderDto.Language,
            Architecture = coderDto.Architecture,
            IsVibeCoder = coderDto.IsVibeCoder
        };
    }
    
    public static Coder ToEntity(this CreateCoderDto coderDto)
    {
        return new Coder
        {
            Name = coderDto.Name,
            Language = coderDto.Language,
            Architecture = coderDto.Architecture,
            IsVibeCoder = coderDto.IsVibeCoder
        };
    }
}