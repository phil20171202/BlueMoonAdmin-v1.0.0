using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ApplicationDbContext _db;

        public CalendarService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<EngineersViewModel> GetEngineersList()
        {
            var engineers = (from user in _db.Users
                             select new EngineersViewModel
                             {
                                 Id = user.Id,
                                 Name = user.FirstName
                             }
                             ).ToList();

            return engineers;
 
        }

        public List<CustomerServiceViewModel> GetCustomerServiceList()
        {
            throw new NotImplementedException();
        }
    }
}
