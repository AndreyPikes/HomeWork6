using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Workers.Data;

namespace Workers
{
    /// <summary>
    /// Логика взаимодействия для WorkerEditor.xaml
    /// </summary>
    public partial class WorkerEditor : Window
    {
        public Worker worker { get; set; } = new Worker();

        public WorkerEditor()
        {
            InitializeComponent();
            WorkerControl.Worker = worker;
            //WorkerControl.SetDefaultDepartment(); //чтобы невозможно было создать работника вообще без департамента
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //WorkerControl.UpdateWorker();
            DialogResult = true;
        }
    }
}
