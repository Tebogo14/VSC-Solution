using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSC_Solution.Services.Customer.Dtos
{
    public class EntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public int Type { get; set; }
        public string Location { get; set; }
    }
}
