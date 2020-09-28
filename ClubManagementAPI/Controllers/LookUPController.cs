using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ClubManagementAPI.Dto;
using ClubManagementAPI.Helpers.Enum;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models.LookUP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagementAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("getLookUP")]
        public async Task<IActionResult> GetLookUP(int userId, LookUPDto lookUPDto)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();
            var lookup = new List<TypeOfCar>();
            //messageParams.userId = userId;
            switch (lookUPDto.LookUpType)
            {
                case LookUpType.TypeOfCar:
                    lookup = await _repo.GetTypeOfCar(lookUPDto.LookUpType);
                    break;
            }


            //var messageFromRepo = await _repo.GetTypeOfCar(lookUPDto.LookUpType);

            //var messages = _mapper.Map<IEnumerable<MessageToReturnDto>>(messageFromRepo);

            //Response.AddPagination(messageFromRepo.CurrentPage, messageFromRepo.PageSize, messageFromRepo.TotalCount, messageFromRepo.TotalPages);

            return Ok(lookup);


        }


    }
}

