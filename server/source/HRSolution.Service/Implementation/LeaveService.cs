using AutoMapper;
using HRSolution.Data;
using HRSolution.Data.Models;
using HRSolution.Models;
using HRSolution.Models.DTOs;
using HRSolution.Service.Helpers;
using HRSolution.Service.Interfaces;
using HRSolution.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSolution.Service.Implementation
{
    public class LeaveService : BaseHrSolutionService, ILeaveService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly Paginator<Leave> _paginator;

        public LeaveService(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _paginator = new Paginator<Leave>();
        }

        public async Task<ServiceResult<Guid>> Add(LeaveDto leaveDto)
        {
            var leave = _mapper.Map<Leave>(leaveDto);
            _context.Leaves.Add(leave);
            await _context.SaveChangesAsync();
            return new ServiceResult<Guid>
            {
                Data = leave.LeaveId
            };
        }

        public async Task<PagedServiceResult<LeaveDto>> GetAll(int page, int perPage)
        {
            var leaves = _context.Leaves;
            try
            {
                var pageOfLeaves = await _paginator
                    .BuildPageResult(leaves, page, perPage, b => b.LeaveId)
                    .ToListAsync();

                var paginatedLeaves = _mapper.Map<List<LeaveDto>>(pageOfLeaves);

                var paginationResult = new PaginationResult<LeaveDto>
                {
                    Results = paginatedLeaves,
                    PerPage = perPage,
                    PageNumber = page
                };

                return new PagedServiceResult<LeaveDto>
                {
                    Data = paginationResult,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return HandleDatabaseCollectionError<LeaveDto>(ex);
            }
        }

        public async Task<PagedServiceResult<LeaveDto>> GetByDateRange(DateTime startDate, DateTime endDate, int page, int perPage)
        {
            var leaves = _context.Leaves.Where(s => s.StartDate == startDate && s.EndDate == endDate);

            var pageOfLeaves = await _paginator
                .BuildPageResult(leaves, page, perPage, b => b.LeaveId)
                .ToListAsync();

            var paginatedLeaves = _mapper.Map<List<LeaveDto>>(pageOfLeaves);

            var paginationResult = new PaginationResult<LeaveDto>
            {
                Results = paginatedLeaves,
                PerPage = perPage,
                PageNumber = page
            };

            return new PagedServiceResult<LeaveDto>
            {
                Data = paginationResult,
                Error = null
            };
        }

        public async Task<ServiceResult<LeaveDto>> GetById(Guid leaveId)
        {
            var leave = await _context.Leaves.FirstOrDefaultAsync(p => p.LeaveId == leaveId);

            try
            {
                var leaveDto = _mapper.Map<LeaveDto>(leave);

                return new ServiceResult<LeaveDto>
                {
                    Data = leaveDto,
                    Error = null
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<LeaveDto>
                {
                    Data = null,
                    Error = new ServiceError
                    {
                        Message = e.Message,
                        Stacktrace = e.StackTrace
                    }
                };
            }
        }

        public async Task<ServiceResult<Guid>> Update(LeaveDto leaveDto)
        {
            var leave = _mapper.Map<Leave>(leaveDto);
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
            return new ServiceResult<Guid>
            {
                Data = leave.LeaveId
            };
        }
    }
}
