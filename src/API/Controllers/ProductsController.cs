namespace ProductApp.Api.Controllers;

public class ProductsController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto productDto)
     => Ok(await Mediator.Send(new CreateProductCommand(productDto.Title, productDto.Description, productDto.Price)));

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
     => Ok(await Mediator.Send(new GetProductsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] string id)
     => Ok(await Mediator.Send(new GetProductByIdQuery(id)));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync([FromRoute] string id, [FromBody] CreateProductDto productDto)
     => Ok(await Mediator.Send(new UpdateProductCommand(id, productDto.Title, productDto.Description, productDto.Price)));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] string id)
    {
        await Mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }

}