
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelApi.Repository;
using hotelApi.Context;
using hotelApi.Entities;

namespace hotelApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BarangaysController : ControllerBase
    {
        private readonly IBarangayRepository barangayRepository;
        private readonly DatabaseContext databaseContext;

        public BarangaysController(DatabaseContext databaseContext, IBarangayRepository barangayRepository)
        {
            this.databaseContext = databaseContext;
            this.barangayRepository = barangayRepository;
        }

        [HttpGet()]
        public async Task<List<Barangay>> GetAllBarangays()
        {
            var barangay = await databaseContext.Barangays.ToListAsync();

            return barangay;
        }

        [HttpGet("{id}")]
        public async Task<Barangay?> GetBarangayById([FromRoute] int id)
        {
            var barangay = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            return barangay;
        }

        [HttpPost()]
        public async Task<Barangay> CreateBarangay([FromBody] Barangay barangay)
        {
            databaseContext.Barangays.Add(barangay);
            await databaseContext.SaveChangesAsync();

            return barangay;
        }

        [HttpPut("{id}")]
        public async Task<Barangay?> UpdateBarangay([FromRoute] int id, [FromBody] Barangay barangay)
        {

            var barangayRecord = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            if (barangayRecord == null)
            {
                return null;
            }

            barangayRecord.BarangayName = barangay.BarangayName;
            barangayRecord.PostalCode = barangay.PostalCode;

            await databaseContext.SaveChangesAsync();

            return barangayRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBarangay([FromRoute] int id)
        {
            var barangayRecord = await databaseContext.Barangays.FirstOrDefaultAsync(x => x.BarangayId == id);

            if (barangayRecord == null)
            {
                return false;
            }

            databaseContext.Barangays.Remove(barangayRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }
    }
}