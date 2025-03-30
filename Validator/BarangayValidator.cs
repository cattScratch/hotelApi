using FluentValidation;
using hotelApi.DTOS;
using hotelApi.Repository;

namespace hotelApi.Validator
{
    public class CreateBarangayValidator : AbstractValidator<CreateBarangay>
    {
        public CreateBarangayValidator(IBarangayRepository barangayRepository)
        {
            RuleFor(x => x.BarangayName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(BarangayName => barangayRepository.GetBarangayName(BarangayName).Result == null)
                    .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.cityId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
        public class UpdateBarangayValidator : AbstractValidator<UpdateBarangay>
        {
            public UpdateBarangayValidator(IBarangayRepository barangayRepository) {

            RuleFor(x => x.BarangayId)
               .NotEmpty()
               .WithMessage("must not be empty here")
               .NotNull()
               .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.BarangayName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(BarangayName => barangayRepository.GetBarangayName(BarangayName).Result == null)
                    .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull();
            RuleFor(x => x.cityId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
        }
    }
        }
    
