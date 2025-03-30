using hotelApi.Entities;
using hotelApi.DTOS;
using hotelApi.Validator;
using AutoMapper;
using FluentValidation.Results;
using hotelApi.Repository;

namespace hotelApi.Service
{
    public interface ICityService
    {
        Task<List<GetCity>> GetAllCities();

        Task<GetCity?> GetCityById(int id);

        Task<GetCity> CreateCity(CreateCity city);

        Task<GetCity?> UpdateCity(int id, Updatecity city);

        Task<bool> DeleteCity(int id);
    }
    public class CityService(ICityRepository cityRepository, IMapper mapper) : ICityService
    {
        private readonly ICityRepository cityRepository = cityRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetCity> CreateCity(CreateCity city)
        {
            CreateCityValidator validator = new(cityRepository);
            ValidationResult results = validator.Validate(city);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createCity = await cityRepository.CreateCity(mapper.Map<City>(city));
            return mapper.Map<GetCity>(createCity);
        }

        public async Task<bool> DeleteCity(int id)
        {
            var deleteResult = await cityRepository.DeleteCity(id);

            return deleteResult;
        }

        public async Task<List<GetCity>> GetAllCities()
        {
            var city = await cityRepository.GetAllCity();

            return mapper.Map<List<GetCity>>(city);
        }

        public async Task<GetCity?> GetCityById(int id)
        {
            var city = await cityRepository.GetCityById(id);

            return mapper.Map<GetCity>(city);
        }

        public async Task<GetCity?> UpdateCity(int id, Updatecity city)
        {
            var updateCityResult = await cityRepository.UpdateCity(id, mapper.Map<City>(city));

            return mapper.Map<GetCity>(updateCityResult);
        }
    }
}
