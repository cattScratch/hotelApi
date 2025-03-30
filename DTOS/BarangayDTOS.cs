namespace hotelApi.DTOS
{
    public class CreateBarangay
    {
        public string BarangayName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int cityId { get; set; }
    }
    public class UpdateBarangay : CreateBarangay
    {
        public int BarangayId { get; set; }
    }
    public class GetBarangay
    {
        public int BarangayId { get; set; }
        public string BarangayName { get; set; } = null!;
        public string PostalCodde { get; set; } = null!;
        public int cityId { get; set; }
    }
}
