using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        private int employeeId;
        private string name;

        public Employee(int employeeId, string name)
        {
            this.employeeId = employeeId;
            this.name = name;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string Name { get => name; set => name = value; }

        public override bool Equals(object? obj)
        {
            return obj is Employee employee &&
                   employeeId == employee.employeeId &&
                   name == employee.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(employeeId, name);
        }
    }
}
