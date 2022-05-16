using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.FrontendModel
{
    public class EmployeeFront : INotifyPropertyChanged

    {
        private int employeeId;
        private string name;

        public EmployeeFront(int employeeId, string name)
        {
            this.employeeId = employeeId;
            this.name = name;
        }

        public EmployeeFront()
        {
        }

        public int EmployeeId {
            get { return employeeId; }
            set {
                if (employeeId != value)
                {
                    employeeId = value;
                    RaisePropertyChanged("EmployeeId");
                }
            }
        }

        
        public string Name {
            get { return name; }
            set {
                if (name != value) { 
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is EmployeeFront front &&
                   employeeId == front.employeeId &&
                   name == front.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(employeeId, name);
        }
    }
}
