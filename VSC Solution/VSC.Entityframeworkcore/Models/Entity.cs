using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VSC.Entityframeworkcore.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public int Type { get; set; }

        [StringLength(225)]
        public string Location { get; set; }
        public List<ContactPerson> ContactPeople { get; set; }
    }
}
