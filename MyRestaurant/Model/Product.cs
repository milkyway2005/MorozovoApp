namespace MyRestaurant.Model
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string ReceiptDate { get; set; }
        public int Amount { get; set; }
        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
        public Product(int idProduct, string nameProduct, string receiptDate, int amount, int idCategory, string nameCategory)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            ReceiptDate = receiptDate;
            Amount = amount;
            IdCategory = idCategory;
            NameCategory = nameCategory;
        }
    }
}
