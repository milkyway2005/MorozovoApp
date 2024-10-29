using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.PagesVM
{
    public class UsersListVM : ViewModelBase
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
        public ObservableCollection<Employee> Employees { get; set; }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
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
        public UsersListVM(Employee employee)
        {
            CurrentEmployee = employee;
            dataBase = new DataBase();
            Employees = new ObservableCollection<Employee>();
            FillDataGrid();
            Positions = new List<string>();
            FillCombobox();
        }

        /// <summary>
        /// Функции
        /// </summary>
        private void FillDataGrid()
        {
            dataTable = dataBase.SqlSelect("select Employees.idEmployee, fullName, dateOfBirth, passport, " +
                                "phoneNumber, loginEmployee, passwordEmployee, " +
                                "Employees.idPosition, Positions.namePosition " +
                                "from Employees, Positions " +
                                "where Employees.idPosition = Positions.idPosition " +
                                "and Employees.idEmployee != " + CurrentEmployee.IdEmployee);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Employees.Add(new Employee(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(),
                    dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), dataTable.Rows[i][4].ToString(),
                    dataTable.Rows[i][5].ToString(), dataTable.Rows[i][6].ToString(), Convert.ToInt32(dataTable.Rows[i][7]),
                    dataTable.Rows[i][8].ToString()));
            }
        }
        private void FillCombobox()
        {
            dataTable = dataBase.SqlSelect("select distinct Positions.namePosition " +
                                "from Employees, Positions " +
                                "where Employees.idPosition = Positions.idPosition " +
                                "and Positions.namePosition != '" + CurrentEmployee.NamePosition + "'");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Positions.Add(dataTable.Rows[i][0].ToString());
            }
        }
        private void RefillDataGrid()
        {
            dataTable = dataBase.SqlSelect("select Employees.idEmployee, fullName, dateOfBirth, passport, " +
                                "phoneNumber, loginEmployee, passwordEmployee, " +
                                "Employees.idPosition, Positions.namePosition " +
                                "from Employees, Positions " +
                                "where Employees.idPosition = Positions.idPosition " +
                                "and Employees.idEmployee != " + CurrentEmployee.IdEmployee +
                                " and namePosition = '" + SelectedPosition + "'");
            Employees.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Employees.Add(new Employee(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(),
                    dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), dataTable.Rows[i][4].ToString(),
                    dataTable.Rows[i][5].ToString(), dataTable.Rows[i][6].ToString(), Convert.ToInt32(dataTable.Rows[i][7]),
                    dataTable.Rows[i][8].ToString()));
            }
        }
        private void DeleteEmployeeMethod()
        {
            dataBase.SqlQuery("delete from EmployeesIssuances where idEmployee = " + SelectedEmployee.IdEmployee);
            dataBase.SqlQuery("delete from Employees where idEmployee = " + SelectedEmployee.IdEmployee);
            Employees.Remove(SelectedEmployee);
            MessageBox.Show("Сотрудник удален");
        }

        /// <summary>
        /// Команды
        /// </summary>
        public ICommand PositionChanged
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    RefillDataGrid();
                }
                );
            }
        }
        public ICommand DeleteEmployee
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedEmployee != null)
                    {
                        DeleteEmployeeMethod();
                    }
                    else
                    {
                        MessageBox.Show("Выберите сотрудника для удаления");
                    }
                }
                );
            }
        }
    }
}
