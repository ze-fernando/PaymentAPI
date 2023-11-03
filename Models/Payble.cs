public class Payble
{
    public int Id { get; set; }
    public int TransactionID { get; set; }
    public string? Status { get; set; }
    public double Amount { get; set; }
    public DateTime DatePayment { get; set; }
}