using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using platformService.Data;
using platformService.Dtos;
using platformService.Models;

namespace platformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatform()
        {
            Console.WriteLine("<---Get Platforms-->");
            var platforms = _repo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {

            var platforms = _repo.GetPlatformById(id);
            if (platforms != null)
                return Ok(_mapper.Map<PlatformReadDto>(platforms));
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatFormCreateDtos platFormCreateDtos)
        {
            var platformmodel=_mapper.Map<Platform>(platFormCreateDtos);
            _repo.CreatePlatForm(platformmodel);
            _repo.SaveChanges();


            var platformReddto=_mapper.Map<PlatformReadDto>(platformmodel);

            return CreatedAtRoute(nameof(GetPlatformById),new{Id = platformReddto.Id},platformReddto);

        }
    }
}