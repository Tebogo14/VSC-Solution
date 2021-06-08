using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC.Entityframeworkcore.EntityFramework;
using VSC.Entityframeworkcore.Models;

namespace VSC_Solution.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly VSCDbContext _context;

        public CustomerService(VSCDbContext context)
        {
            _context = context;
        }

        public List<Entity> GetAllClients()
        {
            return _context.Entities.ToList();
        }

        public Entity GetClient(int id)
        {
            return _context.Entities.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactPerson> GetContactPeople(int entityId)
        {
            return _context.ContactPeople.Where(x => x.EntityId == entityId).ToList();
        }

        public void UpdateEntity(Entity entity)
        {
            var existingEntity = _context.Entities.FirstOrDefault(x => x.Id == entity.Id);

            existingEntity.Location = entity.Location;
            existingEntity.Name = entity.Name;
            existingEntity.Type = entity.Type;
            existingEntity.AccountNumber = entity.AccountNumber;


            _context.SaveChanges();
        }

        public void UpdatePerson(ContactPerson contactPerson)
        {
            var person = _context.ContactPeople.FirstOrDefault(x => x.Id == contactPerson.Id);

            person.Name = contactPerson.Name;
            person.Surname = contactPerson.Surname;
            person.Email = contactPerson.Email;
            person.Number = contactPerson.Number;

            _context.SaveChanges();
        }

        public void DeleteEntity(int id)
        {
            var existingEntity = _context.Entities.Include(x => x.ContactPeople).FirstOrDefault(x => x.Id == id);


            _context.Entities.Remove(existingEntity);

            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.ContactPeople.FirstOrDefault(x => x.Id == id);

            _context.ContactPeople.Remove(person);

            _context.SaveChanges();
        }
    }
}
