using Microsoft.EntityFrameworkCore;
using InvoicesApi.Models;

public class InvoiceService
{
    private readonly AppDBContext _context;

    public InvoiceService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await _context.Invoices.Include(i => i.Customer).ToListAsync();
    }

    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        return await _context.Invoices.Include(i => i.Customer).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Invoice> CreateInvoiceAsync(InvoiceParams invoiceParams)
    {   
        var invoice = invoiceParams.ToInvoice();
        Customer customer = await _context.Customers.FindAsync(invoice.CustomerId);
        if (customer == null) throw new Exception("Customer not found");
        invoice.AddressedTo = customer.Name;

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();
        return invoice;
    }

    public async Task<Invoice> UpdateInvoiceAsync(int id, InvoiceParams invoiceUpdate)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null) throw new Exception("Invoice not found");

        if(invoice.CustomerId != invoiceUpdate.CustomerId) {
            Customer customer = await _context.Customers.FindAsync(invoiceUpdate.CustomerId);
            if (customer == null) throw new Exception("Customer not found");
            invoice.AddressedTo = customer.Name;
            invoice.CustomerId = invoiceUpdate.CustomerId;
        }
        
        invoice.Issued = invoiceUpdate.Issued;
        invoice.TaxPercentage = invoiceUpdate.TaxPercentage;
        invoice.AmountBeforeTax = invoiceUpdate.AmountBeforeTax;
        invoice.State = invoiceUpdate.State;

        await _context.SaveChangesAsync();
        return invoice;
    }
}
