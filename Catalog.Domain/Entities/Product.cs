using Shared.Domain.Common;
using Shared.Domain.Events;

namespace Catalog.Domain.ProductsDetails
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal? Price { get; private set; }
        public string? ImageFile { get; private set; }
        public string? Categories { get; private set; }

        public Product() { }

        public static Product Create(string name, string description)
        {
            var product = new Product { Name = name, Description = description };
            //var before = (Product)this.MemberwiseClone();
            //Name = name;
            product.AddDomainEvent(new EntityUpdatedEvent<Product>(null, product));
            return product;
        }

    }
}
