using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models.ViewModels;
using BlueMoonAdmin.Utility;
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
                             join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                             join roles in _db.Roles.Where(x => x.Name == Helper.Engineer) on userRoles.RoleId equals roles.Id
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
            var customerServices = (from user in _db.Users
                                    join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                                    join roles in _db.Roles.Where(x => x.Name == Helper.CustomerService) on userRoles.RoleId equals roles.Id
                                    select new CustomerServiceViewModel
                                    {
                                        Id = user.Id,
                                        Name = user.FirstName
                                    }
                            ).ToList();

            return customerServices;

            throw new NotImplementedException();
        }
    }
}
