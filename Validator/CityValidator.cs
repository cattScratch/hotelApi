using hotelApi.DTOS;
using hotelApi.Repository;
using FluentValidation;
namespace hotelApi.Validator
{
    public class CreateCityValidator : AbstractValidator<CreateCity>
    {
        public CreateCityValidator(ICityRepository cityRepository)
        {
            RuleFor(x => x.CityName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(CityName => cityRepository.GetCityName(CityName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.CityCode)
                .NotEmpty()
                .WithMessage("must not be empty here");
            RuleFor(x => x.stateId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
    public class UpdateCityValidator : AbstractValidator<Updatecity>
    {
        public UpdateCityValidator(ICityRepository cityRepository)
        {
            RuleFor(x => x.Cityid)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.CityName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(CityName => cityRepository.GetCityName(CityName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.CityCode)
                .NotEmpty()
                .WithMessage("must not be empty here");
            RuleFor(x => x.stateId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
}
