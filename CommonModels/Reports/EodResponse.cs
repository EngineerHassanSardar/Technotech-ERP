namespace CommonModels.Reports
{
    public class EodResponse
    {
        public decimal TotalSales { get; set; }
        public int TransactionCount { get; set; }
        public decimal CashTotal { get; set; }
        public decimal CardTotal { get; set; }
    }
}