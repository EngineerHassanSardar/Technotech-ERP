namespace CommonModels.Reports
{
    public class DashboardResponse
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalExpenses { get; set; }
        public int LowStockItems { get; set; }
    }
}