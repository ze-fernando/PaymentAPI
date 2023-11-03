namespace PaymentAPI.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public Method Method { get; set; }
        public string? CardNumber { get; set; }
        public string? Name { get; set; }
        public string? Validation { get; set; }
        public int Cvv { get; set; }
    }
}