using System;
using System.Collections.Generic;

namespace hotelApi.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? HotelCode { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual Hotel? Hotel { get; set; }
}
