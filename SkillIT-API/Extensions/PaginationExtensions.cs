using Microsoft.EntityFrameworkCore;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillIT_API.Extensions
{
    /// <summary>
    /// Extension methods for pagination
    /// </summary>
    public static class PaginationExtensions
    {
        /// <summary>
        /// Creates a paginated result from an IQueryable
        /// </summary>
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 20 : pageSize;

            var count = await source.CountAsync();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<T>(items, count, pageNumber, pageSize);
        }

        /// <summary>
        /// Creates a paginated result from an IEnumerable
        /// </summary>
        public static PaginatedResult<T> ToPaginatedList<T>(
            this IEnumerable<T> source,
            int pageNumber,
            int pageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 20 : pageSize;

            var enumerable = source as T[] ?? source.ToArray();
            var count = enumerable.Length;
            var items = enumerable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return new PaginatedResult<T>(items, count, pageNumber, pageSize);
        }
    }
}
