using hotelApi.DTOS;
using hotelApi.Repository;
using FluentValidation;
using hotelApi.DTOS;

namespace hotelApi.Validator
{
    public class CreateTransactionValidator : AbstractValidator<CreateTransaction>
    {
        public CreateTransactionValidator(ITransactionRepository transactionRepository)
        {
            RuleFor(x => x.hotelId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.hotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.hotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.dateTo)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.dateFrom)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.fullName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(FullName => transactionRepository.GetTransactionName(FullName).Result == null)
                .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(PhoneNumber => transactionRepository.GetTransactionNumber(PhoneNumber).Result == null)
                .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.emailAddress)
                .NotEmpty()
                .WithMessage("must not be empty here");
        }
    }
    public class UpdateTransactionValidator : AbstractValidator<UpdateTransaction>
    {
        public UpdateTransactionValidator(ITransactionRepository transactionRepository)
        {
            RuleFor(x => x.transactionId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(TransactionId => transactionRepository.GetTransactionById(TransactionId).Result == null);
            RuleFor(x => x.hotelId)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.hotelName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.hotelCode)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.dateTo)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.dateFrom)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here");
            RuleFor(x => x.fullName)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(FullName => transactionRepository.GetTransactionName(FullName).Result == null)
                .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("must not be empty here")
                .NotNull()
                .WithMessage("{PropertyName} must not be null test here")
                .Must(PhoneNumber => transactionRepository.GetTransactionNumber(PhoneNumber).Result == null)
                .WithMessage("{PropertyName} already exists.");
            RuleFor(x => x.emailAddress)
                .NotEmpty()
                .WithMessage("must not be empty here");
        }
    }
}
