using HRSolution.Models.DTOs;
using HRSolution.Service.Models;
using System;
using System.Threading.Tasks;

namespace HRSolution.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<PagedServiceResult<PersonDto>> GetAll(int page, int perPage);
        Task<ServiceResult<PersonDto>> GetById(Guid personId);
        Task<ServiceResult<Guid>> Add(PersonDto newPerson);
        Task<ServiceResult<Guid>> Update(PersonDto personDto);
    }
}
