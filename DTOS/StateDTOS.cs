namespace hotelApi.DTOS
{
    public class CreateState 
    {
        public string StateCode { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public int countryId { get; set; }
    }
    public class UpdateState : CreateState
    {
        public int StateId { get; set; }
    }
    public class GetState
    {
        public int StateId { get; set; }
        public string StateCode { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public int countryId { get; set; }
    }
}
