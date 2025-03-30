using hotelApi.DTOS;
using hotelApi.Repository;
using FluentValidation;
using hotelApi.Entities;

namespace hotelApi.Validator
{
    public class CreateHotelValidator : AbstractValidator<CreateHotel>
    {
        public CreateHotelValidator(IHotelRepository hotelRepository)
        {
            RuleFor(x => x.HotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(HotelName => hotelRepository.GetHotelName(HotelName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.HotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelDescription)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.barangayId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
    public class UpdateHotelValidator : AbstractValidator<UpdateHotel>
    {
        public UpdateHotelValidator(IHotelRepository hotelRepository) 
        {
            RuleFor(x => x.HotelId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.HotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(HotelName => hotelRepository.GetHotelName(HotelName).Result == null)
                    .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.HotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull();
            RuleFor(x => x.HotelDescription)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.barangayId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
}
