using MyRestaurant.View.Pages;
using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;
using MyRestaurant.ViewModel.PagesVM;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.WindowsVM
{
    public class ControlWindowVM : ViewModelBase
    {
        public DataBase dataBase;
        public DataTable dataTable;
        public Window loginWindow;
        private Page ControlPageUsers;
        private Page ControlPageSuchef;
        private Page ControlPageChef;

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
        public ControlWindowVM(Employee employee, Window window)
        {
            dataBase = new DataBase();
            ControlPageUsers = new ControlPageUsers();
            ControlPageSuchef = new ControlPageSuchef();
            ControlPageChef = new ControlPageChef();
            CurrentEmployee = employee;
            loginWindow = window;
            ChoosePage();
        }

        private void ChoosePage()
        {
            switch (CurrentEmployee.IdPosition)
            {
                case 1:
                    {//Шеф-повар
                        CurrentPage = ControlPageChef;
                    }
                    break;
                case 2:
                    {//Су-шеф
                        CurrentPage = ControlPageSuchef;
                    }
                    break;
                default:
                    {//Остальные должности
                        CurrentPage = ControlPageUsers;
                    }
                    break;
            }
            CurrentPage.DataContext = new ControlPagesVM(CurrentEmployee, loginWindow);
        }
        private void CloseWindowMethod()
        {
            loginWindow.Close();
        }
        private void ResizeWindowMethod()
        {
            Window window = loginWindow.OwnedWindows[0];
            window.WindowState = WindowState.Minimized;
        }
        private void BackWindowMethod()
        {
            loginWindow.Show();
            Window window = loginWindow.OwnedWindows[0];
            window.Close();
        }

        public ICommand CloseWindow
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    CloseWindowMethod();
                }
                );
            }
        }
        public ICommand ResizeWindow
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ResizeWindowMethod();
                }
                );
            }
        }
        public ICommand BackBtn_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    BackWindowMethod();
                }
                );
            }
        }
    }
}
