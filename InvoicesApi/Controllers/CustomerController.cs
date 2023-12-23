using Microsoft.AspNetCore.Mvc;
using InvoicesApi.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{    
    private readonly AppDBContext _context;
    public CustomerController(AppDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Customer>> GetAll()
    {
        List<Customer> customers = await _context.Customers.ToListAsync();
        return customers;
    }
}
