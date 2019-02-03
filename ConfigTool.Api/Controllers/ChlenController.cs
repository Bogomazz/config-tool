using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ConfigTool.Api.Models;
using ConfigTool.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ConfigTool.Api.Controllers
{
  [Route("chlens")]
  public class ChlenController
  {
    private readonly IMapper _mapper;
    private readonly IChlenRepository _chlenRepository;

    public ChlenController(IChlenRepository chlenRepository, IMapper mapper)
    {
      _chlenRepository = chlenRepository;
      _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<List<ChlenResponseModel>> Get()
    {
      return _mapper.Map<List<ChlenResponseModel>>(await _chlenRepository.GetAllAsync());
    }
  }
}