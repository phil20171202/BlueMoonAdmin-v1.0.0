using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class UploadViewModel
    {
        public List<Customers> CustomersList { get; set; }

        public List<MonthlySales> SalesList { get; set; }

    }
}
