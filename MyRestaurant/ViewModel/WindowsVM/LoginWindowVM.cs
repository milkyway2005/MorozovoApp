using MyRestaurant.View.Windows;
using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.WindowsVM
{
    public class LoginWindowVM : ViewModelBase
    {
        public DataBase dataBase;
        public DataTable dataTable;
        public Employee CurrentEmployee;

        private string currentLogin;
        public string CurrentLogin
        {
            get { return currentLogin; }
            set { currentLogin = value; OnPropertyChanged("CurrentLogin"); }
        }

        private string currentPassword;
        public string CurrentPassword
        {
            get { return currentPassword; }
            set { currentPassword = value; OnPropertyChanged("CurrentPassword"); }
        }

        public string messageText;
        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; OnPropertyChanged("MessageText"); }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public LoginWindowVM()
        {
            dataBase = new DataBase();
        }

        /// <summary>
        /// Команды
        /// </summary>
        public ICommand OpenControlWindow
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (CheckEmployee())
                    {
                        CreateEmployee();
                        CleanWindow();
                        MessageText = "";
                        OpenControlWindowMethod();
                    }
                    else
                    {
                        CleanWindow();
                        MessageText = "Неверный логин или пароль";
                    }
                }
                );
            }
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

        /// <summary>
        /// Функции
        /// </summary>
        private void OpenControlWindowMethod()
        {
            ControlWindow controlWindow = new ControlWindow();
            controlWindow.Owner = Application.Current.MainWindow;
            controlWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            controlWindow.Show();
            controlWindow.Owner.Hide();
            controlWindow.DataContext = new ControlWindowVM(CurrentEmployee, controlWindow.Owner);
        }
        private void CleanWindow()
        {
            CurrentLogin = "";
            CurrentPassword = "";
        }
        private bool CheckEmployee()
        {
            dataTable = dataBase.SqlSelect("select Employees.*, Positions.namePosition " +
                            "from Employees, Positions " +
                            "where Employees.idPosition = Positions.idPosition and loginEmployee = '" + CurrentLogin +
                            "' and passwordEmployee = '" + CurrentPassword + "'");
            return dataTable.Rows.Count == 0 ? false : true;
        }
        private void CreateEmployee()
        {
            CurrentEmployee = new Employee(Convert.ToInt32(dataTable.Rows[0][0]), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(),
                dataTable.Rows[0][3].ToString(), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString(), dataTable.Rows[0][6].ToString(),
                Convert.ToInt32(dataTable.Rows[0][7]), dataTable.Rows[0][8].ToString());
        }
        private void CloseWindowMethod()
        {
            Window window = Application.Current.MainWindow;
            window.Close();
        }
        private void ResizeWindowMethod()
        {
            Window window = Application.Current.MainWindow;
            window.WindowState = WindowState.Minimized;
        }
    }
}
