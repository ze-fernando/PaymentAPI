namespace PaymentAPI.Models
{
    public class Payble
    {
        public int Id { get; set; }
        public int TransactionID { get; set; }
        public string? Status { get; set; }
        public double Amount { get; set; }
        public string? DatePayment { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}