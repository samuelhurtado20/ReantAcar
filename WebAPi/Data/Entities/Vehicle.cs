namespace WebAPi.Data.Entities;

public class Vehicle : BaseEntity
{
    public Vehicle()
    { }

    public string Plate { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int BrandId { get; set; }

    public Brand Brand { get; set; } = null!;

    public string SerialNumber { get; set; } = string.Empty;

    public string EngineNumber { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public int Year { get; set; }

    public decimal Price { get; set; }

    public string Image { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}