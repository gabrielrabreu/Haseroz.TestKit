using FluentValidation;
using Haseroz.TestKit.Sample.Core.Models;

namespace Haseroz.TestKit.Sample.Core.Validators;

public class SkuValidator : AbstractValidator<Sku>
{
    public SkuValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
    }
}
