using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperStore.Domain.Entity;

public partial class Product_Sale
{
    public int IdSales { get; set; }

    public int IdProduct { get; set; }

    [Key]
    public int Id { get; set; }

    public int Amount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("IdProduct")]
    [InverseProperty("Product_Sales")]
    public virtual Product IdProductNavigation { get; set; }

    [ForeignKey("IdSales")]
    [InverseProperty("Product_Sales")]
    public virtual Sale IdSalesNavigation { get; set; }
}