using hotelApi.DTOS;
using hotelApi.Repository;
using FluentValidation;

namespace hotelApi.Validator
{
    public class CreateCountryValidator : AbstractValidator<CreateCountry>
    {
        public CreateCountryValidator(ICountryRepository countryRepository)
        {
            RuleFor(x => x.CountryName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(CountryName => countryRepository.GetCountryName(CountryName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                 .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
    public class UpdateCountryValidator : AbstractValidator<UpdateCountry>
    {
        public UpdateCountryValidator(ICountryRepository countryRepository)
        {
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.CountryName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(CountryName => countryRepository.GetCountryName(CountryName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");

        }
    }
}
