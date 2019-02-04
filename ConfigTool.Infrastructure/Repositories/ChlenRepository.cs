using System.Collections.Generic;
using System.Threading.Tasks;
using ConfigTool.Domain.Contract;
using ConfigTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConfigTool.Infrastructure.Repositories
{
  public class ChlenRepository : IChlenRepository
  {
    private readonly ApplicationContext _context;

    public ChlenRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task<Chlen> FindAsync(int id, bool trackEntity = true)
    {
      return trackEntity
        ? await _context.Chlens.FindAsync(id)
        : await _context.Chlens.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }

    public async Task<List<Chlen>> GetAllAsync(bool trackEntities = true)
    {
      return trackEntities
        ? await _context.Chlens.ToListAsync()
        : await _context.Chlens.AsNoTracking().ToListAsync();
    }
  }
}