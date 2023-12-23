using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoicesApi.Models;
public class Invoice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Customer")]
    [JsonIgnore]
    public int CustomerId { get; set; }

    [Required]
    public DateTime Issued { get; set; }

    [Required]
    public InvoiceState State { get; set; }

    //This is the name of the person or company that the invoice is addressed to.
    //It is the customer's name at the time of the invoice.
    //Invoices are legal documents and should not be changed after they are issued.
    [Required]
    [StringLength(150)]
    public string AddressedTo { get; set; }

    [Required]
    public double TaxPercentage { get; set; }

    [Required]
    public decimal AmountBeforeTax { get; set; }

    public Customer Customer { get; set; }
}
