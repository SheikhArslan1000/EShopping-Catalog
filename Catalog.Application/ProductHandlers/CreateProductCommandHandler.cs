using BuildingBlocks.CQRS;
using Catalog.Application.Persistance;
using Catalog.Domain.ProductsDetails;

namespace Catalog.Application.ProductHandlers
{
    public record CreateProductCommand(string Name, string Category, string Description, decimal Price, string ImageFile) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {

        private readonly IProductDetailsRepositories _productDetailsRepositories;

        public CreateProductCommandHandler(IProductDetailsRepositories productDetailsRepositories)
        {
            _productDetailsRepositories = productDetailsRepositories;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //var pro = new Product();
            var product = Product.Create(command.Name, command.Description);
            await _productDetailsRepositories.CreateAsync(product);
            return new CreateProductResult(product.Id);
        }
    }

}
