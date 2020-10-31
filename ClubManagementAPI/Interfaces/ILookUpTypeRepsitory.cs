using ClubManagementAPI.Helpers.Enum;
using ClubManagementAPI.Models.LookUP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Interfaces
{
    public interface ILookUpTypeRepsitory
    {
        Task<List<TypeOfCar>> GetTypeOfCar();

        Task<List<Nationality>> GetNationalities();

        Task<IEnumerable<dynamic>> GetLookUpsCascading(int id, int lookUpType);

        //dynamic or object
        Task<Dictionary<string, IEnumerable<dynamic>>> GetLookUps();
    }
}
