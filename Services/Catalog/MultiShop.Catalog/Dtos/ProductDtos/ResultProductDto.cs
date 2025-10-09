namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string productId { get; set; }

        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }

        public string CategoryId { get; set; }
    }
}
