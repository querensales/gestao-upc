using AppService.Domain;
using AppService.Domain.Registration.Request;
using AppService.Domain.Registration.Response;
using Repository;
using Repository.Entity;

namespace AppService.Application;

public class RecordService : IRecordService
{
    private readonly AppDbContext _appDbContext;
    public RecordService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddRecordAsync(AddRecordRequest request)
    {
        await _appDbContext.Record.AddAsync(new Record
        {
            Name = request.Name,
            SubCategoryId = request.SubCategoryId,
            AccountId = request.AccountId,
            // Value, Date, Description devem estar presentes na entidade Record
        });
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateRecordAsync(UpdateRecordRequest request)
    {
        var record = await _appDbContext.Record.FindAsync(request.Id);
        if (record is null) throw new Exception("Lançamento não encontrado");
        record = record with
        {
            Name = request.Name,
            SubCategoryId = request.SubCategoryId,
            AccountId = request.AccountId,
            // Value, Date, Description idem acima
        };
        _appDbContext.Record.Update(record);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteRecordAsync(Guid id)
    {
        var record = await _appDbContext.Record.FindAsync(id);
        if (record is null) throw new Exception("Lançamento não encontrado");
        _appDbContext.Record.Remove(record);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<RecordResponse> GetRecordByIdAsync(Guid id)
    {
        var record = await _appDbContext.Record.FindAsync(id);
        if (record is null) throw new Exception("Lançamento não encontrado");
        return new RecordResponse
        {
            Id = record.Id,
            Name = record.Name,
            SubCategoryId = record.SubCategoryId,
            AccountId = record.AccountId,
            // Value, Date, Description devem ser retornados se existirem na entidade Record
        };
    }

    public async Task<List<RecordResponse>> GetAllRecordsAsync()
    {
        return _appDbContext.Record.Select(record => new RecordResponse
        {
            Id = record.Id,
            Name = record.Name,
            SubCategoryId = record.SubCategoryId,
            AccountId = record.AccountId,
            // Value, Date, Description idem acima
        }).ToList();
    }
} 