using hotelApi.Entities;
using hotelApi.DTOS;
using hotelApi.Validator;
using AutoMapper;
using FluentValidation.Results;
using hotelApi.Repository;

namespace hotelApi.Service
{
    public interface IStateService
    {
        Task<List<GetState>> GetAllStates();

        Task<GetState?> GetStateById(int id);

        Task<GetState> CreateState(CreateState state);

        Task<GetState?> UpdateState(int id, UpdateState state);

        Task<bool> DeleteState(int id);

    }
    public class StateService(IStateRepository stateRepository, IMapper mapper) : IStateService
    {
        private readonly IStateRepository stateRepository = stateRepository;
        private readonly IMapper mapper = mapper;

        public async Task<GetState> CreateState(CreateState state)
        {
            CreateStateValidator validator = new(stateRepository);
            ValidationResult results = validator.Validate(state);

            if (results.Errors.Count > 0)
            {
                throw new Exception(string.Join(",", results.Errors.Select(x => x.ErrorMessage).ToList()));
            }
            var createState = await stateRepository.CreateState(mapper.Map<State>(state));
            return mapper.Map<GetState>(createState);
        }

        public async Task<bool> DeleteState(int id)
        {
            var deleteResult = await stateRepository.DeleteState(id);

            return deleteResult;

        }

        public async Task<List<GetState>> GetAllStates()
        {
            var state = await stateRepository.GetAllStates();

            return mapper.Map<List<GetState>>(state);
        }

        public async Task<GetState?> GetStateById(int id)
        {
            var state = await stateRepository.GetStateById(id);

            return mapper.Map<GetState>(state);
        }

        public async Task<GetState?> UpdateState(int id, UpdateState state)
        {
            var updateStateResult = await stateRepository.UpdateState(id, mapper.Map<State>(state));

            return mapper.Map<GetState>(updateStateResult);
        }
    }
}
