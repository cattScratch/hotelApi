using hotelApi.Entities;
using hotelApi.DTOS;
using hotelApi.Validator;
using AutoMapper;
using FluentValidation.Results;
using hotelApi.Repository;

namespace hotelApi.Service
{
    public interface IBarangayService
    {
        Task<List<GetBarangay>> GetAllBarangays();

        Task<GetBarangay?> GetBarangayById(int id);

        Task<GetBarangay> CreateBarangay(CreateBarangay barangay);

        Task<GetBarangay?> UpdateBarangay(int id, UpdateBarangay barangay);

        Task<bool> DeleteBarangay(int id);
    }
    public class BarangayService(IBarangayRepository barangayRepository, IMapper mapper) : IBarangayService
    {
        private readonly IBarangayRepository barangayRepository;
        private readonly IMapper mapper;
        public async Task<GetBarangay> CreateBarangay(CreateBarangay barangay)
        {
            CreateBarangayValidator validator = new CreateBarangayValidator(barangayRepository);
            ValidationResult results = validator.Validate(barangay);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }

            var createdBarangay = await barangayRepository.CreateBarangay(mapper.Map<Barangay>(barangay));

            return mapper.Map<GetBarangay>(createdBarangay);
        }

        public async Task<bool> DeleteBarangay(int id)
        {
            var deleteResult = await barangayRepository.DeleteBarangay(id);

            return deleteResult;
        }

        public async Task<List<GetBarangay>> GetAllBarangays()
        {
            var barangay = await barangayRepository.GetAllBarangay();

            return mapper.Map<List<GetBarangay>>(barangay);
        }

        public async Task<GetBarangay?> GetBarangayById(int id)
        {
            var barangay = await barangayRepository.GetBarangayById(id);
            return mapper.Map<GetBarangay>(barangay);
        }

        public async Task<GetBarangay?> UpdateBarangay(int id, UpdateBarangay barangay)
        {
            var updateBarangayResult = await barangayRepository.UpdateBarangay(id, mapper.Map<Barangay>(barangay));

            return mapper.Map<GetBarangay>(updateBarangayResult);
        }
    }
}
