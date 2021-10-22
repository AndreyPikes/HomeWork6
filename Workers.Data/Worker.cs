using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Workers.Data
{
    public class Worker : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private string position;
        private string comment;
        private bool secrecy;
        private Department department;

        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string Name
        {
            get { return name; }
            set { name = value;  NotifyPropertyChanged(); }
        }
        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged(); }
        }
        public string Position
        {
            get { return position; }
            set { position = value; NotifyPropertyChanged(); }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; NotifyPropertyChanged(); }
        }
        public bool Secrecy
        {
            get { return secrecy; }
            set { secrecy = value; NotifyPropertyChanged(); }
        }
        public Department Department
        {
            get { return department; }
            set { department = value; NotifyPropertyChanged(); }
        }

        public Worker () { }

        public Worker (string name, int age, string position, string comment, bool secrecy, Department department)
        {
            Name = name;
            Age = age;
            Position = position;
            Comment = comment;
            Secrecy = secrecy;
            Department = department;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
