namespace RestaurantReservation.Domain.AppMetaData;
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
    public static class TableRouting
    {
        public const string Prefix = Rule + "Table";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }
    public static class MenuItemRouting
    {
        public const string Prefix = Rule + "MenuItem";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }
    public static class EmployeeRouting
    {
        public const string Prefix = Rule + "Employee";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }

    public static class CustomerRouting
    {
        public const string Prefix = Rule + "Customer";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }
    public static class OrderRouting
    {
        public const string Prefix = Rule + "Order";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }
    public static class OrderItemRouting
    {
        public const string Prefix = Rule + "OrderItem";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }

    public static class ReservationRouting
    {
        public const string Prefix = Rule + "Reservation";
        public const string List = Prefix + "/List";
        public const string GetByID = Prefix + SignleRoute;
        public const string Create = Prefix + "/Create";
        public const string Edit = Prefix + "/Edit";
        public const string Delete = Prefix + "/{id}";
        public const string Paginated = Prefix + "/Paginated";

    }
}
