using System.Collections.Generic;
using System.IO;
using BlueMoonAdmin.Models;

namespace BlueMoonAdmin.Services
{
    public class EmployeeServices : IEmployyeService
    {
        public IEnumerable<BlueMoonAdmin.Models.Employee> GetAll()
        {
            List<BlueMoonAdmin.Models.Employee> empleados = new List<BlueMoonAdmin.Models.Employee>();
            var lineas = File.ReadAllLines("employees.csv");
            foreach (var linea in lineas)
            {
                if (linea.Length > 0)
                {
                    var valores = linea.Split(',');
                    Employee empleado = new Employee();
                    empleado.Name = valores[0];
                    empleado.Position = valores[1];
                    empleado.Office = valores[2];
                    empleado.Age = valores[3];
                    empleado.StartDate = valores[4];
                    empleado.Salary = valores[5];
                    empleados.Add(empleado);
                }
            }
            return empleados;
        }
    }
}