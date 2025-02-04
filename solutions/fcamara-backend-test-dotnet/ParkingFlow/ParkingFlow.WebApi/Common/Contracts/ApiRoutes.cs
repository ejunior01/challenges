namespace ParkingFlow.WebApi.Common.Contracts;

public static class ApiRoutes
{
    public static class Vehicles
    {
        public const string Create = "vehicles";
        public const string Update = "vehicles/{plate}";
        public const string Delete = "vehicles/{plate}";
        public const string Get = "vehicles";
        public const string GetById = "vehicles/{plate}";
    }
}