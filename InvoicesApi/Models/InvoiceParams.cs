using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesApi.Models;
public class InvoiceParams
{
    public int CustomerId { get; set; }

    public DateTime Issued { get; set; }

    public double TaxPercentage { get; set; }

    public decimal AmountBeforeTax { get; set; }

    public InvoiceState State { get; set; }

    public Invoice ToInvoice()
    {
        return new Invoice
        {
            CustomerId = CustomerId,
            Issued = Issued,
            TaxPercentage = TaxPercentage,
            AmountBeforeTax = AmountBeforeTax,
            State = State
        };
    }
}
