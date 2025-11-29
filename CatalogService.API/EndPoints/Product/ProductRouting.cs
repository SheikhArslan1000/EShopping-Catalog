using Carter;
using Catalog.Application.ProductHandlers;

namespace Catalog.API.EndPoints.Product
{
    /*
     This is testing process to setup the minimal ap
     Note: According to setting khaber daar logic add ki warna m developer ky hath band du ga.. abi chexzy lose rakhi hai
     */
    public class ProductRouting : ICarterModule
    {
        
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/v1/products").WithTags("Products Actions");
            //group.MapGet("", _productAction.GetProducts)
            //.Produces<List<Products>>();

            //group.MapGet("{productId}", _productAction.GetProduct)
            //    .Produces<Products>()
            //    .Produces(StatusCodes.Status404NotFound);

            group.MapPost("", async (CreateProductCommand command, IProductAction productAction) =>
                      await productAction.CreateProduct(command));

            //group.MapPut("{productId}", _productAction.UpdateProduct)
            //    .Produces(StatusCodes.Status204NoContent)
            //    .ProducesProblem(StatusCodes.Status404NotFound)
            //    .ProducesValidationProblem();

            //group.MapDelete("{productId}", _productAction.DeleteProduct)
            //    .Produces(StatusCodes.Status204NoContent)
            //    .ProducesProblem(StatusCodes.Status404NotFound);

          //  group.MapGet("", async (IProductAction productAction) =>
          //await productAction.GetProducts());

          //  group.MapGet("{productId}", async (string productId, IProductAction productAction) =>
          //      await productAction.GetProduct(productId));

          //  group.MapPost("", async (CreateProductCommand command, IProductAction productAction) =>
          //      await productAction.CreateProduct(command));

          //  group.MapPut("{productId}", async (HttpRequest req, IProductAction productAction) =>
          //      await productAction.UpdateProduct(req));

          //  group.MapDelete("{productId}", async (int productId, IProductAction productAction) =>
          //      await productAction.DeleteProduct(productId));

        }
    }
}
