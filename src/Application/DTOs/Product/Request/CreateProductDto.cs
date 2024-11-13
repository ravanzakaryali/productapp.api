namespace ProductApp.Application.DTOs;

public class CreateProductDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}