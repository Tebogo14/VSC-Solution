using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSC_Solution.Services.Customer.Dtos
{
    public class ContactPersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public int EntityId { get; set; }
    }
}
