using System.Collections.Generic;

namespace SkillIT_Models.Models
{
    /// <summary>
    /// Represents a paginated result set
    /// </summary>
    /// <typeparam name="T">The type of items in the result</typeparam>
    public class PaginatedResult<T>
    {
        /// <summary>
        /// Gets or sets the current page number (1-based)
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of items across all pages
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets the total number of pages
        /// </summary>
        public int TotalPages => (int)System.Math.Ceiling(TotalCount / (double)PageSize);

        /// <summary>
        /// Gets whether there is a previous page
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Gets whether there is a next page
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;

        /// <summary>
        /// Gets or sets the items on the current page
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Creates a new paginated result
        /// </summary>
        public PaginatedResult()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Creates a new paginated result with the specified parameters
        /// </summary>
        public PaginatedResult(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            Items = items;
        }
    }

    /// <summary>
    /// Pagination request parameters
    /// </summary>
    public class PaginationParams
    {
        private int _pageSize = SkillIT_Models.Constants.AppConstants.Pagination.DefaultPageSize;

        /// <summary>
        /// Gets or sets the page number (1-based)
        /// </summary>
        public int PageNumber { get; set; } = SkillIT_Models.Constants.AppConstants.Pagination.DefaultPageNumber;

        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > SkillIT_Models.Constants.AppConstants.Pagination.MaxPageSize 
                ? SkillIT_Models.Constants.AppConstants.Pagination.MaxPageSize 
                : value;
        }
    }
}
