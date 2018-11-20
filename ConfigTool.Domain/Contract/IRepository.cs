using System.Threading.Tasks;
using ConfigTool.Domain.Entities;

namespace ConfigTool.Domain.Contract
{
  public interface IRepository<T> where T : EntityBase
  {
    Task<T> FindAsync(int id, bool trackEntity = true);
    Task SaveAsync();
  }
}