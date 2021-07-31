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

namespace DadCPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.Header.Visibility = Visibility.Collapsed;
            this.DG.Visibility = Visibility.Collapsed;
            this.EmpAdmin.Visibility= Visibility.Visible;
            this.CoAdmin.Visibility = Visibility.Collapsed;
        }

        private void btnCPF_Click(object sender, RoutedEventArgs e)
        {
            this.Header.Visibility = Visibility.Visible;
            this.DG.Visibility = Visibility.Visible;
            this.EmpAdmin.Visibility = Visibility.Collapsed;
            this.CoAdmin.Visibility = Visibility.Collapsed;
        }

        private void btnCompany_Click(object sender, RoutedEventArgs e)
        {
            this.DG.Visibility = Visibility.Collapsed;
            this.EmpAdmin.Visibility = Visibility.Collapsed;
            this.CoAdmin.Visibility = Visibility.Visible;
        }
    }
}
