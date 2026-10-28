using CommonModels.Expenses;

namespace Core.BaseRepository
{
    public interface IExpenseService // MUST say public
    {
        Task<List<ExpenseDto>> GetExpensesAsync();
    }
}