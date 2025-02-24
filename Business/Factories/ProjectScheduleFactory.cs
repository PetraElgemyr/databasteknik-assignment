﻿using Business.Models;
using Business.Models.CusomerAddresses;
using Data.Entities;

namespace Business.Factories;

public static class ProjectScheduleFactory
{

    public static ProjectScheduleEntity CreateEntityFromRegistrationForm(ProjectSchedule schedule)
    {
        return new ProjectScheduleEntity
        {
            StartDate = schedule.StartDate,
            EndDate = schedule.EndDate,
        };
    }

    public static ProjectScheduleEntity CreateEntityFromUpdateFormWithId(ProjectSchedule schedule)
    {
        return new ProjectScheduleEntity
        {
            Id = schedule.Id,
            StartDate = schedule.StartDate,
            EndDate = schedule.EndDate,
        };
    }

    public static ProjectSchedule CreateScheduleFromEntity(ProjectScheduleEntity entity)
    {
        return new ProjectSchedule
        {
            Id = entity.Id,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
        };
    }
}
