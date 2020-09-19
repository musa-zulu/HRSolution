using AutoMapper;
using HRSolution.Models.DTOs;
using HRSolution.Service.Features.Common;
using HRSolution.Service.Features.EmployeeFeatures.Commands;
using HRSolution.Service.Features.EmployeeFeatures.Exceptions;
using HRSolution.Service.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CommandResult>
{
    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IEmployeeService employeeService, IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }
    public async Task<CommandResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await HandleCreateEmployee(request, cancellationToken);
    }

    private async Task<CommandResult> HandleCreateEmployee<T>(T request, CancellationToken cancellationToken)
    {
        try
        {
            var person = _mapper.Map<PersonDto>(request);
            var newEmployee = await _employeeService.Add(person);

            return CommandResult.Success(newEmployee.Data);
        }
        catch (Exception ex)
        {
            return CommandResult.Error(new CreateEmployeeException("There was an error creating the employee", ex));
        }
    }
}