using FluentValidation;
using Mobiliva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Business.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Category).MaximumLength(50).WithMessage("Please less than 50 character for category name.");
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(500).WithMessage("Please less than 500 character for description.");
            RuleFor(x => x.Unit).LessThan(500).WithMessage("Unit number can't be more than 500.");
            RuleFor(x => x.UnitPrice).LessThan(999999).WithMessage("Unit price can't be more than 999999.");
        }
    }
}
