using Business.Models;
using Business.Models.Projects;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<ResponseResult<Project?>> CreateNewProjectAsync(ProjectRegistrationForm form);
    Task<ResponseResult> DeleteProjectByIdAsync(int id);
    Task<ResponseResult<IEnumerable<ListProject>?>> GetAllProjectsAsync();
    Task<ResponseResult<IEnumerable<ListProject>?>> GetAllProjectsByCustomerIdAsync(int customerId);
    Task<ResponseResult<ProjectWithDetails?>> GetOneProjectByIdAsync(int projectId);
    Task<ResponseResult<Project?>> UpdateProjectAsync(ProjectUpdateForm updateForm);
}