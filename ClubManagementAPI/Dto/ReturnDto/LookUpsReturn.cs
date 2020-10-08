using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagementAPI.Dto.ReturnDto
{
    public class LookUpsReturn
    {
        public Dictionary<string, IEnumerable<object>> LookUps { get; set; }
    }
}
