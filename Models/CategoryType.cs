using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models
{
    public class CategoryType
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Type Name")]
        public string CategoryTypeName { get; set; }

    }
}

