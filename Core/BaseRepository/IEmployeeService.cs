using CommonModels.Employees;
namespace Core.BaseRepository
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployeesAsync();
    }
}