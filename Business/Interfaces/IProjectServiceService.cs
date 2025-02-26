using Business.Models;
using Business.Models.ProjectServices;

namespace Business.Services;

public interface IProjectServiceService
{
    Task<ResponseResult<ProjectServiceWithDetails?>> CreateNewProjectServiceAsync(ProjectServiceRegistrationForm form);
    Task<ResponseResult> DeleteProjectServiceByIdAsync(int projectId, int serviceId);
    Task<ResponseResult<IEnumerable<ProjectServiceWithDetails>>> GetProjectServicesByProjectIdAsync(int projectId);
}