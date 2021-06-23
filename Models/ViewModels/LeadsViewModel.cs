using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class LeadsViewModel
    {
        public Leads Leads { get; set; }
        public IEnumerable<Notes> Notes { get; set; }
    }
}
