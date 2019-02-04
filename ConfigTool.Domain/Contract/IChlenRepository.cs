using System.Collections.Generic;
using System.Threading.Tasks;
using ConfigTool.Domain.Entities;

namespace ConfigTool.Domain.Contract
{
  public interface IChlenRepository : IRepository<Chlen>
  {
    Task<List<Chlen>> GetAllAsync(bool trackEntities = true);
  }
}