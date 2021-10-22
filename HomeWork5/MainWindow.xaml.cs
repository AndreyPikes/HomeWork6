using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using Workers.Data;

namespace Workers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Worker> workers
        {
            get;
            set;
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            workers = WorkersDatabase.ListWorkers;

            WorkersListView.ItemsSource = WorkersDatabase.ListWorkers;

            DepartmentsCombobox.ItemsSource = WorkersDatabase.ListDepartment;

            CollectionView viewWorkers = (CollectionView)CollectionViewSource.GetDefaultView(WorkersListView.ItemsSource);
            viewWorkers.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (DepartmentsCombobox.SelectedItem as Department == null) return false;
            else return ((item as Worker).Department.NameDepartment == (DepartmentsCombobox.SelectedItem as Department).NameDepartment);
        }

        private void DepartmentsCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionView viewWorkers = (CollectionView)CollectionViewSource.GetDefaultView(WorkersListView.ItemsSource);
            viewWorkers.Refresh();
            if (e?.AddedItems.Count > 0) tbxDepartment.Text = ((Department)e.AddedItems[0]).NameDepartment;
            if (DepartmentsCombobox.SelectedIndex == 0)
            {
                tbxDepartment.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSave1.IsEnabled = false;
            }
                
            else
            {
                btnDelete.IsEnabled = true;
                tbxDepartment.IsEnabled = true;
                btnSave1.IsEnabled = true;
            }
                
        }

        private void WorkersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                WorkerControl.Worker = ((Worker)e.AddedItems[0]);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersListView.SelectedItems.Count < 1) return;
            if (MessageBox.Show("Вы действительно желаете удалить контакт?",
                "Удаление контакта", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                WorkersDatabase.ListWorkers.Remove((Worker)WorkersListView.SelectedItems[0]);
                DepartmentsCombobox_SelectionChanged(null, null);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersListView.SelectedItems.Count < 1) return;
            //WorkerControl.UpdateWorker();            
            DepartmentsCombobox_SelectionChanged(null,null);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WorkerEditor workerEditor = new WorkerEditor();
            if (workerEditor.ShowDialog() == true)
            {
                WorkersDatabase.ListWorkers.Add(workerEditor.worker);
            }
            DepartmentsCombobox_SelectionChanged(null, null);
        }

        private void btnSave1_Click(object sender, RoutedEventArgs e)
        {
            ((Department)DepartmentsCombobox.SelectedItem).NameDepartment = tbxDepartment.Text;
            DepartmentsCombobox.ItemsSource = null;
            DepartmentsCombobox.ItemsSource = WorkersDatabase.ListDepartment;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var worker in WorkersDatabase.ListWorkers)
            {
                if (worker.Department == (Department)DepartmentsCombobox.SelectedItem)
                {
                    worker.Department = WorkersDatabase.ListDepartment[0];
                }
            }

            WorkersDatabase.ListDepartment.Remove((Department)DepartmentsCombobox.SelectedItem);
            DepartmentsCombobox.ItemsSource = null;
            DepartmentsCombobox.ItemsSource = WorkersDatabase.ListDepartment;
            DepartmentsCombobox.SelectedIndex = 0;
        }

        private void btnAdd1_Click(object sender, RoutedEventArgs e)
        {
            WorkersDatabase.ListDepartment.Add(new Department("созданный департамент"));
            DepartmentsCombobox.ItemsSource = null;
            DepartmentsCombobox.ItemsSource = WorkersDatabase.ListDepartment;
            DepartmentsCombobox.SelectedIndex = WorkersDatabase.ListDepartment.Count - 1;
        }
    }
}
