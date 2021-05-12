using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMoonAdmin.Models
{
    public class ToDoListItem
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Date")]
        public DateTime ToDoDate { get; set; }

        [DisplayName("My Task")]
        public string ToDoTask { get; set; }

        [DisplayName("Completed")]
        public string Completed { get; set; }


    }
}
