using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManagementAPI.Dto.QueryDto
{
    public class CarCardCreationDto
    {
        public int CarNumber { get; set; }
        public int TypeCar { get; set; }
        public string TypeCarName { get; set; }
        public int Nationality { get; set; }
        public string NationalityName { get; set; }
        public int CarModel { get; set; }
        public string CarModelName { get; set; }
        public int ScheduledCars { get; set; }
        public int ExistingCars { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public DateTime CarCarAdded { get; set; }
        public string Notes { get; set; }
    }
}
