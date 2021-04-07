using System.Collections.Generic;

namespace BlueMoonAdmin.Services
{
    public interface IEmployyeService
    {
        IEnumerable<BlueMoonAdmin.Models.Employee> GetAll();
    }
}