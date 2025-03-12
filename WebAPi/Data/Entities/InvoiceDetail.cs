namespace WebAPi.Data.Entities;

public class InvoiceDetail(int invoiceId, int vehicleId, int quantity, decimal price) : BaseEntity
{
    public int InvoiceId { get; set; } = invoiceId;

    public Invoice Invoice { get; set; } = null!;

    public int VehicleId { get; set; } = vehicleId;

    public Vehicle Vehicle { get; set; } = null!;

    public int Quantity { get; set; } = quantity;

    public decimal Price { get; set; } = price;
}