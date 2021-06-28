using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueMoonAdmin.Models
{
    public class MonthlySales
    {
        [Key]
        public int Id { get; set; }      

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }
    }

}

