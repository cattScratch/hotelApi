using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelApi.Repository;
using hotelApi.Context;
using hotelApi.Entities;


namespace hotelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;
        private readonly DatabaseContext databaseContext;
        public CityController(DatabaseContext databaseContext, ICityRepository cityRepository)
        {
            this.databaseContext = databaseContext;
            this.cityRepository = cityRepository;
        }

        [HttpGet()]
        public async Task<List<City>> GetAllCity()
        {
            var city = await databaseContext.Cities.ToListAsync();

            return city;
        }

        [HttpGet("{id}")]
        public async Task<City> GetCityById([FromRoute] int id)
        {
            var city = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            return city;
        }
        [HttpPost()]
        public async Task<City> CreateCity([FromBody] City city)
        {
            databaseContext.Cities.Add(city);
            await databaseContext.SaveChangesAsync();

            return city;
        }
        [HttpPut("{id}")]
        public async Task<City?> UpdateCity([FromRoute] int id, [FromBody] City city)
        {

            var cityRecord = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            if (cityRecord == null)
            {
                return null;
            }

            cityRecord.CityName = city.CityName;
            cityRecord.CityCode = city.CityCode;

            await databaseContext.SaveChangesAsync();

            return cityRecord;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCity([FromRoute] int id)
        {
            var cityRecord = await databaseContext.Cities.FirstOrDefaultAsync(x => x.CityId == id);

            if (cityRecord == null)
            {
                return false;
            }

            databaseContext.Cities.Remove(cityRecord);

            await databaseContext.SaveChangesAsync();

            return true;

        }
    }
}
