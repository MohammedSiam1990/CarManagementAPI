using ClubManagementAPI.Helpers.Enum;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models.LookUP;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Data
{
    public class LookUpTypeRepsitory : ILookUpTypeRepsitory
    {
        private readonly DataContext _context;

        public LookUpTypeRepsitory(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Nationality>> GetNationalities(LookUpType lookUpType)
        {
            var list = await _context.Nationalities.ToListAsync();
            return list;
        }
       

        public async Task<List<TypeOfCar>> GetTypeOfCar(LookUpType lookUpType)
        {
            var list = await _context.TypeOfCars.ToListAsync();
            return list;
        }
    }
}
