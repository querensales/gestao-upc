using AppService.Domain.Registration.Request;
using AppService.Domain.Registration.Response;

namespace AppService.Domain;

public interface IRecordService
{
    Task AddRecordAsync(AddRecordRequest request);
    Task UpdateRecordAsync(UpdateRecordRequest request);
    Task DeleteRecordAsync(Guid id);
    Task<RecordResponse> GetRecordByIdAsync(Guid id);
    Task<List<RecordResponse>> GetAllRecordsAsync();
    // Métodos para listagem e consulta podem ser adicionados futuramente
} 