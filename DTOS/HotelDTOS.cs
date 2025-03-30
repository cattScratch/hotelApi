namespace hotelApi.DTOS
{
    public class CreateHotel
    {
        public string HotelCode { get; set; } = null!;
        public string HotelName { get; set; } = null!;
        public string HotelDescription { get; set; } = null!;
        public int barangayId { get; set; }
    }
    public class UpdateHotel : CreateHotel
    {
        public int HotelId { get; set; }
    }
    public class GetHotel
    {
        public int HotelId { get; set; }
        public string HotelCode { get; set; } = null!;
        public string HotelName { get; set; } = null!;
        public string HotelDescription { get; set; } = null!;
        public int barangayId { get; set; }
    }
}
