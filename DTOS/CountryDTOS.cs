namespace hotelApi.DTOS
{
    public class CreateCountry
    {
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; } = null!;

    }
    public class UpdateCountry : CreateCountry
    {
        public int CountryId { get; set; }
    }
    public class GetCountry
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; } = null!;
    }
}
