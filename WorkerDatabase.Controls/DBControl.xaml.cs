using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Workers;
using Workers.Data;

namespace WorkerDatabase.Controls
{
    /// <summary>
    /// Логика взаимодействия для DBControl.xaml
    /// </summary>
    public partial class DBControl : UserControl, INotifyPropertyChanged
    {
        private Worker worker;
        private ObservableCollection<Department> departments;
        public Worker Worker
        {
            get { return worker; }
            set { worker = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Department> Departments
        {
            get { return departments; }
            set { departments = value; NotifyPropertyChanged(); }

        }

        //private WorkersDatabase workersDatabase = new WorkersDatabase();
        public DBControl()
        {
            InitializeComponent();
            DataContext = this;
            Departments = WorkersDatabase.ListDepartment;
            //cbxDepartment.ItemsSource = WorkersDatabase.ListDepartment;
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        /// <summary>
        /// извне устанавливаем дефолтный департамент, чтобы невозможно было создать работника вообще без департамента
        /// </summary>
        public void SetDefaultDepartment() 
        {
            //cbxDepartment.SelectedIndex = 0;
        }

        
        
        
    }
}
