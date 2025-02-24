using Business.Factories;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectScheduleService(IProjectScheduleRepository projectRepository)
{
    private readonly IProjectScheduleRepository _projectScheduleRepository = projectRepository;

    //public async Task<ResponseResult<ProjectSchedule?>> GetScheduleByProjectId(int projectId)
    //{
    //    try
    //    {
    //        var entity = await _projectScheduleRepository.GetAsync(schedule => schedule.ProjectId == projectId);
    //        if (entity == null)
    //        {
    //            return ResponseResult<ProjectSchedule?>.NotFound("Schedule not found");
    //        }

    //        var schedule = ProjectScheduleFactory.CreateScheduleFromEntity(entity);
    //        return ResponseResult<ProjectSchedule?>.Ok("", schedule);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //        return ResponseResult<ProjectSchedule?>.Error("An error occurred while trying to get the schedule");
    //    }

    //}
}
