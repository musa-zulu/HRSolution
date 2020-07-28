using HRSolution.Models.DTOs;
using HRSolution.Service.Models;
using System;
using System.Threading.Tasks;

namespace HRSolution.Service.Interfaces
{
    public interface ILeaveService
    {
        Task<PagedServiceResult<LeaveDto>> GetAll(int page, int perPage);
        Task<ServiceResult<LeaveDto>> GetById(Guid leaveId);
        Task<ServiceResult<Guid>> Add(LeaveDto leaveDto);
        Task<ServiceResult<Guid>> Update(LeaveDto leaveDto);
        Task<PagedServiceResult<LeaveDto>> GetByDateRange(DateTime startDate, DateTime endDate, int page, int perPage);
    }
}
