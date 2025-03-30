namespace hotelApi.DTOS
{
    public class CreateTransaction
    {
        public int hotelId { get; set; }
        public string hotelName { get; set; } = null!;
        public string hotelCode { get; set; } = null!;
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public string fullName { get; set; } = null!;
        public string emailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null;
    }
    public class UpdateTransaction : CreateTransaction
    {
        public int transactionId { get; set; }
    }
    public class GetTransaction
    {
        public int transactionId { get; set; }
        public int hotelId { get; set; }
        public string hotelName { get; set; } = null!;
        public string hotelCode { get; set; } = null!;
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public string fullName { get; set; } = null!;
        public string emailAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null;
    }
}
