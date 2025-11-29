using Catalog.API.EndPoints.Product;
using Catalog.Application.ProductHandlers;
using Mapster;
using MediatR;

namespace Catalog.API.EndPoints.Product
{
    public class ProductAction : IProductAction
    {
        private readonly ISender _sender;

        public ProductAction(ISender sender)
        {
            _sender = sender;
        }
        public async Task<IResult> CreateProduct(CreateProductCommand req)
        {
            var command = req.Adapt<CreateProductCommand>();
            var result = await _sender.Send(command);
            var response = result.Adapt<CreateProductResult>();

            return Results.Created($"api/v1/products/{response.Id}", response);
        }
    }
}
