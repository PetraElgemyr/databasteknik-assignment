﻿using Data.Entities;

namespace Data.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<IEnumerable<UserEntity>> GetAllByRoleNameAsync(string roleName);
}
