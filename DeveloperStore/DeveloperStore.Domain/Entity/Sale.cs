using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperStore.Domain.Entity;

[Table("Sale")]
public partial class Sale
{
    [Key]
    public int Id { get; set; }

    public DateTime Dt_Sale { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    [InverseProperty("IdSalesNavigation")]
    public virtual ICollection<Product_Sale> Product_Sales { get; set; } = new List<Product_Sale>();
}