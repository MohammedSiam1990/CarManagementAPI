using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarManagementAPI.Dto.QueryDto;
using ClubManagementAPI.Dto;

using ClubManagementAPI.Dto.ReturnDto;
using ClubManagementAPI.Helpers.Enum;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models.LookUP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagementAPI.Controllers
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class LookUPController : ControllerBase
    {
        private readonly ILookUpTypeRepsitory _repo;
        private readonly IMapper _mapper;

        public LookUPController(ILookUpTypeRepsitory repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getLookUP")]
        public async Task<IActionResult> GetLookUP(int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            LookUpsReturn lookUpsReturn = new LookUpsReturn();
            //var lookup = new { };
            //or
            var lookups = (dynamic)null;
            lookUpsReturn.LookUps = await _repo.GetLookUps();
            lookups = lookUpsReturn.LookUps;
            //messageParams.userId = userId;
            //switch (lookUpType.LookUpType)
            //{
            //    case LookUpType.TypeOfCar:
            //        lookup = await _repo.GetTypeOfCar();
            //        break;
            //    case LookUpType.Nationality:
            //        lookup = await _repo.GetNationalities();
            //        break;
            //}
            return Ok(lookUpsReturn);
        }

        [HttpGet]
        [Route("{Id}/{lookUpType}/GetLookUPCascading")]
        public async Task<IActionResult> GetLookUPCascading(int userId, int Id, int lookUpType)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var lookup = (dynamic)null;

            lookup = await _repo.GetLookUpsCascading(Id, lookUpType);
            return Ok(lookup);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemslookUp(int userId, DefinitionLookupDto definitionLookup)
        {

            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();


            throw new Exception("Creating the Car Card failed on save");

        }
    }
}

