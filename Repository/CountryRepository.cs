using hotelApi.Context;
using hotelApi.Entities;
using hotelApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountry();
        Task<Country> getCountryById(int id);
        Task<Country> CreateCountry(Country Country);
        Task<Country> UpdateCountry(int id, Country Country);
        Task<bool> DeleteCountry(int id);
        Task<Country?> GetCountryName(String CountryName);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext databaseContext;
        public CountryRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<Country> CreateCountry(Country Country)
        {
            databaseContext.Countries.Add(Country);
            await databaseContext.SaveChangesAsync();

            return Country;
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var countryRecord = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
            if (countryRecord == null)
            {
                return false;
            }

            databaseContext.Countries.Remove(countryRecord);

            return true;
        }

        public async Task<List<Country>> GetAllCountry()
        {
            var Country = await databaseContext.Countries.ToListAsync();

            return Country;
        }

        public async Task<Country?> getCountryById(int id)
        {
            var Country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);

            return Country;
        }

        public async Task<Country?> GetCountryName(string CountryName)
        {
            Country? Country = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryName == CountryName);

            return Country;
        }

        public async Task<Country> UpdateCountry(int id, Country Country)
        {
            var cityRecord = await databaseContext.Countries.FirstOrDefaultAsync(x => x.CountryId == id);
            if (cityRecord == null)
            {
                return null;
            }

            cityRecord.CountryCode = Country.CountryCode;
            cityRecord.CountryName = Country.CountryName;

            await databaseContext.SaveChangesAsync();

            return cityRecord;

        }
    }
}
