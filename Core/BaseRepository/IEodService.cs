using CommonModels.Reports;
namespace Core.BaseRepository
{
    public interface IEodService
    {
        Task<EodResponse> GetEodReportAsync(DateTime date);
    }
}