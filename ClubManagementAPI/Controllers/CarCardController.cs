using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CarManagementAPI.Dto.QueryDto;
using CarManagementAPI.Helpers;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class CarCardController : ControllerBase
    {

        private readonly ICarCardRepository _repo;
        private readonly IMapper _mapper;
        public CarCardController(ICarCardRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        //[HttpGet("{id}", Name = "GetCarCard")]
        //[ActionName("GetCarCard")]
        [HttpGet("{Id}")]
        [ActionName(nameof(GetCarCard))]
        //[Route("{Id}/GetCarCard")]
        public async Task<IActionResult> GetCarCard(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var carCardFromRepo = await _repo.GetCarCard(id);

            if (carCardFromRepo == null)
                return NotFound();

            return Ok(carCardFromRepo);
        }

        [HttpPost("AddNewCarCard")]
        public async Task<IActionResult> AddNewCarCard(int userId, CarCardCreationDto carCardCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            if (carCardCreationDto.CarNumber.ToString() == null)
                return BadRequest("Could not find Car Number");

            if (await _repo.CarCardExists(carCardCreationDto.CarNumber))
                return BadRequest("CarNumber Already exists");


            var newCarCard = _mapper.Map<CarCard>(carCardCreationDto);

            _repo.Add(newCarCard);

            if (await _repo.SaveAll())
            {
                var newCarCardToReturn = _mapper.Map<CarCard>(newCarCard);
                return CreatedAtAction(nameof(GetCarCard), new { id = newCarCard.CarNumber }, newCarCardToReturn);
            }

            throw new Exception("Creating the Car Card failed on save");
        }

        [HttpGet("GetCarCards")]
        public async Task<IActionResult> GetCarCards(int userId, [FromQuery] CarCardParams carCardParams)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var carCardsFromRepo = await _repo.GetCarCards(carCardParams);

            var carCards = _mapper.Map<IEnumerable<dynamic>>(carCardsFromRepo);

            Response.AddPagination(carCardsFromRepo.CurrentPage, carCardsFromRepo.PageSize, carCardsFromRepo.TotalCount, carCardsFromRepo.TotalPages);

            return Ok(carCards);


        }
    }
}
