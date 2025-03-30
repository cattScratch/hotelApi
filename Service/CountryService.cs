using hotelApi.Entities;
using hotelApi.DTOS;
using hotelApi.Validator;
using AutoMapper;
using FluentValidation.Results;
using hotelApi.Repository;


namespace hotelApi.Service
{
    public interface ICountryService
    {
        Task<List<GetCountry>> GetAllCountries();

        Task<GetCountry?> GetCountryById(int id);

        Task<GetCountry> CreateCountry(CreateCountry country);

        Task<GetCountry?> UpdateCountry(int id, UpdateCountry country);

        Task<bool> DeleteCountry(int id);
    }
    public class CountryService(ICountryRepository countryRepository, IMapper mapper) : ICountryService
    {
        private readonly ICountryRepository countryRepository = countryRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetCountry> CreateCountry(CreateCountry country)
        {
            CreateCountryValidator validator = new(countryRepository);
            ValidationResult results = validator.Validate(country);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createCountry = await countryRepository.CreateCountry(mapper.Map<Country>(country));
            return mapper.Map<GetCountry>(createCountry);
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var deleteResult = await countryRepository.DeleteCountry(id);

            return deleteResult;
        }

        public async Task<List<GetCountry>> GetAllCountries()
        {
            var country = await countryRepository.GetAllCountry();

            return mapper.Map<List<GetCountry>>(country);
        }

        public async Task<GetCountry?> GetCountryById(int id)
        {
            var country = await countryRepository.getCountryById(id);

            return mapper.Map<GetCountry>(country);
        }

        public async Task<GetCountry?> UpdateCountry(int id, UpdateCountry country)
        {
            var updateCountryResult = await countryRepository.UpdateCountry(id, mapper.Map<Country>(country));

            return mapper.Map<GetCountry>(updateCountryResult);
        }
    }
}
