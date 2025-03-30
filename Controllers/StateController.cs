using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelApi.Repository;
using hotelApi.Context;
using hotelApi.Entities;

namespace HotelsApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StatesController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly IStateRepository stateRepository;
        public StatesController(DatabaseContext databaseContext,IStateRepository stateRepository)
        {
            this.databaseContext = databaseContext;
            this.stateRepository = stateRepository;
        }

        [HttpGet()]
        public async Task<List<State>> GetAllStates()
        {
            var states = await databaseContext.States.ToListAsync();
            return states;
        }
        [HttpGet("{id}")]
        public async Task<State?> GetStateById([FromRoute] int id)
        {
            var state = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);
            return state;
        }
        [HttpPost()]
        public async Task<State> CreateState([FromBody] State state)
        {
            databaseContext.States.Add(state);

            await databaseContext.SaveChangesAsync();
            return state;
        }
        [HttpPut("{id}")]
        public async Task<State?> UpdateHotel([FromRoute] int id, [FromBody] State state)
        {
            var stateRecord = await databaseContext.States.FirstOrDefaultAsync(x => x.StateId == id);

            if (stateRecord == null)
            {
                return null;
            }

            stateRecord.StateName = state.StateName;
            stateRecord.StateCode = state.StateCode;

            return stateRecord;
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteRecord([FromRoute] int id)
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
    }
}
