using AutoMapper;
using HRSolution.Data;
using HRSolution.Data.Models;
using HRSolution.Models;
using HRSolution.Models.DTOs;
using HRSolution.Service.Interfaces;
using HRSolution.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSolution.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginator<Person> _employeesPaginator;

        public EmployeeService(
            IApplicationDbContext context,
            IMapper mapper,
            IPaginator<Person> paginator)
        {
            _context = context;
            _mapper = mapper;
            _employeesPaginator = paginator;
        }

        public async Task<ServiceResult<Guid>> Add(PersonDto newPerson)
        {
            var employee = _mapper.Map<Person>(newPerson);
            _context.People.Add(employee);
            await _context.SaveChangesAsync();
            return new ServiceResult<Guid>
            {
                Data = newPerson.PersonId
            };
        }

        public async Task<PagedServiceResult<PersonDto>> GetAll(int page, int perPage)
        {
            var employees = _context.People;

            var pageOfEmployees = await _employeesPaginator
                .BuildPageResult(employees, page, perPage, b => b.PersonId)
                .ToListAsync();

            var paginatedEmployees = _mapper.Map<List<PersonDto>>(pageOfEmployees);

            var paginationResult = new PaginationResult<PersonDto>
            {
                Results = paginatedEmployees,
                PerPage = perPage,
                PageNumber = page
            };

            return new PagedServiceResult<PersonDto>
            {
                Data = paginationResult,
                Error = null
            };
        }

        public async Task<ServiceResult<PersonDto>> GetById(Guid personId)
        {
            var employee = await _context
                        .People.FirstOrDefaultAsync(p => p.PersonId == personId);

            try
            {
                var personDto = _mapper.Map<PersonDto>(employee);

                return new ServiceResult<PersonDto>
                {
                    Data = personDto,
                    Error = null
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<PersonDto>
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

        public async Task<ServiceResult<Guid>> Update(PersonDto personDto)
        {
            var employee = _mapper.Map<Person>(personDto);
            _context.People.Update(employee);
            await _context.SaveChangesAsync();
            return new ServiceResult<Guid>
            {
                Data = employee.PersonId
            };
        }
    }
}
