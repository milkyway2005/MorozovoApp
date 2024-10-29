using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace MyRestaurant.ViewModel.PagesVM
{
    public class CreateApplicationVM : ViewModelBase
    {
        /// <summary>
        /// Сортировка продуктов по поставщикам и категориям
        /// </summary>
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
        private List<string> suppliers;
        public List<string> Suppliers
        {
            get { return suppliers; }
            set
            {
                suppliers = value;
                OnPropertyChanged("Suppliers");
            }
        }
        private string selectedSupplier;
        public string SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                selectedSupplier = value;
                OnPropertyChanged("SelectedSupplier");
            }
        }
        public ObservableCollection<SuppliersProduct> Products { get; set; }
        private SuppliersProduct selectedProduct;
        public SuppliersProduct SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        private bool enableCategory;
        public bool EnableCategory
        {
            get { return enableCategory; }
            set
            {
                enableCategory = value;
                OnPropertyChanged("EnableCategory");
            }
        }
        private bool enableSupplier;
        public bool EnableSupplier
        {
            get { return enableSupplier; }
            set
            {
                enableSupplier = value;
                OnPropertyChanged("EnableSupplier");
            }
        }

        /// <summary>
        /// Составление заявки
        /// </summary>
        public ObservableCollection<SuppliersProduct> ApplicationProducts { get; set; }
        private SuppliersProduct selectedApplicationProduct;
        public SuppliersProduct SelectedApplicationProduct
        {
            get { return selectedApplicationProduct; }
            set
            {
                selectedApplicationProduct = value;
                OnPropertyChanged("SelectedApplicationProduct");
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
        int idSupplier;

        /// <summary>
        /// Конструктор
        /// </summary>
        public CreateApplicationVM(Employee employee)
        {
            CurrentEmployee = employee;
            dataBase = new DataBase();
            Products = new ObservableCollection<SuppliersProduct>();
            ApplicationProducts = new ObservableCollection<SuppliersProduct>();
            EnableCategory = false;
            EnableSupplier = true;
            Suppliers = new List<string>();
            FillComboboxSuppliers();
            Categories = new List<string>();
            FillDataGrid();
        }

        /// <summary>
        /// Функции
        /// </summary>
        private void FillComboboxCategories()
        {
            dataTable = dataBase.SqlSelect("select distinct ProductsCategories.nameCategory " +
                                "from SuppliersProducts, ProductsCategories, Suppliers " +
                                "where SuppliersProducts.idCategory = ProductsCategories.idCategory " +
                                "and Suppliers.IdSupplier = SuppliersProducts.IdSupplier " +
                                "and Suppliers.nameSupplier = '" + SelectedSupplier + "'");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Categories.Add(dataTable.Rows[i][0].ToString());
            }
        }
        private void FillComboboxSuppliers()
        {
            dataTable = dataBase.SqlSelect("select distinct nameSupplier from Suppliers");
            Suppliers = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Suppliers.Add(dataTable.Rows[i][0].ToString());
            }
        }
        private void FillDataGrid()
        {
            dataTable = dataBase.SqlSelect("select SuppliersProducts.IdProduct, SuppliersProducts.nameProduct, ProductsCategories.nameCategory, " +
                                    "Suppliers.IdSupplier, Suppliers.nameSupplier, SuppliersProducts.price " +
                                    "from SuppliersProducts, ProductsCategories, Suppliers " +
                                    "where Suppliers.idSupplier = SuppliersProducts.idSupplier " +
                                    "and SuppliersProducts.idCategory = ProductsCategories.idCategory");
            SuppliersProduct product;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                product = new SuppliersProduct(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(),
                    Convert.ToInt32(dataTable.Rows[i][3]), dataTable.Rows[i][4].ToString(), Convert.ToInt32(dataTable.Rows[i][5]), 0);
                Products.Add(product);
            }
        }
        private void RefillDataGridCategories()
        {
            dataTable = dataBase.SqlSelect("select SuppliersProducts.IdProduct, SuppliersProducts.nameProduct, ProductsCategories.nameCategory, " +
                                "Suppliers.IdSupplier, Suppliers.nameSupplier, SuppliersProducts.price " +
                                "from SuppliersProducts, ProductsCategories, Suppliers " +
                                "where Suppliers.idSupplier = SuppliersProducts.idSupplier " +
                                "and SuppliersProducts.idCategory = ProductsCategories.idCategory " +
                                "and ProductsCategories.nameCategory = '" + SelectedCategory + "' " +
                                "and Suppliers.nameSupplier = '" + SelectedSupplier + "'");
            Products.Clear();
            SuppliersProduct product;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                product = new SuppliersProduct(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(),
                    Convert.ToInt32(dataTable.Rows[i][3]), dataTable.Rows[i][4].ToString(), Convert.ToInt32(dataTable.Rows[i][5]), 0);
                Products.Add(product);
            }
        }
        private void RefillDataGridSuppliers()
        {
            dataTable = dataBase.SqlSelect("select SuppliersProducts.IdProduct, SuppliersProducts.nameProduct, ProductsCategories.nameCategory, " +
                                    "Suppliers.IdSupplier, Suppliers.nameSupplier, SuppliersProducts.price " +
                                    "from SuppliersProducts, ProductsCategories, Suppliers " +
                                    "where Suppliers.idSupplier = SuppliersProducts.idSupplier " +
                                    "and SuppliersProducts.idCategory = ProductsCategories.idCategory " +
                                    "and Suppliers.nameSupplier = '" + SelectedSupplier + "'");
            Products.Clear();
            SuppliersProduct product;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                product = new SuppliersProduct(Convert.ToInt32(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(),
                    Convert.ToInt32(dataTable.Rows[i][3]), dataTable.Rows[i][4].ToString(), Convert.ToInt32(dataTable.Rows[i][5]), 0);
                Products.Add(product);
            }
            EnableSupplier = false;
            EnableCategory = true;
            FillComboboxCategories();
        }
        private bool CheckProduct()
        {
            return (SelectedProduct == null || ProductsCount <= 0) ? false : true;
        }
        private void AddProductMethod()
        {
            SelectedProduct.Amount = ProductsCount;
            ApplicationProducts.Add(SelectedProduct);
            ProductsCount = 0;
            idSupplier = SelectedProduct.IdSupplier;
            if (EnableSupplier)
            {
                SelectedSupplier = SelectedProduct.NameSupplier;
                RefillDataGridSuppliers();
            }

        }
        private void DeleteApplicationProductMethod()
        {
            SelectedApplicationProduct.Amount = 0;
            ApplicationProducts.Remove(SelectedApplicationProduct);
        }
        private void CreateApplicationMethod()
        {
            string date = (DateTime.Now).ToString();
            dataBase.SqlQuery("insert into Applications values (" + CurrentEmployee.IdEmployee + ", "
                + idSupplier + ", '" + date + "', 0)");
            dataTable = dataBase.SqlSelect("select idApplication from Applications where idEmployee = " + CurrentEmployee.IdEmployee +
                " and idSupplier = " + idSupplier + " and orderDate = '" + date + "' and statusApplication = 0");
            int idApplication = Convert.ToInt32(dataTable.Rows[0][0]);
            foreach (var p in ApplicationProducts)
            {
                dataBase.SqlQuery("insert into ApplicationsProducts values (" + p.IdProduct + ", " + idApplication +
                    ", " + p.Amount + ")");
            }
            MessageBox.Show("Заявка отправлена");
            ApplicationProducts.Clear();
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
                    RefillDataGridCategories();
                }
                );
            }
        }
        public ICommand SupplierChanged
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    RefillDataGridSuppliers();
                }
                );
            }
        }
        public ICommand AddProduct
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (CheckProduct())
                    {
                        AddProductMethod();
                    }
                    else
                    {
                        MessageBox.Show("Выберете продукт и укажите допустимое количество");
                    }
                }
                );
            }
        }
        public ICommand DeleteApplicationProduct
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SelectedApplicationProduct != null)
                    {
                        DeleteApplicationProductMethod();
                    }
                }
                );
            }
        }
        public ICommand CreateApplication
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (ApplicationProducts.Count > 0)
                    {
                        CreateApplicationMethod();
                    }
                }
                );
            }
        }
    }
}
