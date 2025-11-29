using Catalog.Domain.ProductsDetails;
using Catalog.Infrastructure.DataBaseContext;
using Catalog.Application.Persistance;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductDetailsRepository : GenericRepositry<Product>, IProductDetailsRepositories
    {
        public ProductDetailsRepository(CatalogDatabaseContext context) : base(context)
        {

        }
    }
}
