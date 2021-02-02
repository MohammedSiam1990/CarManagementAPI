using CarManagementAPI.Helpers;
using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Data
{
    public class CarCardRepository : ICarCardRepository
    {
        private readonly DataContext _context;
        public CarCardRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void AddNewCarCard(dynamic newcarCard)
        {
            _context.CarCards.Add(newcarCard);
        }

        public async Task<dynamic> GetCarCard(int id)
        {
            return await _context.CarCards.FirstOrDefaultAsync(m => m.CarNumber == id);
        }

        public async Task<bool> CarCardExists(int carCardNumber)
        {
            if (await _context.CarCards.AnyAsync(x => x.CarNumber == carCardNumber))
                return true;
            return false;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteNewCarCard<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task<PageList<dynamic>> GetCarCards(CarCardParams carCardParams)
        //{
        //    var carCards = _context.CarCards.Include(c => c.CarNumber).AsQueryable();
        //    carCards = carCards.OrderByDescending(d => d.CarCarAdded);
        //    return await PageList<dynamic>.CreateAsync(carCards, carCardParams.PageNumber, carCardParams.PageSize);
        //}

        public async Task<PageList<dynamic>> GetCarCards(CarCardParams carCardParams)
        {
            var carCards = _context.CarCards.AsQueryable();
            //carCards = carCards.OrderByDescending(d => d.CarCarAdded);
            return await PageList<dynamic>.CreateAsync(carCards, carCardParams.PageNumber, carCardParams.PageSize);
        }



    }
}
