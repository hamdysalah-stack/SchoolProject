namespace SchoolProject.Data.AppRoutes
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";
        public const string SignleRoute = "/{id}";


        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string Paginated = Prefix + "/Paginated";

            public const string Getyid = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string Getyid = Prefix + SignleRoute;


        }
    }
}
