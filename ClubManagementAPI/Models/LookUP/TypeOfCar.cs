using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Models.LookUP
{
    public class TypeOfCar
    {
        [Key]
        public int ID { get; set; }
        public string CarName { get; set; }

    }
}
