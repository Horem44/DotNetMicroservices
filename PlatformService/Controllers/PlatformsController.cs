using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platforms = _platformRepository.GetAllPlarforms();
            var mappedPlatforms = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);

            return Ok(mappedPlatforms);
        }

        [HttpGet("{id:int}", Name = "GetPlatform")]
        public ActionResult<PlatformReadDto> GetPlatform([FromRoute] int id)
        {
            var platform = _platformRepository.GetPlatformById(id);

            return platform != null ? Ok(_mapper.Map<PlatformReadDto>(platform)) : NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformCreateDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);

            _platformRepository.CreatePlatform(platform);
            _platformRepository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            return CreatedAtRoute(
                nameof(GetPlatform),
                new { Id = platformReadDto.Id },
                platformReadDto
            );
        }
    }
}
