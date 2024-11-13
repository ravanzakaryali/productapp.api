namespace ProductApp.Application.Handlers;

public record GetProductByIdQuery(string Id) : IRequest<GetProductDto>;

internal class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, GetProductDto>
{
    readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Product), request.Id);

        return new GetProductDto
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price
        };
    }
}

