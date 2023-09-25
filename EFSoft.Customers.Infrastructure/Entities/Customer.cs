namespace EFSoft.Customers.Infrastructure.Entities;

public class Customer
{
    [Key]
    public Guid CustomerId { get; set; }


    [Required]
    public string FullName { get; set; }

    [Required]
    public DateTimeOffset DateOfBirth { get; set; }

    [DefaultValue(false)]
    public bool HasOpenOrder { get; set; }

    public bool Deleted { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
