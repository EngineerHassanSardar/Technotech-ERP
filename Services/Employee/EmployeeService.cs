using System.Net.Http.Json;
using CommonModels.Employees;
using Core.BaseRepository;

namespace Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        public EmployeeService(HttpClient http) => _http = http;

        public async Task<List<EmployeeDto>> GetEmployeesAsync()
        {
            // Update "api/employees" to your real endpoint
            return await _http.GetFromJsonAsync<List<EmployeeDto>>("api/employees") ?? new List<EmployeeDto>();
        }
    }
}