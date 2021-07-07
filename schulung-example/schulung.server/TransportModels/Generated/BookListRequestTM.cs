using ON.Web.Api.Models;
using ON.Web.Api.Models.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1506 // Avoid excessive class coupling
namespace Schulung.Server
{
#pragma warning disable ON1091 // UseNameOf
  [SwaggerGenerateRequestClass(DefaultSortColumn = "CreatedAt", DefaultSortOrder = ON.Web.Api.Models.SortOrder.Ascending, DefaultPageSize = -1)]
#pragma warning restore ON1091 // UseNameOf
  [SwaggerForForm]
  public partial class BookListRequestTM : APagedRequest
  {
    public BookListRequestTM() { }
    public System.Int32? Id { get; set; }
    public System.String Title { get; set; }
    public System.String Isbn { get; set; }
    public System.String AuthorName { get; set; }
    public System.DateTime[] DateRange { get; set; }

  }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1506 // Avoid excessive class coupling
