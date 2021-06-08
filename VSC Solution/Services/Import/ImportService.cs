using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VSC.Entityframeworkcore.EntityFramework;
using VSC.Entityframeworkcore.Models;

namespace VSC_Solution.Services.Import
{
    public class ImportService : IImportService
    {
        private readonly VSCDbContext _context;

        public ImportService(VSCDbContext context)
        {
            _context = context;
        }

        public string ImportData(string filePath)
        {
            var filedata = new List<string>();

            var lines = File.ReadAllLines(filePath).Select(x => x);

            filedata = lines.Skip(1).ToList();


            foreach (var item in filedata)
            {
                var items = item.Split(",").ToList();

                var entity = _context.Entities.Include(x => x.ContactPeople).FirstOrDefault(x => x.Name == items[0]);


                if (entity == null)
                {
                    var newEntity = new Entity
                    {
                        Name = items[0],
                        AccountNumber = items[1],
                        Type = Convert.ToInt32(items[2]),
                        Location = items[3].Replace("\"(","") + "," +items[4].Replace(")\"", ""),
                        ContactPeople = new List<ContactPerson>()
                    };

                    if(items[5] != "")
                    {
                        var contactPerson = new ContactPerson
                        {
                            Name = items[5],
                            Surname = items[6],
                            Number = items[7],
                            Email = items[8]
                        };

                        newEntity.ContactPeople.Add(contactPerson);
                    }

                    _context.Entities.Add(newEntity);
                }
                else
                {
                    var contactPerson = new ContactPerson
                    {
                        Name = items[5],
                        Surname = items[6],
                        Number = items[7],
                        Email = items[8]
                    };

                    entity.ContactPeople.Add(contactPerson);
                }

                _context.SaveChanges();
            }



           return "";
        }
    }
}
