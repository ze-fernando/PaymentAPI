public class Payble
{
    public int Id { get; set; }
    public int TransactionID { get; set; }
    public Status Status { get; set; }
    public DateTime DatePayment { get; set; } = DateTime.Now;
    public double Amount { get; set; }
}