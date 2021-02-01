using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManagementAPI.Dto.QueryDto
{
    public class DefinitionLookupDto
    {
        public int ID { get; set; }
        public int OtherType { get; set; }
        public int lookUpType { get; set; }
        public string Description { get; set; }
    }
}
