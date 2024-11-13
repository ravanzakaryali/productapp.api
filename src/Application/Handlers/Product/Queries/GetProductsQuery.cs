namespace ProductApp.Application.Handlers;

public class GetProductsQuery : IRequest<IEnumerable<GetProductDto>>;

internal class GetProducts : IRequestHandler<GetProductsQuery, IEnumerable<GetProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetProducts(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<GetProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await _productRepository.GetAllAsync();

        return products.Select(p => new GetProductDto
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            Price = p.Price
        });
    }
}