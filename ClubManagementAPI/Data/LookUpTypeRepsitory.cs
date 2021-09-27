using CarManagementAPI.Dto.QueryDto;
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


        //public async Task<List<CarModel>> GetCarModel(int CarTypeId)
        //{
        //    var list = await _context.CarModels.Where(id => id.CarTypeID == CarTypeId).ToListAsync();
        //    return list();
        //}

        public async Task<IEnumerable<dynamic>> GetLookUpsCascading(int IDType, int lookUpType)
        {
            var lookup = (dynamic)null;
            switch (lookUpType)
            {
                case (int)LookUpType.CarModel:
                    lookup = await _context.CarModels.Where(id => id.CarTypeID == IDType).ToListAsync();
                    break;

            }
            
            return (dynamic)lookup;
        }

        public async Task<bool> AddNewItems(DefinitionLookupDto newitemlookup)
        {
            switch (newitemlookup.lookUpType)
            {
                case (int)LookUpType.TypeOfCar:
                    if (await _context.TypeOfCars.AnyAsync(x => x.CarName == newitemlookup.Description))
                        return true;
                    var typeOfCar = new TypeOfCar()
                    {
                        CarName = newitemlookup.Description
                    };
                    await _context.TypeOfCars.AddAsync(typeOfCar);
                    break;

                case (int)LookUpType.Nationality:
                    if (await _context.Nationalities.AnyAsync(x => x.NationalityName == newitemlookup.Description))
                        return true;
                    var nationality = new Nationality()
                    {
                        NationalityName = newitemlookup.Description
                    };
                   await _context.Nationalities.AddAsync(nationality);
                    break;

                case (int)LookUpType.CarModel:
                    if (await _context.CarModels.AnyAsync(x => x.ModelName == newitemlookup.Description) || await _context.CarModels.AnyAsync(x => x.CarTypeID == newitemlookup.OtherType))
                        return true;
                    var carModel = new CarModel()
                    {
                        CarTypeID = newitemlookup.OtherType,
                        ModelName = newitemlookup.Description
                    };
                    await _context.CarModels.AddAsync(carModel);
                    break;
            }
            await _context.SaveChangesAsync();
            return false;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
