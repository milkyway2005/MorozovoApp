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
    public class ProductsStockVM : ViewModelBase
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
        private List<string> categories;
        public List<string> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        private string selectedCategory;
        public string SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public ObservableCollection<Product> Products { get; set; }
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private int productsCount;
        public int ProductsCount
        {
            get { return productsCount; }
            set
            {
                productsCount = value;
                OnPropertyChanged("ProductsCount");
            }
        }

        DataBase dataBase;
        DataTable dataTable;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductsStockVM(Employee employee)
        {
            CurrentEmployee = employee;
            dataBase = new DataBase();
            Products = new ObservableCollection<Product>();
            FillCombobox();
            RefreshDataGrid();
        }

        /// <summary>
        /// Функции
        /// </summary>
        private void FillCombobox()
        {
            dataTable = dataBase.SqlSelect("select distinct ProductsCategories.nameCategory " +
                                    "from SuppliersProducts, ProductsStock, ProductsCategories " +
                                    "where SuppliersProducts.idCategory = ProductsCategories.idCategory " +
                                    "and ProductsStock.idProduct = SuppliersProducts.idProduct");
            Categories = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Categories.Add(dataTable.Rows[i][0].ToString());
            }
        }
        private void RefillDataGrid()
        {
            dataTable = dataBase.SqlSelect("select ProductsStock.idProduct, SuppliersProducts.nameProduct, " +
                                    "ProductsStock.receiptDate, ProductsStock.amount, SuppliersProducts.idCategory, " +
                                    "ProductsCategories.nameCategory " +
                                    "from ProductsCategories, ProductsStock, SuppliersProducts " +
                                    "where ProductsCategories.idCategory = SuppliersProducts.idCategory " +
                                    "and SuppliersProducts.idProduct = ProductsStock.idProduct and " +
                                    "ProductsCategories.nameCategory = '" + SelectedCategory + "'");
            Products.Clear();
            Product product;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                product = new Product(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(),
                    Convert.ToInt32(dataTable.Rows[i][3]), Convert.ToInt32(dataTable.Rows[i][4]), dataTable.Rows[i][5].ToString());
                Products.Add(product);
            }
        }
        private void RefreshDataGrid()
        {
            dataTable = dataBase.SqlSelect("select ProductsStock.idProduct, SuppliersProducts.nameProduct, " +
                                    "ProductsStock.receiptDate, ProductsStock.amount, SuppliersProducts.idCategory, " +
                                    "ProductsCategories.nameCategory " +
                                    "from ProductsCategories, ProductsStock, SuppliersProducts " +
                                    "where ProductsCategories.idCategory = SuppliersProducts.idCategory " +
                                    "and SuppliersProducts.idProduct = ProductsStock.idProduct");
            Products.Clear();
            Product product;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                product = new Product(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(),
                    Convert.ToInt32(dataTable.Rows[i][3]), Convert.ToInt32(dataTable.Rows[i][4]), dataTable.Rows[i][5].ToString());
                Products.Add(product);
            }
        }
        private bool CheckProduct()
        {
            return (SelectedProduct == null || ProductsCount == 0 || ProductsCount > SelectedProduct.Amount) ? false : true;
        }

        private void TakeProductMethod()
        {
            string date = (DateTime.Now).ToString();
            dataBase.SqlQuery("insert into EmployeesIssuances values (" + SelectedProduct.IdProduct + ", " +
                CurrentEmployee.IdEmployee + ", " + ProductsCount + ", '" + date + "')");
            ProductMethod("Продукт выдан");
        }
        private void DeleteProductMethod()
        {
            ProductMethod("Продукт удален");
        }
        private void ProductMethod(string message)
        {
            SelectedProduct.Amount -= ProductsCount;
            ProductsCount = 0;
            if (SelectedProduct.Amount == 0)
            {
                dataBase.SqlQuery("delete from ProductsStock where idProduct = " + selectedProduct.IdProduct);
            }
            else
            {
                dataBase.SqlQuery("update ProductsStock set amount = " + selectedProduct.Amount + " where idProduct = " +
                    selectedProduct.IdProduct);
            }
            SelectedCategory = null;
            SelectedProduct = null;
            RefreshDataGrid();
            MessageBox.Show(message);
        }

        /// <summary>
        /// Команды
        /// </summary>
        public ICommand CategoryChanged
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
        public ICommand TakeProduct
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (CheckProduct())
                    {
                        TakeProductMethod();
                    }
                    else
                    {
                        MessageBox.Show("Выберете продукт и укажите допустимое количество");
                    }
                }
                );
            }
        }
        public ICommand DeleteProduct
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (CheckProduct())
                    {
                        DeleteProductMethod();
                    }
                    else
                    {
                        MessageBox.Show("Выберете продукт и укажите допустимое количество");
                    }
                }
                );
            }
        }
    }
}
