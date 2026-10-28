using System.Net.Http.Json;
using CommonModels.Inventory;
using Core.BaseRepository;

namespace Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly HttpClient _http;

        public InventoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<ProductDto>>("api/inventory");
                return response ?? new List<ProductDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching inventory: {ex.Message}");
                return new List<ProductDto>();
            }
        }
    }
}