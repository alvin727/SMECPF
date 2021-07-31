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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DadCPFApp.ViewModel;

namespace DadCPFApp
{
    /// <summary>
    /// Interaction logic for CompanyAdmin.xaml
    /// </summary>
    public partial class CompanyAdmin : UserControl
    {
        public CompanyAdmin()
        {
            InitializeComponent();
            this.DataContext = new CompanyAdminVM();
        }
    }
}
