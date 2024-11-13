namespace ProductApp.Application.DTOs;

public class UpdateProductDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}