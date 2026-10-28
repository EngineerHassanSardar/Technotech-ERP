using CommonModels.Inventory;

namespace Core.BaseRepository
{
    public interface IInventoryService
    {
        Task<List<ProductDto>> GetProductsAsync();
    }
}