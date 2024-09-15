using ABPCourse.Demo1.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace ABPCourse.Demo1.Products
{
    public class CreateUpdateProductValidator : AbstractValidator<CreateUpdateProductDto>
    {
        private readonly IStringLocalizerFactory stringLocalizerFactory;

        private IStringLocalizer PrdLoc => stringLocalizerFactory.Create(typeof(ProductsResource));
        private IStringLocalizer Loc => stringLocalizerFactory.Create(typeof(Demo1Resource));
        public CreateUpdateProductValidator(IStringLocalizerFactory stringLocalizerFactory)
        {
            this.stringLocalizerFactory = stringLocalizerFactory;

            RuleFor(x => x.NameAr)
                .NotEmpty()
                .MaximumLength(Demo1Consts.GeneralTextMaxLength)
                .WithErrorCode(Demo1DomainErrorCodes.INVALID_PRODUCT_DATA_NAME_AR)
                .WithMessage(PrdLoc["Products:InvalidProductNameAr"]);
            RuleFor(x => x.NameEn)
                .NotEmpty()
                .MaximumLength(Demo1Consts.GeneralTextMaxLength)
                .WithErrorCode(Demo1DomainErrorCodes.INVALID_PRODUCT_DATA_NAME_EN)
                .WithMessage(PrdLoc["Products:InvalidProductNameEn"]);
            RuleFor(x => x.DescriptionAr)
                .NotEmpty()
                .MaximumLength(Demo1Consts.DescriptionTextMaxLength)
                .WithErrorCode(Demo1DomainErrorCodes.INVALID_PRODUCT_DATA_DESC_AR)
                .WithMessage(PrdLoc["Products:InvalidProductDescAr"]);
            RuleFor(x => x.DescriptionEn)
                .NotEmpty()
                .MaximumLength(Demo1Consts.DescriptionTextMaxLength)
                .WithErrorCode(Demo1DomainErrorCodes.INVALID_PRODUCT_DATA_DESC_EN)
                .WithMessage(PrdLoc["Products:InvalidProductDescEn"]);
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithErrorCode(Demo1DomainErrorCodes.INVALID_PRODUCT_CATEGORY)
                .WithMessage(PrdLoc["Products:InvalidProductCategory"]);
        }
    }
}
