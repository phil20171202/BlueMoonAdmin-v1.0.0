using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using System;
using System.Collections.Generic;

namespace BlueMoonAdmin.Controllers
{
    internal class ApplicationDBContext
    {
        public IEnumerable<ToDoListItem> ToDoListItems { get; internal set; }

        public static implicit operator ApplicationDBContext(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}