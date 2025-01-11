using LogisticaProject.BL.DTOs;
using LogisticaProject.Core.Entities;

namespace LogisticaProject.BL.Services.Abstractions
{
    public interface ITransportService
    {
        Task<List<Transport>> GetAllAsync();
        Task<Transport> GetByIdAsync(int id);
        Task<Transport> CreateAsync(TransportDto transportDto);
        Task<Transport> UpdateAsync(int id, TransportDto transportDto);
        Task<Transport> SoftDeleteAsync(int id);

    }
}
