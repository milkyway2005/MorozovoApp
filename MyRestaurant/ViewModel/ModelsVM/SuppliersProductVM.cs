using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;

namespace MyRestaurant.ViewModel.ModelsVM
{
    public class SuppliersProductVM : ViewModelBase
    {
        private SuppliersProduct suppliersProduct;
        public SuppliersProductVM(SuppliersProduct prod)
        {
            suppliersProduct = prod;
        }
        public int IdProduct
        {
            get { return suppliersProduct.IdProduct; }
            set
            {
                suppliersProduct.IdProduct = value;
                OnPropertyChanged("IdProduct");
            }
        }
        public string NameProduct
        {
            get { return suppliersProduct.NameProduct; }
            set
            {
                suppliersProduct.NameProduct = value;
                OnPropertyChanged("NameProduct");
            }
        }
        public string NameCategory
        {
            get { return suppliersProduct.NameCategory; }
            set
            {
                suppliersProduct.NameCategory = value;
                OnPropertyChanged("NameCategory");
            }
        }
        public int IdSupplier
        {
            get { return suppliersProduct.IdSupplier; }
            set
            {
                suppliersProduct.IdSupplier = value;
                OnPropertyChanged("IdSupplier");
            }
        }
        public string NameSupplier
        {
            get { return suppliersProduct.NameSupplier; }
            set
            {
                suppliersProduct.NameSupplier = value;
                OnPropertyChanged("NameSupplier");
            }
        }
        public int Price
        {
            get { return suppliersProduct.Price; }
            set
            {
                suppliersProduct.Price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Amount
        {
            get { return suppliersProduct.Amount; }
            set
            {
                suppliersProduct.Amount = value;
                OnPropertyChanged("Amount");
            }
        }
    }
}
