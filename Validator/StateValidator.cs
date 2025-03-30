using FluentValidation;
using hotelApi.DTOS;
using hotelApi.Repository;

namespace hotelApi.Validator
{
    public class CreateStateValidator : AbstractValidator<CreateState>
    {
        public CreateStateValidator(IStateRepository stateRepository)
        {
            RuleFor(x => x.StateName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(StateName => stateRepository.GetStateName(StateName).Result == null)
                    .WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.StateCode)
                .NotEmpty()
                .WithMessage("must not be empty here");

        }
    }
    public class UpdateStateValidator : AbstractValidator<UpdateState>
    {
        public UpdateStateValidator(IStateRepository stateRepository)
        {
            RuleFor(x => x.StateId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.StateName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(StateName => stateRepository.GetStateName(StateName).Result == null)
                    .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.StateCode)
                .NotEmpty()
                .WithMessage("must not be empty here");

        }
    }
}
