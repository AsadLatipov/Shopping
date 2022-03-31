using Shopping.Domain.Enums;
using System;

namespace Shopping.Domain.Commons
{
    public interface IAuditable
    {
        Guid Id { get; set; }
        ItemState State { get; set; }

    }
}
