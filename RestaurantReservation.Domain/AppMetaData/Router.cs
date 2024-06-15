﻿namespace RestaurantReservation.Domain.AppMetaData;
public static class Router
{
    public const string SignleRoute = "/{id}";

    public const string root = "Api";
    public const string version = "V1";
    public const string Rule = root + "/" + version + "/";

    public static class RestaurantRouting
    {
        public const string Prefix = Rule + "Restaurant";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }
}