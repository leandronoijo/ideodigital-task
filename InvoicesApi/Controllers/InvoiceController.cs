using Microsoft.AspNetCore.Mvc;
using InvoicesApi.Models;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly InvoiceService _invoiceService;

    public InvoiceController(InvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _invoiceService.GetAllInvoicesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InvoiceParams invoice)
    {
        var createdInvoice = await _invoiceService.CreateInvoiceAsync(invoice);
        return CreatedAtAction(nameof(GetById), new { id = createdInvoice.Id }, createdInvoice);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, InvoiceParams invoice)
    {
        var updatedInvoice = await _invoiceService.UpdateInvoiceAsync(id, invoice);
        if (updatedInvoice == null)
        {
            return NotFound();
        }
        return Ok(updatedInvoice);
    }
}
