using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Haseroz.TestKit.Sample.Core.DTOs;
using Haseroz.TestKit.Sample.Core.Models;
using Haseroz.TestKit.Sample.Core.Validators;

namespace Haseroz.TestKit.Sample.Core.Services;

public class SkuService
{
    private readonly ICollection<Sku> _existentSkus = 
    [
        new Sku("SKU001", "Product 1", 10.89m, 5) 
        {
            Id = Guid.Parse("d2e5817a-361a-4c41-bf5b-f3795748b794")
        }
    ];

    public Result<Sku> Create(CreateSkuRequestDto request)
    {
        var sku = new Sku(request.Code, request.Name, request.Price, request.Stock);

        var validator = new SkuValidator();

        var result = validator.Validate(sku);

        if (!result.IsValid)
            return Result.Invalid(result.AsErrors());

        if (_existentSkus.Any(x => x.Code == sku.Code))
            return Result.Conflict($"Sku ({sku.Code} already exists in the system");

        return Result<Sku>.Created(sku, $"/Skus/{sku.Id}");
    }

    public Result Delete(Guid id)
    {
        var sku = _existentSkus.FirstOrDefault(x => x.Id == id);

        if (sku == null)
            return Result.NotFound($"Sku with id '{id}' not found");

        return Result.Success();
    }
}
