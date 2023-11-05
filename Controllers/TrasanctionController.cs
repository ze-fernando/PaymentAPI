using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
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

            Payble pay;
            string[]? card = transaction.CardNumber?.Split(' ');
            transaction.CardNumber = card?[3];

            if (transaction.Method != "debt")
            {
                pay = new Payble
                {
                    TransactionId = transaction.Id,
                    Amount = transaction.Amount * 0.95,
                    Status = "waiting_funds",
                    DatePayment = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy HH:mm")
                };
            }

            else
            {
                pay = new Payble
                {
                    TransactionId = transaction.Id,
                    Amount = transaction.Amount,
                    Status = "paid"
                };
            }

            using (var db = new PaymentContext())
            {

                db.Transactions.Add(transaction);
                db.Payble.Add(pay);
                db.SaveChanges();
            }

                return pay;
        }
    }
}
