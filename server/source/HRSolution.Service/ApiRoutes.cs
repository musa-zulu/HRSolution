namespace HRSolution.Service
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Employee
        {
            public const string GetAll = Base + "/employees";

            public const string Get = Base + "/employees/{personId}";

            public const string GetByDateRange = Base + "/employees/{startDate, endDate}";

            public const string Create = Base + "/employees";

            public const string Update = Base + "/employees";

            public const string Delete = Base + "/employees/{personId}";
        }
    }
}
