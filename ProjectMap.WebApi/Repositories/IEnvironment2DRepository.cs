﻿using LarsIProject.WebApi.Models;

namespace LarsIProject.WebApi.Repositories
{
    public interface IEnvironment2DRepository
    {
        Task DeleteAsync(string id);
        Task<Environment2D> InsertAsync(Environment2D environment2D);
        Task<IEnumerable<Environment2D>> ReadAsync(string userID);
        Task<Environment2D?> ReadAsync(Guid id);
        Task UpdateAsync(Environment2D environment);
    }
}