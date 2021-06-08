using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC.Entityframeworkcore.Models;

namespace VSC_Solution.Services.Customer
{
    public interface ICustomerService
    {
        public List<Entity> GetAllClients();
        public Entity GetClient(int id);
        public List<ContactPerson> GetContactPeople(int entityId);
        public void UpdateEntity(Entity entity);
        public void DeleteEntity(int id);
        public void UpdatePerson(ContactPerson contactPerson);
        public void DeletePerson(int id);

    }
}
