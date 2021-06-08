using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlueMoonAdmin.Models;

namespace BlueMoonAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ServiceCustomer> ServiceCustomers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Notes> Notes { get; set; }

        public DbSet<MonthlySales> MonthlySalesFigure { get; set; }

        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<TaskManagerEvent> TaskManagerEvents { get; set; }
        public DbSet<ToDoListItem> ToDoListItems { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }

        public DbSet<ServiceHistory> ServiceHistory { get; set; }

        public DbSet<Leads> Lead { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<BlueMoonAdmin.Models.Leads> Leads { get; set; }
    }
}