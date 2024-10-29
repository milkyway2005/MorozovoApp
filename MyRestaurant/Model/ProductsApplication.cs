using System.Collections.ObjectModel;

namespace MyRestaurant.Model
{
    public class ProductsApplication
    {
        public int IdApplication { get; set; }
        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }
        public string ReseiptDate { get; set; }
        public ObservableCollection<SuppliersProduct> Products { get; set; }
        public ProductsApplication(int idApplication, int idSupplier, string nameSupplier, string reseiptDate, ObservableCollection<SuppliersProduct> products)
        {
            IdApplication = idApplication;
            IdSupplier = idSupplier;
            NameSupplier = nameSupplier;
            ReseiptDate = reseiptDate;
            Products = products;
        }
    }
}
