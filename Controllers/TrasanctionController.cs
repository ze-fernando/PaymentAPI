using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
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
                var pay = new Payble
                {
                    TransactionID = transaction.Id,
                    Amount = transaction.Amount * 0.95,
                    Status = "waiting_funds",
                    DatePayment = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy HH:mm")
                };
                return pay;
            }
            else
            {
                var pay = new Payble
                {
                    TransactionID = transaction.Id,
                    Amount = transaction.Amount,
                    Status = "paid"
                };
                return pay;
            }

        }
    }
}