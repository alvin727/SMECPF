using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DadCPFApp.Model;
using DadCPFApp.ViewModel.UtilityClass;
using System.IO;
using System.Text.Json;

namespace DadCPFApp.ViewModel
{
    public class CompanyAdminVM : ObservableObject
    {
        private ObservableCollection<Company> companies = null;
        private ICommand _saveCO = null;

        public ObservableCollection<Company> Companies 
        { 
            get
            {
                //this.companies = Services.Companies;

                if (this.companies==null)
                {
                    byte[] allByt = File.ReadAllBytes(@"F:\COs.json");
                    var s = Encoding.Default.GetString(allByt);
                    this.companies=
                        JsonSerializer.Deserialize<ObservableCollection<Company>>(s);
                    OnPropertyChanged("Companies");
                }
                return companies;
            }
            set
            {
                if (value != companies)
                {
                    companies = value;
                }
                OnPropertyChanged("Companies");
            }
            
        }


        public ICommand SaveCOs
        {
            get
            {
                if (_saveCO == null)
                {
                    _saveCO = new RelayCommand(
                        param => this.SaveCOsToFile());
                }

                return _saveCO;
            }
            
        }

        public void SaveCOsToFile()
        {
            using (FileStream fs = new FileStream(@"F:\COs.json", FileMode.Create))
            {
                var json = JsonSerializer.Serialize(this.companies);
                byte[] cos = Encoding.Default.GetBytes(json);
                fs.Write(cos);
            }
        }
    }
}
