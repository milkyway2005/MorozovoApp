namespace MyRestaurant.Model
{
    public class SuppliersProduct
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string NameCategory { get; set; }
        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public SuppliersProduct(int idProduct, string nameProduct, string nameCategory, int idSupplier, string nameSupplier, int price, int amount)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            NameCategory = nameCategory;
            IdSupplier = idSupplier;
            NameSupplier = nameSupplier;
            Price = price;
            Amount = amount;
        }
    }
}
