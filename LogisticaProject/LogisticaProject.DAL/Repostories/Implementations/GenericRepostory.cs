using LogisticaProject.Core.Entities;
using LogisticaProject.DAL.Contexts;
using LogisticaProject.DAL.Repostories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LogisticaProject.DAL.Repostories.Implementations;

public class GenericRepostory<Tentity> : IGenericRepostory<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDbContext _context;
    public GenericRepostory(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<Tentity> Table => _context.Set<Tentity>();

    public async Task<List<Tentity>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    public async Task<Tentity> CreateAsync(Tentity entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    

    public async Task<Tentity> GetByIdAsync(int id)
    {
        return await Table.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<Tentity> GetByIdForUpdateAsync(int id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
    }

    public Tentity SoftDelete(Tentity entity)
    {
        entity.IsDeleted = true;
        return entity;
    }

    public Tentity Update(Tentity entity)
    {
        Table.Update(entity);
        return entity;
    }
}
