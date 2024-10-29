using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.PagesVM
{
    public class ProductsSuppliesVM : ViewModelBase
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
        public ObservableCollection<ProductsApplication> Applications { get; set; }
        private ProductsApplication selectedApplication;
        public ProductsApplication SelectedApplication
        {
            get { return selectedApplication; }
            set
            {
                selectedApplication = value;
                OnPropertyChanged("SelectedApplication");
            }
        }

        DataBase dataBase;
        DataTable dataTable;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductsSuppliesVM(Employee employee)
        {
            CurrentEmployee = employee;
            dataBase = new DataBase();
            Applications = new ObservableCollection<ProductsApplication>();
            FillDataGrid();
        }

        /// <summary>
        /// Функции
        /// </summary>
        private void FillDataGrid()
        {
            dataTable = dataBase.SqlSelect("select Applications.idApplication, Applications.idSupplier, " +
                                "Suppliers.nameSupplier, Applications.orderDate " +
                                "from Suppliers, Applications " +
                                "where Suppliers.idSupplier = Applications.idSupplier " +
                                "and Applications.statusApplication = 0");
            DataTable dt;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dt = dataBase.SqlSelect("select ApplicationsProducts.idProduct, SuppliersProducts.nameProduct, " +
                    "ProductsCategories.nameCategory, Applications.idSupplier, " +
                    "Suppliers.nameSupplier, SuppliersProducts.price, ApplicationsProducts.amount " +
                    "from Suppliers, Applications, ApplicationsProducts, SuppliersProducts, " +
                    "ProductsCategories " +
                    "where Applications.idApplication = ApplicationsProducts.idApplication " +
                    "and SuppliersProducts.idProduct = ApplicationsProducts.idProduct " +
                    "and Suppliers.idSupplier = SuppliersProducts.idSupplier " +
                    "and SuppliersProducts.idCategory = ProductsCategories.idCategory " +
                    "and Suppliers.idSupplier = Applications.idSupplier " +
                    "and ApplicationsProducts.idApplication = " + Convert.ToInt32(dataTable.Rows[i][0]));
                ObservableCollection<SuppliersProduct> products = new ObservableCollection<SuppliersProduct>();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    products.Add(new SuppliersProduct(Convert.ToInt32(dt.Rows[j][0]), dt.Rows[j][1].ToString(), dt.Rows[j][2].ToString(),
                        Convert.ToInt32(dt.Rows[j][3]), dt.Rows[j][4].ToString(), Convert.ToInt32(dt.Rows[j][5]), Convert.ToInt32(dt.Rows[j][6])));

                }
                Applications.Add(new ProductsApplication(Convert.ToInt32(dataTable.Rows[i][0]), Convert.ToInt32(dataTable.Rows[i][1]),
                    dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), products));
            }
        }
        private void AcceptApplicationMethod()
        {
            dataBase.SqlQuery("update Applications set statusApplication = 1 where idApplication = " + SelectedApplication.IdApplication);
            foreach (var p in SelectedApplication.Products)
            {
                dataTable = dataBase.SqlSelect("select * from ProductsStock where idProduct = " + p.IdProduct);
                if (dataTable.Rows.Count == 0)
                {
                    string date = (DateTime.Now).ToString();
                    dataBase.SqlQuery("insert into ProductsStock values (" + p.IdProduct + ", '" + date + "', " + p.Amount + ")");
                }
                else
                {
                    dataBase.SqlQuery("update ProductsStock set amount += " + p.Amount + " where idProduct = " + p.IdProduct);
                }
                Applications.Remove(SelectedApplication);
            }
            MessageBox.Show("Поставка принята");
        }

        /// <summary>
        /// Команды
        /// </summary>
        public ICommand AcceptApplication
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedApplication != null)
                    {
                        AcceptApplicationMethod();
                    }
                    else
                    {
                        MessageBox.Show("Выберете поставку");
                    }
                }
                );
            }
        }
    }
}
