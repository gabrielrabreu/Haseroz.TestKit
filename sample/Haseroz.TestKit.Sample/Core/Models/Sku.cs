namespace Haseroz.TestKit.Sample.Core.Models;

public class Sku(string code, string name, decimal price, int stock)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = code;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int Stock { get; set; } = stock;
}
