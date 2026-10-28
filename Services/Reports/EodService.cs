using System.Net.Http.Json;
using CommonModels.Reports;
using Core.BaseRepository;

namespace Services.Reports
{
    public class EodService : IEodService
    {
        private readonly HttpClient _http;
        public EodService(HttpClient http) => _http = http;

        public async Task<EodResponse> GetEodReportAsync(DateTime date)
        {
            // Update "api/eod" to your real endpoint
            var url = $"api/eod?date={date:yyyy-MM-dd}";
            return await _http.GetFromJsonAsync<EodResponse>(url) ?? new EodResponse();
        }
    }
}