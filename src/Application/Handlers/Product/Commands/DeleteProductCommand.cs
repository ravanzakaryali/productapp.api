namespace ProductApp.Application.Handlers;

public record DeleteProductCommand(string Id) : IRequest;

internal class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
{
    readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Product), request.Id);

        await _productRepository.DeleteAsync(request.Id);
    }
}