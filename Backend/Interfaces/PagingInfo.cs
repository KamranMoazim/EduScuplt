

using Backend.Utils;

namespace Backend.Interfaces
{
    public class PagingInfo
    {
        private const int DefaultPageNumber = AppConstants.DefaultPageNumber;
        private const int DefaultPageSize = AppConstants.DefaultPageSize;
        // private const string DefaultOrderBy = AppConstants.DefaultOrderBy; // Provide your default value
        private const string DefaultOrderBy = "ID"; // Provide your default value
        private const OrderDirection DefaultOrderDirection = AppConstants.DefaultOrderDirection; // Provide your default value

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public OrderDirection? OrderDirection { get; set; }


        public void ApplyDefaults()
        {
            PageNumber ??= DefaultPageNumber;
            PageSize ??= DefaultPageSize;
            OrderBy ??= DefaultOrderBy;
            OrderDirection ??= DefaultOrderDirection;
        }
    }
}