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
    public class EmployeeAdminVM : ObservableObject
    {
        private ICommand _addEmpCommand;
        private ICommand _delEmpCommand;
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
                    _employees = Services.Employees;
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

        }

        #endregion
    }
}
