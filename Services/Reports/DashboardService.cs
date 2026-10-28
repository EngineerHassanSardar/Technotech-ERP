using System.Net.Http.Json;
using CommonModels.Reports;
using Core.BaseRepository;

namespace Services.Reports
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _http;

        public DashboardService(HttpClient http)
        {
            _http = http;
        }

        public async Task<DashboardResponse> GetDashboardDataAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<DashboardResponse>("api/dashboard");
                return response ?? new DashboardResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching dashboard: {ex.Message}");
                return new DashboardResponse();
            }
        }
    }
}