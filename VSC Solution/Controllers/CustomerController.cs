using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VSC.Entityframeworkcore.Models;
using VSC_Solution.Services.Customer;
using VSC_Solution.Services.Customer.Dtos;

namespace VSC_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("GetAllClients")]
        public List<EntityDto> GetAllClients()
        {

            var entity = _customerService.GetAllClients();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Entity, EntityDto>());
            var mapper = new Mapper(config);


            return mapper.Map<List<EntityDto>>(entity);
        }


        [HttpGet]
        [Route("GetClients")]
        public EntityDto GetClients(int id)
        {
            var entity = _customerService.GetClient(id);

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Entity, EntityDto>());
            var mapper = new Mapper(config);


            return mapper.Map<EntityDto>(entity);
        }

        [HttpGet]
        [Route("GetContactPerson")]
        public List<ContactPersonDto> GetContactPerson(int entityId)
        {
            var contactPeople = _customerService.GetContactPeople(entityId);

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<ContactPerson, ContactPersonDto>());
            var mapper = new Mapper(config);


            return mapper.Map<List<ContactPersonDto>>(contactPeople);
        }


        [HttpPut]
        [Route("UpdateClient")]
        public void UpdateClient(EntityDto entityDto)
        {
            var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<EntityDto, Entity>());
            var mapper = new Mapper(config);

            _customerService.UpdateEntity(mapper.Map<Entity>(entityDto));

        }

        [HttpDelete]
        [Route("DeleteClient")]
        public void DeleteClient(int id)
        {
            _customerService.DeleteEntity(id);
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public void UpdatePerson(ContactPersonDto contactPerson)
        {
            var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<ContactPersonDto, ContactPerson>());
            var mapper = new Mapper(config);

            _customerService.UpdatePerson(mapper.Map<ContactPerson>(contactPerson));

        }

        [HttpDelete]
        [Route("DeletePerson")]
        public void DeletePerson(int id)
        {
            _customerService.DeletePerson(id);
        }
    }
}