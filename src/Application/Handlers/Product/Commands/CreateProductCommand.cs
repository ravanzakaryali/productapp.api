namespace ProductApp.Application.Handlers;

public record CreateProductCommand(
    string Title,
    string Description,
    decimal Price
) : IRequest<GetProductDto>;

internal class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, GetProductDto>
{

    readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price
        };
        await _productRepository.InsertAsync(product);

        return new GetProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price
        };

    }
}
