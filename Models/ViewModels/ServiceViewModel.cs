using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class ServiceViewModel
    {
        public Customers CustomersVm { get; set; }

        public ServiceCustomer ServiceCustomer { get; set; }
        
        public IEnumerable<Notes> Notes { get; set; }
        public Notes Note { get; set; }

        //public IEnumerable<Appointment> Appointments { get; set; }

        //public ServiceHistory serviceHistory { get; set; }

        //public IEnumerable<ServiceHistory> serviceHistories { get; set; }

        public int LiveService { get; set; }
        public int Serviced { get; set; }

        public int Upcoming { get; set; }
        public int OverDue { get; set; }

        public IQueryable<ServiceViewModel> CustomerCombineService { get; set; }

    }
}
