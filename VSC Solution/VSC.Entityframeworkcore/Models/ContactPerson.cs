using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VSC.Entityframeworkcore.Models
{
    public class ContactPerson
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public int EntityId { get; set; }
        public Entity Entity { get; set; }
    }
}
