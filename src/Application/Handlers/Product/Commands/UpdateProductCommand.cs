namespace ProductApp.Application.Handlers;

public record UpdateProductCommand(
    string Id,
    string Title,
    string Description,
    decimal Price
) : IRequest<GetProductDto>;

internal class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, GetProductDto>
{
    readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Product), request.Id);

        await _productRepository.UpdateAsync(request.Id, new Product()
        {
            Id = product.Id,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price
        });

        return new GetProductDto
        {
            Id = product.Id,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price
        };
    }
}