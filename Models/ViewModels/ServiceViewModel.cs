using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class ServiceViewModel
    {
        public Customers Customers { get; set; }

        // one to one Customer to service
        public IEnumerable<ServiceCustomer> ServiceCustomers { get; set; }

        public ServiceCustomer ServiceCustomer { get; set; }
        public int Overdue { get; set; }

        public IEnumerable<Notes> Notes { get; set; }

    }
}
