namespace hotelApi.DTOS
{
    public class CreateCity
    {
        public string CityCode { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public int stateId { get; set; }
    }
    public class Updatecity : CreateCity
    {
        public int Cityid { get; set; }
    }
    public class GetCity
    {
        public int Cityid { get; set; }
        public string CityCode { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public int stateId { get; set; }
    }
}
