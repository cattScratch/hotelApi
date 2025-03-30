using hotelApi.Context;
using hotelApi.Entities;
using hotelApi.Repository;
using Microsoft.EntityFrameworkCore;


namespace hotelApi.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStates();
        Task<State?> GetStateById(int id);
        Task<State> CreateState(State state);
        Task<State?> UpdateState(int id, State state);
        Task<bool> DeleteState(int id);
        Task<State?> GetStateName(string stateName);

    }
    public class StateRepository : IStateRepository
    {
        private readonly DatabaseContext databaseContext;

        public StateRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<State> CreateState(State state)
        {
            databaseContext.States.Add(state);
            await databaseContext.SaveChangesAsync();

            return state;
        }

        public async Task<bool> DeleteState(int id)
        {
            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return false;
            }

            databaseContext.States.Remove(stateRecord);

            await databaseContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<State>> GetAllStates()
        {
            var state = await databaseContext.States.ToListAsync();

            return state;
        }

        public async Task<State?> GetStateById(int id)
        {
            var state = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            return state;
        }

        public async Task<State?> GetStateName(string stateName)
        {
            State? state = await databaseContext.States.FirstOrDefaultAsync(x => x.StateName == stateName);

            return state;
        }

        public async Task<State?> UpdateState(int id, State state)
        {
            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return null;
            }

            stateRecord.StateName = state.StateName;
            stateRecord.StateCode = state.StateCode;

            await databaseContext.SaveChangesAsync();

            return stateRecord;
        }
    }
}