using MyRestaurant.Model;
using MyRestaurant.View.Pages;
using MyRestaurant.ViewModel.BaseVM;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.PagesVM
{
    public class ControlPagesVM : ViewModelBase
    {
        private Page Profile;
        private Page ProductsStock;
        private Page CreateApplication;
        private Page ProductsSupplies;
        private Page UsersList;
        private Page AddUser;
        public Window loginWindow;

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

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

        public ControlPagesVM(Employee employee, Window window)
        {
            CurrentEmployee = employee;

            Profile = new Profile();
            ProductsStock = new ProductsStock();
            CreateApplication = new CreateApplication();
            ProductsSupplies = new ProductsSupplies();
            UsersList = new UsersList();
            AddUser = new AddUser();
            loginWindow = window;
        }

        public ICommand ProfileBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = Profile;
                    CurrentPage.DataContext = new ProfileVM(CurrentEmployee);
                }
                );
            }
        }
        public ICommand ProductsStockBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = ProductsStock;
                    CurrentPage.DataContext = new ProductsStockVM(CurrentEmployee);
                }
                );
            }
        }
        public ICommand CreateApplicationBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = CreateApplication;
                    CurrentPage.DataContext = new CreateApplicationVM(CurrentEmployee);
                }
                );
            }
        }
        public ICommand ProductsSuppliesBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = ProductsSupplies;
                    CurrentPage.DataContext = new ProductsSuppliesVM(CurrentEmployee);
                }
                );
            }
        }
        public ICommand UsersListBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = UsersList;
                    CurrentPage.DataContext = new UsersListVM(CurrentEmployee);
                }
                );
            }
        }
        public ICommand AddUserBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CurrentPage = AddUser;
                    CurrentPage.DataContext = new AddUserVM();
                }
                );
            }
        }
    }
}
