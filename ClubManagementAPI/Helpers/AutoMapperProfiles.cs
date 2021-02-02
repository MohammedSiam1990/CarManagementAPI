using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubManagementAPI.Models;
using ClubManagementAPI.Dto;
using CarManagementAPI.Dto.QueryDto;

namespace ClubManagementAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<CarCardCreationDto, CarCard>();
        }
    }
}
