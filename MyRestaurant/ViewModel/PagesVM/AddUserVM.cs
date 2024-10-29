using MyRestaurant.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.PagesVM
{
    public class AddUserVM : ViewModelBase
    {
        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value == 0 || value > 1900 && value < 2200)
                {
                    year = value;
                    OnPropertyChanged("Year");
                }
            }
        }
        private int month;
        public int Month
        {
            get { return month; }
            set
            {
                if (value >= 0 && value < 13)
                {
                    month = value;
                    OnPropertyChanged("Month");
                }
            }
        }
        private int day;
        public int Day
        {
            get { return day; }
            set
            {
                if (value >= 0 && value < 32)
                {
                    day = value;
                    OnPropertyChanged("Day");
                }
            }
        }
        private string passport;
        public string Passport
        {
            get { return passport; }
            set
            {
                if (value == null || value.Length == 10)
                {
                    passport = value;
                    OnPropertyChanged("Passport");
                }
            }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value == null || value.Length == 11 || (value.Length == 12 && value[0] == '+'))
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        private List<string> positions;
        public List<string> Positions
        {
            get { return positions; }
            set
            {
                positions = value;
                OnPropertyChanged("Positions");
            }
        }
        private string selectedPosition;
        public string SelectedPosition
        {
            get { return selectedPosition; }
            set
            {
                selectedPosition = value;
                OnPropertyChanged("SelectedPosition");
            }
        }
        DataBase dataBase;
        DataTable dataTable;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddUserVM()
        {
            dataBase = new DataBase();
            Positions = new List<string>();
            FillCombobox();
        }

        /// <summary>
        /// Функции
        /// </summary>
        private void FillCombobox()
        {
            dataTable = dataBase.SqlSelect("select namePosition from Positions");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Positions.Add(dataTable.Rows[i][0].ToString());
            }
        }
        private void AddEmployeeMethod()
        {
            string dateOfBirth = Year.ToString() + "-" + Month.ToString() + "-" + Day.ToString();
            string FullName = Surname + " " + FirstName + " " + Patronymic;
            dataTable = dataBase.SqlSelect("select idPosition from Positions where namePosition = '" + SelectedPosition + "'");
            int idPosition = Convert.ToInt32(dataTable.Rows[0][0]);

            if (dataBase.SqlSelect("select * from Employees where fullName = '" + FullName + "' and " +
                "dateOfBirth = '" + dateOfBirth + "' and passport = '" + Passport + "' and phoneNumber = '" + PhoneNumber +
                "' and idPosition = " + idPosition).Rows.Count == 0)
            {
                dataBase.SqlQuery("insert into Employees values ('" + FullName + "', '" + dateOfBirth + "', '" + Passport +
                    "', '" + PhoneNumber + "', '" + Login + "', '" + Password + "', " + idPosition + ")");
                MessageBox.Show("Сотрудник зарегестирован");
                CleanAll();
            }
            else
            {
                MessageBox.Show("Сотрудник с такими данными уже зарегистрирован");
                CleanAll();
            }
        }
        private void CleanAll()
        {
            Surname = null;
            FirstName = null;
            Patronymic = null;
            Year = 0;
            Month = 0;
            Day = 0;
            Passport = null;
            PhoneNumber = null;
            Login = null;
            Password = null;
            SelectedPosition = null;
        }

        /// <summary>
        /// Команды
        /// </summary>
        public ICommand AddEmployee
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (Surname != null && FirstName != null && Patronymic != null && Year != 0
                    && Month != 0 && Day != 0 && Passport != null && PhoneNumber != null
                    && Login != null && Password != null && SelectedPosition != null)
                    {
                        AddEmployeeMethod();
                    }
                    else
                    {
                        MessageBox.Show("Введите все данные");
                    }
                }
                );
            }
        }
    }
}
