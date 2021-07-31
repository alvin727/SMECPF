using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DadCPFApp.ViewModel;
using DadCPFApp.Model;

namespace DadCPFApp
{
    /// <summary>
    /// Interaction logic for EmployeeAdmin.xaml
    /// </summary>
    public partial class EmployeeAdmin : UserControl
    {
        public EmployeeAdmin()
        {
            InitializeComponent();
            this.DataContext = new EmployeeAdminVM();
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAdminVM vm = ((EmployeeAdminVM)this.dgMain.DataContext);
            vm.MySelectedItem = vm.Employees.First<Employee>();
            //this.dgMain.SelectedIndex =
            //        ((EmployeeAdminVM)this.dgMain.DataContext).Employees.Count;
            //this.dgMain.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
        }
    }
}
