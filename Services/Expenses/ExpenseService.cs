using System.Net.Http.Json;
using CommonModels.Expenses;
using Core.BaseRepository;

namespace Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _http;
        public ExpenseService(HttpClient http) => _http = http;

        public async Task<List<ExpenseDto>> GetExpensesAsync()
        {
            // Update "api/expenses" to your real endpoint
            return await _http.GetFromJsonAsync<List<ExpenseDto>>("api/expenses") ?? new List<ExpenseDto>();
        }
    }
}