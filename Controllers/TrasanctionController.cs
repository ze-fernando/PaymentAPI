using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;

[ApiController]
[Route("v1")]
public class TrasanctionController : Controller
{
    [HttpPost("cash-in")]
    public Task<ActionResult> CreateTransaction([FromBody] Transactions transaction)
    {
        Console.WriteLine(transaction.Name);
        Console.WriteLine(transaction.Amount);
        Console.WriteLine(transaction.Cvv);
        return Task.FromResult<ActionResult>(Ok());
    }
}