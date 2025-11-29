using Catalog.Domain.ProductsDetails;
using Shared.Application.Persistance;

namespace Catalog.Application.Persistance
{
    public interface IProductDetailsRepositories : IGenericRepository<Product>
    {
    }
}
