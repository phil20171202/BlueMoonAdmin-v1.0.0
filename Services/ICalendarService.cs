using BlueMoonAdmin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Services
{
    public interface ICalendarService
    {
        public List<EngineersViewModel> GetEngineersList();
        public List<CustomerServiceViewModel> GetCustomerServiceList();
        public Task<int> AddUpdate(AppointmentViewModel model);
    }
}
