using CommonModels.Reports;

namespace Core.BaseRepository
{
    public interface IDashboardService
    {
        Task<DashboardResponse> GetDashboardDataAsync();
    }
}