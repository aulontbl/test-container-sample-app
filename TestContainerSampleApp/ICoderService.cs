namespace TestContainerSampleApp;

public interface ICoderService
{
    Task<IEnumerable<CoderDto>> GetAllCoders();
    Task<CoderDto?> GetCoderById(Guid id);
    Task<CoderDto> CreateCoder(CreateCoderDto coder);
    Task<CoderDto> UpdateCoder(Guid id, CoderDto coder);
    Task DeleteCoder(Guid id);
}