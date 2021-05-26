using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class ServiceViewModel
    {
        public Customers customersVm { get; set; }

        // Dont think I am using theIeumerable now
        //public IEnumerable<ServiceCustomer> ServiceCustomers { get; set; }

        public ServiceCustomer ServiceCustomer { get; set; }
        
        public IEnumerable<Notes> Notes { get; set; }





    }
}
