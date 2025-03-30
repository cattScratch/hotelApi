using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelApi.Entities;
using hotelApi.Repository;
using hotelApi.Context;

namespace HotelsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly DatabaseContext databaseContext;
        public TransactionController(DatabaseContext databaseContext, ITransactionRepository transactionRepository)
        {
            this.databaseContext = databaseContext;
            this.transactionRepository = transactionRepository;
        }

        [HttpGet()]
        public async Task<List<Transaction>> GetAllTransaction()
        {
            var transaction = await databaseContext.Transactions.ToListAsync();
            return transaction;
        }
        [HttpGet("{id}")]
        public async Task<Transaction> GetTransactionById([FromRoute] int id)
        {
            var transaction = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);
            return transaction;
        }
        [HttpPost()]
        public async Task<Transaction> CreaateHotel([FromRoute] int id, [FromBody] Transaction transaction)
        {
            databaseContext.Transactions.Add(transaction);
            await databaseContext.SaveChangesAsync();
            return transaction;
        }
        [HttpPut("{id}")]
        public async Task<Transaction?> UpdateTransaction([FromRoute] int id, [FromBody] Transaction transaction)
        {
            var transactionRecord = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);
            if (transactionRecord == null)
            {
                return null;
            }
            transactionRecord.FullName = transaction.FullName;
            transactionRecord.HotelName = transaction.HotelName;
            transactionRecord.EmailAddress = transaction.EmailAddress;
            transactionRecord.PhoneNumber = transaction.PhoneNumber;

            await databaseContext.SaveChangesAsync();

            return transaction;
        }
        [HttpDelete("{id}")]
        public async Task<bool?> DeleteTransaction([FromRoute] int id)
        {
            var transactionRecord = await databaseContext.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if (transactionRecord == null)
            {
                return null;
            }
            databaseContext.Transactions.Remove(transactionRecord);

            await databaseContext.SaveChangesAsync();

            return true;
        }
    }
}
