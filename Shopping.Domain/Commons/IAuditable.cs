using Shopping.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Domain.Commons
{
    public interface IAuditable
    {
        Guid Id { get; set; }
        ItemState State { get; set; }

    }
}
