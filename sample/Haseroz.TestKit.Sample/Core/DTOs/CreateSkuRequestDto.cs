namespace Haseroz.TestKit.Sample.Core.DTOs;

public class CreateSkuRequestDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public int Stock { get; set; } = 0;
}
