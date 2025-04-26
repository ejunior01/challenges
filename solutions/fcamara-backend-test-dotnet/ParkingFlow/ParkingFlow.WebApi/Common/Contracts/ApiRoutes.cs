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

    public static class Parkings
    {
        public const string Create = "parkings";
        public const string Update = "parkings/{id}";
        public const string Delete = "parkings/{id}";
        public const string Get = "parkings";
        public const string GetById = "parkings/{id}";
        public const string GetByName = "parkings/{name}";
    }
}