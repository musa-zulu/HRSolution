using System;

namespace HRSolution.Service.Features.EmployeeFeatures.Exceptions
{
    [Serializable]
	internal class CreateEmployeeException : Exception
	{
		public CreateEmployeeException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
