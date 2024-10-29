using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;

namespace MyRestaurant.ViewModel.ModelsVM
{
    public class EmployeeVM : ViewModelBase
    {
        private Employee employee;
        public EmployeeVM(Employee emp)
        {
            employee = emp;
        }
        public int IdEmpoyee
        {
            get { return employee.IdEmployee; }
            set
            {
                employee.IdEmployee = value;
                OnPropertyChanged("IdEmpoyee");
            }
        }
        public string FullName
        {
            get { return employee.FullName; }
            set
            {
                employee.FullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string DateOfBirth
        {
            get { return employee.DateOfBirth; }
            set
            {
                employee.DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public string Passport
        {
            get { return employee.Passport; }
            set
            {
                employee.Passport = value;
                OnPropertyChanged("Passport");
            }
        }
        public string PhoneNumber
        {
            get { return employee.PhoneNumber; }
            set
            {
                employee.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string LoginEmployee
        {
            get { return employee.LoginEmployee; }
            set
            {
                employee.LoginEmployee = value;
                OnPropertyChanged("LoginEmployee");
            }
        }
        public string PasswordEmployee
        {
            get { return employee.PasswordEmployee; }
            set
            {
                employee.PasswordEmployee = value;
                OnPropertyChanged("PasswordEmployee");
            }
        }
        public int IdPosition
        {
            get { return employee.IdPosition; }
            set
            {
                employee.IdPosition = value;
                OnPropertyChanged("IdEmpoyee");
            }
        }
        public string NamePosition
        {
            get { return employee.NamePosition; }
            set
            {
                employee.NamePosition = value;
                OnPropertyChanged("NamePosition");
            }
        }
    }
}
