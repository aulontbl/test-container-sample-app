using NHibernate;

namespace TestContainerSampleApp;

public class CoderService : ICoderService
{
    private readonly ISessionFactory _sessionFactory;
    
    public CoderService(ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;
    }

    public async Task<IEnumerable<CoderDto>> GetAllCoders()
    {
        using var session = _sessionFactory.OpenSession();
        using var tx = session.BeginTransaction();
        
        var coders = await session.QueryOver<Coder>().ListAsync();

        var query = coders.Select(x => x.ToDto());

        return query;
    }




    public async Task<CoderDto?> GetCoderById(Guid id)
    {
        using var session = _sessionFactory.OpenSession();
        using var tx = session.BeginTransaction();
        
        var coder = await session.GetAsync<Coder>(id);
        
        return coder?.ToDto();
    }

    public async Task<CoderDto> CreateCoder(CreateCoderDto coder)
    {
        using var session = _sessionFactory.OpenSession();
        using var tx = session.BeginTransaction();
        
        var entity = coder.ToEntity();
        
        await session.SaveAsync(entity);
        
        await tx.CommitAsync();
        
        return entity.ToDto();
    }

    public async Task<CoderDto> UpdateCoder(Guid id, CoderDto dto)
    {
        using var session = _sessionFactory.OpenSession();
        using var tx = session.BeginTransaction();
        
        var coder = await session.GetAsync<Coder>(id);

        dto.ToEntity();
        
        coder.Architecture = dto.Architecture;
        coder.IsVibeCoder = dto.IsVibeCoder;
        coder.Language = dto.Language;
        coder.Name = dto.Name;
        coder.Id = id;
        
        await session.UpdateAsync(coder);
        
        await tx.CommitAsync();
        
        return coder.ToDto();
    }
    
    public async Task DeleteCoder(Guid id)
    {
        using var session = _sessionFactory.OpenSession();
        using var tx = session.BeginTransaction();
        
        var coder = await session.GetAsync<Coder>(id);
        
        await session.DeleteAsync(coder);
        
        await session.FlushAsync();
        
        await tx.CommitAsync();
    }
    
}