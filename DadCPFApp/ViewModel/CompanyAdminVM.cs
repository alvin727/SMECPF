using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DadCPFApp.Model;
using DadCPFApp.ViewModel.UtilityClass;

namespace DadCPFApp.ViewModel
{
    public class CompanyAdminVM : ObservableObject
    {
        private ObservableCollection<Company> companies = null;
        
        public ObservableCollection<Company> Companies 
        { 
            get
            {
                if (this.companies==null)
                {
                    companies = Services.Companies;
                }
                return companies;
            }
        }
    }
}
