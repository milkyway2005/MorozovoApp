using MyRestaurant.Model;
using MyRestaurant.ViewModel.BaseVM;

namespace MyRestaurant.ViewModel.ModelsVM
{
    public class ProductVM : ViewModelBase
    {
        private Product product;
        public ProductVM(Product prod)
        {
            product = prod;
        }
        public int IdProduct
        {
            get { return product.IdProduct; }
            set
            {
                product.IdProduct = value;
                OnPropertyChanged("IdProduct");
            }
        }
        public string NameProduct
        {
            get { return product.NameProduct; }
            set
            {
                product.NameProduct = value;
                OnPropertyChanged("NameProduct");
            }
        }
        public string ReceiptDate
        {
            get { return product.ReceiptDate; }
            set
            {
                product.ReceiptDate = value;
                OnPropertyChanged("ReceiptDate");
            }
        }
        public int Amount
        {
            get { return product.Amount; }
            set
            {
                product.Amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public int IdCategory
        {
            get { return product.IdCategory; }
            set
            {
                product.IdCategory = value;
                OnPropertyChanged("IdCategory");
            }
        }
        public string NameCategory
        {
            get { return product.NameCategory; }
            set
            {
                product.NameCategory = value;
                OnPropertyChanged("NameCategory");
            }
        }
    }
}
