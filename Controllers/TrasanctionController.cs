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
            using (var db = new PaymentContext())
            {
                string status, date;
                double amount;

                if (transaction.Method == "debt")
                {
                    amount = transaction.Amount;
                    status = "paid";
                    date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    amount = transaction.Amount * 0.95;
                    status = "waiting_funds";
                    date = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy HH:mm");
                }

                string[]? card = transaction.CardNumber?.Split(' ');
                transaction.CardNumber = card?[3];

                db.Transactions.Add(transaction);
                db.SaveChanges();

                pay = new Payble{
                    Status = status,
                    Amount = amount,
                    DatePayment = date,
                    TransactionId = transaction.Id
                };

                db.Payble.Add(pay);
                db.SaveChanges();
            }

                return pay;
        }

    
        [HttpGet("transactions")]
        public List<Transactions> AllTransactions()
        {
            List<Transactions> transactions;
            using (var database = new PaymentContext())
            {
                transactions = database.Transactions.ToList();
            }

            return transactions;
        }
    
        [HttpGet("transactions/{card}")]
        public List<Transactions> TransactionByCard([FromRoute] string card)
        {
            List<Transactions> transactions;
            using (var database = new PaymentContext())
            {
                transactions = database.Transactions.
                Where(n => n.CardNumber == card)
                .OrderBy(a => a.Amount)
                .ToList();
            }

            return transactions;
        }
    }
}
