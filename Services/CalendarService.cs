using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
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

        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));

            if(model!=null && model.Id > 0 )
            {
                //update
                return 1;
            }
            else
            {
                //create
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    EngineerId = model.EngineerId,
                    CustomerServiceId = model.CustomerServiceId,
                    IsEngineerApproved = model.IsEngineerApproved,
                    AdminId = model.AdminId
                };

                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
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
        {  // ServiceCustomers Table for the calendar to pull in service contract customers

            var customerServices = (from customer in _db.Customers
                                    join service in _db.ServiceCustomers on customer.Id equals service.CustomerId
                                    where service.Service
                                    select new CustomerServiceViewModel
                                    {
                                        Id = service.CustomerId.ToString(),
                                        Name = service.Customer.CompanyName
                                    }
                            ).ToList();

            return customerServices;

            throw new NotImplementedException();



            // User table link
            //var customerServices = (from user in _db.Users
            //                        join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
            //                        join roles in _db.Roles.Where(x => x.Name == Helper.CustomerService) on userRoles.RoleId equals roles.Id
            //                        select new CustomerServiceViewModel
            //                        {
            //                            Id = user.Id,
            //                            Name = user.FirstName
            //                        }
            //                ).ToList();

            //return customerServices;

            //throw new NotImplementedException();
        }

    }
}
