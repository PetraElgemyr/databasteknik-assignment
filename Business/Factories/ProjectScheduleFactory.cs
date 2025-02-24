using Business.Models;
using Business.Models.CusomerAddresses;
using Data.Entities;

namespace Business.Factories;

public static class ProjectScheduleFactory
{

    public static ProjectScheduleEntity CreateEntityFromForm(ProjectSchedule schedule)
    {
        return new ProjectScheduleEntity
        {
            StartDate = schedule.StartDate,
            EndDate = schedule.EndDate,
            ProjectId = schedule.ProjectId
        };
    }

    public static ProjectSchedule CreateScheduleFromEntity(ProjectScheduleEntity entity)
    {
        return new ProjectSchedule
        {
            Id = entity.Id,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            ProjectId = entity.ProjectId
        };
    }
}
