using Catalog.Application.ProductHandlers;
namespace Catalog.API.EndPoints.Product
{
    public interface IProductAction
    {
        Task<IResult> CreateProduct(CreateProductCommand req);
  
    }
}