using System.Collections.Generic;
using System.Threading.Tasks;
using ConfigTool.Domain.Contract;
using ConfigTool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConfigTool.Controllers
{
  [Route("chlens")]
  public class ChlenController
  {
    private readonly IChlenRepository _chlenRepository;

    public ChlenController(IChlenRepository chlenRepository)
    {
      _chlenRepository = chlenRepository;
    }

    [HttpGet("")]
    public async Task<List<Chlen>> Get()
    {
      return await _chlenRepository.GetAllAsync();
    }
  }
}