﻿using EmployeeCrud.Domain;
using EmployeeCrud.Web.Models.DTO;

namespace EmployeeCrud.Web.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll(CancellationToken cancellationToken);
        Task<Employee?> Get(int id, CancellationToken cancellationToken);
        Task<Employee?> Create(EmployeeDTO dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<bool> Update(int id, Employee dto, CancellationToken cancellationToken);
    }
}
