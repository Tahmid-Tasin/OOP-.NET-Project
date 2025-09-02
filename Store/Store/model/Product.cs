namespace Store
{
    public class Product
    {
        public int ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public string NAME { get; set; }
        public string BRAND { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public string BARCODE { get; set; }
        public string IMAGE_PATH { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
