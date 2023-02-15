using UniApi.Models;

namespace UniApi.Interfaces
{
    public interface IDecaniRepository
    {
        Task<List<Decan>> GetAllDecaniAsync();
        Task<Decan> GetDecanAsync(Guid id);
        Task<Decan> CreateDecanAsync(AddDecanRequest addRequest);
        Task<Decan> UpdateDecanAsync(UpdateDecanRequest updateRequest, Guid id);
        Task<Decan> DeleteDecanAsync(Guid id);
    }
}
