using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;

namespace MyRestaurant.ViewModel.PagesVM
{
    public class ProfileVM : ViewModelBase
    {
        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set
            {
                currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");
            }
        }
        public ProfileVM(Employee employee)
        {
            CurrentEmployee = employee;
        }
    }
}
