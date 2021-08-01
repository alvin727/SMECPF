using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DadCPFApp.Model;
using DadCPFApp.ViewModel.UtilityClass;
using System.Text.Json;
using System.IO;


namespace DadCPFApp.ViewModel
{
    public class EmployeeAdminVM : ObservableObject
    {
        private ICommand _addEmpCommand;
        private ICommand _delEmpCommand;
        private ICommand _saveEmpCommand;
        private ObservableCollection<Employee> _employees =null;
        private Employee _selected = null;

        public int MySelectedIdx
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }
        
        public Employee MySelectedItem
        {
            get {
                return _selected; 
            }
            set
            {
                if (value!=_selected)
                {
                    _selected = value;
                }
                OnPropertyChanged("MySelectedItem");
            }
        }

        public EmployeeAdminVM()
        {
            Console.WriteLine("IN IN");
        }

        public ObservableCollection<Employee> Employees
        {
            get {
                if (_employees == null)
                {
                    byte[] allByt = File.ReadAllBytes(@"F:\Info.json");
                    var s = Encoding.Default.GetString(allByt);
                    this._employees = 
                        JsonSerializer.Deserialize<ObservableCollection<Employee>>(s);
                }
                return _employees;
            }
            set
            {
                if (value!=_employees)
                {
                    _employees = value;
                }
                OnPropertyChanged("Employees");
            }
        }
#region ICommand
        public ICommand AddEmployeeCommand 
        { 
            get
            {
                if (_addEmpCommand == null)
                {
                    _addEmpCommand = new RelayCommand(
                        param => AddEmployee() //AddEmployee is the Handler
                    );
                }
                return _addEmpCommand;
            }
        }

        public ICommand DelEmployeeCommand
        {
            get
            {
                if (_delEmpCommand==null)
                {
                    _delEmpCommand = new RelayCommand(
                            new Action<object>(DelEmployee), //Strange..
                            param => this._selected!=null
                        );
                }
                return _delEmpCommand;
            }
        }

        public ICommand SaveEmployees
        {
            get
            {
                if(_saveEmpCommand==null)
                {
                    _saveEmpCommand = new RelayCommand(
                        param => this.SaveEmployeesToFile());
                }

                return _saveEmpCommand;
            }
        }


#endregion

        #region Handler Functions
        private void AddEmployee()
        {
            Employee e = new PermEmployee();
            this._employees.Insert(0, e);
            int i = 1;
            foreach (Employee emp in _employees)
            {
                emp.SN = i;
                ++i;
            }
            Services.ReCalculate();                
            this.Employees = _employees;
            this.MySelectedItem = e;
        }

        private void DelEmployee(object sels)
        {
            if (this.MySelectedItem!=null)
            {
                this._employees.Remove(this.MySelectedItem);
            }
            OnPropertyChanged("Employees");
        }
        
        /// <summary>
        /// To Save the List of Employees
        /// </summary>
        public void SaveEmployeesToFile()
        {
            if (this._employees!=null)
            {
                using (FileStream fs = new FileStream(@"F:\Info.json", FileMode.Create))
                {
                    var json = JsonSerializer.Serialize(this._employees);
                    byte[] emps = Encoding.Default.GetBytes(json);
                    fs.Write(emps);
                    //foreach (Employee e in this._employees)
                    //{
                    //    string s = JsonSerializer.Serialize((PermEmployee)e);
                    //    byte[] emp = Encoding.Default.GetBytes(s);
                    //    fs.Write(emp);
                    //    fs.Write(Encoding.ASCII.GetBytes(Environment.NewLine));
                    //}
                }
                
            }
        }

        #endregion
    }
}
