using LogisticaProject.Core.Entities;

namespace LogisticaProject.DAL.Repostories.Abstractions;

public interface IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
{
    Task<List<Tentity>> GetAllAsync();
    Task<Tentity> CreateAsync(Tentity entity);
    Task<Tentity> GetByIdAsync(int id);
    Task<Tentity> GetByIdForUpdateAsync(int id);

    Tentity SoftDelete(Tentity entity);
    Tentity Update(Tentity entity);
}
