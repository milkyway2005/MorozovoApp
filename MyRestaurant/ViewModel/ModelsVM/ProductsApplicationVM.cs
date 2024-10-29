using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;
using System.Collections.ObjectModel;

namespace MyRestaurant.ViewModel.ModelsVM
{
    public class ProductsApplicationVM : ViewModelBase
    {
        private ProductsApplication application;

        public ProductsApplicationVM(ProductsApplication app)
        {
            application = app;
        }
        public int IdApplication
        {
            get { return application.IdApplication; }
            set
            {
                application.IdApplication = value;
                OnPropertyChanged("IdApplication");
            }
        }
        public int IdSupplier
        {
            get { return application.IdSupplier; }
            set
            {
                application.IdSupplier = value;
                OnPropertyChanged("IdSupplier");
            }
        }
        public string NameSupplier
        {
            get { return application.NameSupplier; }
            set
            {
                application.NameSupplier = value;
                OnPropertyChanged("NameSupplier");
            }
        }
        public string ReseiptDate
        {
            get { return application.ReseiptDate; }
            set
            {
                application.ReseiptDate = value;
                OnPropertyChanged("ReseiptDate");
            }
        }
        public ObservableCollection<SuppliersProduct> Products
        {
            get { return application.Products; }
            set
            {
                application.Products = value;
                OnPropertyChanged("ReseiptDate");
            }
        }
    }
}
