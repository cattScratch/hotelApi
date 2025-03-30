using hotelApi.Context;
using hotelApi.Entities;
using hotelApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Repository
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction?> GetTransactionById(int id);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction?> UpdateTransaction(int id, Transaction transaction);
        Task<bool> DeleteTransaction(int id);
        Task<Transaction?> GetTransactionName(string transactionName);
        Task<Transaction?> GetTransactionNumber(string transactionNumber);
    }

    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext databaseContext;
        public TransactionRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            databaseContext.Transactions.Add(transaction);
            await databaseContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            var transactionRecord = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if (transactionRecord == null)
            {
                return false;
            }

            databaseContext.Transactions.Remove(transactionRecord);

            await databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            var transaction = await databaseContext.Transactions.ToListAsync();

            return transaction;
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            var transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            return transaction;
        }

        public async Task<Transaction?> GetTransactionName(string hotelName)
        {
            Transaction? transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.FullName == hotelName);

            return transaction;
        }

        public async Task<Transaction?> GetTransactionNumber(string hotelNumber)
        {
            Transaction? transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.PhoneNumber == hotelNumber);

            return transaction;
        }

        public async Task<Transaction> UpdateTransaction(int id, Transaction transaction)
        {
            var transactionRecord = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if (transactionRecord == null)
            {
                return null;
            }

            transactionRecord.HotelId = transaction.HotelId;
            transactionRecord.HotelName = transaction.HotelName;
            transactionRecord.HotelCode = transaction.HotelCode;
            transactionRecord.DateTo = transaction.DateTo;
            transactionRecord.DateFrom = transaction.DateFrom;
            transactionRecord.FullName = transaction.FullName;
            transactionRecord.PhoneNumber = transaction.PhoneNumber;
            transactionRecord.EmailAddress = transaction.EmailAddress;

            await databaseContext.SaveChangesAsync();

            return transactionRecord;

        }
    }
}


