using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Data
{
    public class Department : IEquatable<Department>, INotifyPropertyChanged
    {
        private string nameDepartment;

        public string NameDepartment 
        {   get { return nameDepartment; }
            set { nameDepartment = value; NotifyPropertyChanged(); } 
        }

        public Department(string name)
        {
            NameDepartment = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(Department other)
        {
            return this.NameDepartment == other.NameDepartment;
        }
    }
}
