using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class ToDoCategoryViewModel
    {
        public ToDoListItem Category { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
