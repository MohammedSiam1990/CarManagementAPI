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

        public async Task<List<Nationality>> GetNationalities()
        {
            var list = await _context.Nationalities.ToListAsync();
            return list;
        }
        public async Task<List<TypeOfCar>> GetTypeOfCar()
        {
            var list = await _context.TypeOfCars.ToListAsync();
            return list;
        }

        public async Task<Dictionary<string, IEnumerable<dynamic>>> GetLookUps()
        {
            Dictionary<string, IEnumerable<dynamic>> lookup = new Dictionary<string, IEnumerable<dynamic>>();
            lookup.Add(LookUpType.TypeOfCar.ToString(), await _context.TypeOfCars.ToListAsync());
            lookup.Add(LookUpType.Nationality.ToString(), await _context.Nationalities.ToListAsync());
            //var list = await _context.TypeOfCars.ToListAsync();
            return lookup;
        }
    }
}
