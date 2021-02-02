using CarManagementAPI.Helpers;
using ClubManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Interfaces
{
    public interface ICarCardRepository
    {
        void Add<T>(T entity) where T : class;

        void AddNewCarCard(dynamic newcarCard);

        void DeleteNewCarCard<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<User> GetUser(int id);

        Task<bool> CarCardExists(int carCardNumber);

        Task<dynamic> GetCarCard(int id);

        Task<PageList<dynamic>> GetCarCards(CarCardParams carCardParams);

        //Task<User> GetUser(int id);

    }
}
