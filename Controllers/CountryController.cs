using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelApi.Repository;
using hotelApi.Context;
using hotelApi.Entities;

namespace HotelsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly DatabaseContext databaseContext;

        public CountryController(DatabaseContext databaseContext, ICountryRepository countryRepository)
        {
            this.databaseContext = databaseContext;
            this.countryRepository = countryRepository;
        }
        [HttpGet()]
        public async Task<List<Country>> GetAllCountry()
        {
            var country = await databaseContext.Countries.ToListAsync();
            return country;
        }
        [HttpGet("{id}")]
        public async Task<Country?> GetCountryById([FromRoute] int id)
        {
            var country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
            return country;
        }
        [HttpPost()]
        public async Task<Country> CreateCountry([FromBody] Country country)
        {
            databaseContext.Countries.Add(country);
            await databaseContext.SaveChangesAsync();
            return country;
        }
        [HttpPut("{id}")]
        public async Task<Country> UpdateCountry([FromRoute] int id, [FromBody] Country country)
        {
            var recordCountry = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            if (recordCountry == null)
            {
                return null;
            }

            recordCountry.CountryCode = country.CountryCode;
            recordCountry.CountryName = country.CountryName;

            await databaseContext.SaveChangesAsync();

            return recordCountry;
        }
        [HttpDelete("{id}")]
        public async Task<bool?> DeleteCountry([FromRoute] int id)
        {
            var recordCountry = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            if (recordCountry == null)
            {
                return false;
            }

            databaseContext.Countries.Remove(recordCountry);

            await databaseContext.SaveChangesAsync();

            return true;

        }

    }
}
