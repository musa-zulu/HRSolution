using HRSolution.Data.Requests;
using System.Threading.Tasks;

namespace HRSolution.Service.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}