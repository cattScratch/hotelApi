using System;
using System.Collections.Generic;

namespace hotelApi.Entities;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelCode { get; set; } = null!;

    public string HotelName { get; set; } = null!;

    public string HotelDescription { get; set; } = null!;

    public int? BarangayId { get; set; }

    public virtual Barangay? Barangay { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
