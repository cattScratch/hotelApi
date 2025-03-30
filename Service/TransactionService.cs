using hotelApi.Entities;
using hotelApi.DTOS;
using hotelApi.Validator;
using AutoMapper;
using FluentValidation.Results;
using hotelApi.Repository;

namespace hotelApi.Service
{
    public interface ITransactionService
    {
        Task<List<GetTransaction>> GetAllTransactions();

        Task<GetTransaction?> GetTransactionById(int id);

        Task<GetTransaction> CreateTransaction(CreateTransaction transaction);

        Task<GetTransaction?> UpdateTransaction(int id, UpdateTransaction transaction);

        Task<bool> DeleteTransaction(int id);

    }
    public class TransactionService(ITransactionRepository transactionRepository, IMapper mapper) : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository = transactionRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetTransaction> CreateTransaction(CreateTransaction transaction)
        {
            CreateTransactionValidator validator = new(transactionRepository);
            ValidationResult results = validator.Validate(transaction);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createTransaction = await transactionRepository.CreateTransaction(mapper.Map<Transaction>(transaction));
            return mapper.Map<GetTransaction>(createTransaction);
        }
        public async Task<bool> DeleteTransaction(int id)
        {
            var deleteResult = await transactionRepository.DeleteTransaction(id);

            return deleteResult;


        }

        public async Task<List<GetTransaction>> GetAllTransactions()
        {
            var transaction = await transactionRepository.GetAllTransactions();

            return mapper.Map<List<GetTransaction>>(transaction);
        }

        public async Task<GetTransaction?> GetTransactionById(int id)
        {
            var transaction = await transactionRepository.GetTransactionById(id);

            return mapper.Map<GetTransaction>(transaction);
        }

        public async Task<GetTransaction?> UpdateTransaction(int id, UpdateTransaction transaction)
        {
            var updateTransactionResult = await transactionRepository.UpdateTransaction(id, mapper.Map<Transaction>(transaction));

            return mapper.Map<GetTransaction>(updateTransactionResult);
        }
    }
}
