using HRSolution.Contracts.Interfaces.Services;

namespace HRSolution.Contracts.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
    }
}