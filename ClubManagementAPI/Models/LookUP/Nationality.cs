using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Models.LookUP
{
    public class Nationality
    {
        [Key]
        public int ID { get; set; }
        public string NationalityName { get; set; }
    }
}
