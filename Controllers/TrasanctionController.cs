using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;

[ApiController]
[Route("v1")]
public class TrasanctionController : ControllerBase
{
    [HttpPost("cash-in")]
    public Payble CreateTransaction([FromBody] Transactions transaction)
    {
        string[]? card = transaction.CardNumber?.Split(' ');
        transaction.CardNumber = card?[3];
        
        
        if (transaction.Method != "debt")
        {
            var pay = new Payble{
                TransactionID = transaction.Id,
                Amount = transaction.Amount * 0.95,
                Status = "waiting_funds",
                DatePayment = DateTime.Now.AddDays(30)
            };
            return pay;
        }
        else{
            var pay = new Payble{
                TransactionID = transaction.Id,
                Amount = transaction.Amount,
                Status = "paid",
                DatePayment = DateTime.Now
            };
            return pay;
        }
        
    }
}
//https://github.com/pagarme/vagas/blob/master/desafios/software-engineer-backend/README.md