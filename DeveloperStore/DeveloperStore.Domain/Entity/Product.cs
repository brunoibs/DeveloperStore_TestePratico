using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DeveloperStore.Domain.Entity;

[Table("Product")]
[Index("Name", Name = "UQ__Produto__737584F62F9328BF", IsUnique = true)]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string Name { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int Amount { get; set; }

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<Product_Sale> Product_Sales { get; set; } = new List<Product_Sale>();
}