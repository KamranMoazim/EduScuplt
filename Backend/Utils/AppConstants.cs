

namespace Backend.Utils
{
    public enum OrderDirection
    {
        Ascending,
        Descending
    }


    public enum OrderBy
    {
        ID,
        CreatedOn,
        ModifiedOn
    }

    public static class AppConstants
    {
        
        public static string INSTRUCTOR = "Instructor";
        public static string STUDENT = "Student";
        public static string ADMIN = "Admin";


        public const int DefaultPageSize = 10;
        public const int DefaultPageNumber = 1;
        public const OrderDirection DefaultOrderDirection = OrderDirection.Ascending;
        public const OrderBy DefaultOrderBy = OrderBy.ID;
    }
}