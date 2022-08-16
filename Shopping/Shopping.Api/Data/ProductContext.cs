using Shopping.Api.Models;

namespace Shopping.Api.Data
{
    public static class ProductContext
    {
        public static void ConnectToCosmos()
        {

        }
        public static readonly List<Product> Products = new()
        {
            new Product
            {
                Name = "IPhone x",
                Description = "IPhone X mobile phone",
                ImageFile = "product1.png",
                Price = 950.00M,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "Samsung 10",
                Description = "Samsung  mobile phone",
                ImageFile = "product2.png",
                Price = 840.00M,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "Mi Redmi Note 11",
                Description = "Redmi mobile phone",
                ImageFile = "product3.png",
                Price = 750.00M,
                Category = "Smart Phone"
            }
        };
    }
}
