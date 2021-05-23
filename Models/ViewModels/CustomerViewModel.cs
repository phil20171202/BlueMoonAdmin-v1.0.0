using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class CustomerViewModel
    {
        public Customers Customers { get; set; }
        public IEnumerable<Contacts> Contacts { get; set; }

        public IEnumerable<Notes> Notes { get; set; }

        public IEnumerable<Addresses> Addresses { get; set; }

        public ServiceCustomer ServiceCustomer { get; set; }
    }
}
