using hotelApi.Context;
using hotelApi.Entities;
using hotelApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCity();
        Task<City> GetCityById(int id);
        Task<City> CreateCity(City city);
        Task<City> UpdateCity(int id, City city);
        Task<bool> DeleteCity(int id);
        Task<City?> GetCityName(string cityName);
    }

    public class CityRepository : ICityRepository
    {
        private readonly DatabaseContext databaseContext;
        public CityRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<City> CreateCity(City city)
        {
            databaseContext.Cities.Add(city);
            await databaseContext.SaveChangesAsync();

            return city;
        }

        public async Task<bool> DeleteCity(int id)
        {
            var cityRecord = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);
            if (cityRecord == null)
            {
                return false;
            }

            databaseContext.Cities.Remove(cityRecord);

            return true;
        }

        public async Task<List<City>> GetAllCity()
        {
            var city = await databaseContext.Cities.ToListAsync();

            return city;
        }

        public async Task<City?> GetCityById(int id)
        {
            var city = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            return city;
        }

        public async Task<City?> GetCityName(string cityName)
        {
            City? city = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityName == cityName);

            return city;
        }

        public async Task<City> UpdateCity(int id, City city)
        {
            var cityRecord = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);
            if (cityRecord == null)
            {
                return null;
            }

            cityRecord.CityCode = city.CityCode;
            cityRecord.CityName = city.CityName;

            await databaseContext.SaveChangesAsync();

            return cityRecord;

        }
    }
}


