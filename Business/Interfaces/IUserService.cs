﻿using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    Task<IEnumerable<ProjectManager>> GetAllProjectManagersAsync();
}