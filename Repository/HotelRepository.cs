using hotelApi.Context;
using hotelApi.Entities;
using hotelApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace hotelApi.Repository
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel?> GetHotelById(int id);
        Task<Hotel> CreateHotel(Hotel hotel);
        Task<Hotel> UpdateHotel(int id, Hotel hotel);
        Task<bool> DeleteHotel(int id);

        Task<Hotel?> GetHotelName(String hotelName);
    }
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseContext databaseContext;
        public HotelRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            databaseContext.Hotels.Add(hotel);
            await databaseContext.SaveChangesAsync();

            return hotel;
        }

        public async Task<bool> DeleteHotel(int id)
        {
            var hotelRecord = await databaseContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);

            if (hotelRecord == null)
            {
                return false;
            }

            databaseContext.Hotels.Remove(hotelRecord);

            return true;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            var hotel = await databaseContext.Hotels.ToListAsync();

            return hotel;
        }

        public async Task<Hotel?> GetHotelById(int id)
        {
            var hotel = await databaseContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);

            return hotel;

        }

        public async Task<Hotel?> GetHotelName(string hotelName)
        {
            Hotel? hotel = await databaseContext.Hotels.FirstOrDefaultAsync(x => x.HotelName == hotelName);

            return hotel;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            var hotelRecord = await databaseContext.Hotels.FirstOrDefaultAsync(x => x.HotelId == id);

            if (hotelRecord == null)
            {
                return null;
            }

            hotelRecord.HotelCode = hotel.HotelCode;
            hotelRecord.HotelName = hotel.HotelName;
            hotelRecord.HotelDescription = hotel.HotelDescription;

            await databaseContext.SaveChangesAsync();

            return hotelRecord;
        }


    }



}
