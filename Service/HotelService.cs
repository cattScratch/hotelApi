using hotelApi.Entities;
using hotelApi.DTOS;
using hotelApi.Validator;
using AutoMapper;
using FluentValidation.Results;
using hotelApi.Repository;

namespace hotelApi.Service
{
    public interface IHotelService
    {
        Task<List<GetHotel>> GetAllHotels();

        Task<GetHotel?> GetHotelById(int id);

        Task<GetHotel> CreateHotel(CreateHotel hotel);

        Task<GetHotel?> UpdateHotel(int id, UpdateHotel hotel);

        Task<bool> DeleteHotel(int id);

    }
    public class HotelService(IHotelRepository hotelRepository, IMapper mapper) : IHotelService
    {
        private readonly IHotelRepository hotelRepository = hotelRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetHotel> CreateHotel(CreateHotel hotel)
        {
            CreateHotelValidator validator = new(hotelRepository);
            ValidationResult results = validator.Validate(hotel);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createHotel = await hotelRepository.CreateHotel(mapper.Map<Hotel>(hotel));
            return mapper.Map<GetHotel>(createHotel);
        }

        public async Task<bool> DeleteHotel(int id)
        {
            var deleteResult = await hotelRepository.DeleteHotel(id);

            return deleteResult;
        }

        public async Task<List<GetHotel>> GetAllHotels()
        {
            var hotel = await hotelRepository.GetAllHotels();

            return mapper.Map<List<GetHotel>>(hotel);
        }

        public async Task<GetHotel?> GetHotelById(int id)
        {
            var hotel = await hotelRepository.GetHotelById(id);

            return mapper.Map<GetHotel>(hotel);
        }

        public async Task<GetHotel?> UpdateHotel(int id, UpdateHotel hotel)
        {
            var updateHotelResult = await hotelRepository.UpdateHotel(id, mapper.Map<Hotel>(hotel));

            return mapper.Map<GetHotel>(updateHotelResult);
        }
    }
}
