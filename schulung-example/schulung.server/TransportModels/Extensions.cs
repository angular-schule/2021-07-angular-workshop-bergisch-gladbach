using Schulung.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulung.Server.TransportModels
{
  public static class Extensions
  {
    public static IQueryable<BookContainer> DateRange(this IQueryable<BookContainer> query, DateTime[] dateRange)
    {
      if (dateRange.Length is 2)
      {
        var start = dateRange[0];
        var end = dateRange[1];
        return query = query.Where(b => b.CreatedAt >= start && b.CreatedAt <= end);
      }
      return query;
    }
  }
}
