using ON.Tools.TMGenerator;
using ON.Web.Api.Models;
using ON.Web.Api.Models.Attributes;
using Schulung.Core;
using Schulung.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulung.Tooling.ClassDefinitions
{
  public static class BookDefinitions
  {
    public static ClassDefinition BookListTM()
    {
      return new ClassDefinition()
        .ForEntityType<SchulungDbContext, BookContainer>()
        .WithPropertiesFromEntity<BookContainer>(b => new { b.Id, b.Title, b.Isbn, b.CreatedAt, b.AuthorName })
        .WithConstructorQueryable();
    }

    public static ClassDefinition BookListRequestTM()
    {
      return new ClassDefinition()
        .ForPagedRequest<SchulungDbContext, BookContainer>(b => b.CreatedAt, SortOrder.Ascending)
        .WithSortColumns<BookContainer>(b => new { b.Id, b.Title, b.CreatedAt })
        .WithSortColumns(new SortExpression { Key = nameof(BookContainer.AuthorName), Expression = "AuthorRoll.Firstname + item.AuthorRoll.Lastname" })
        .WithPropertiesForRequest<BookContainer>(b => b
          .Add<int?>(p => p.Id, p => p.Id, FilterOperator.Equals)
          .Add<string>(p => p.Title, p => p.Title, FilterOperator.Contains)
          .Add<string>(p => p.Isbn, p => p.Isbn, FilterOperator.Contains)
          .AddCustom<string>(nameof(BookContainer.AuthorName), "o => o.AuthorRoll.Firstname.Contains(request.AuthorName) || o.AuthorRoll.Lastname.Contains(request.AuthorName)")
          .AddCustom<DateTime[]>("DateRange", "DateRange(request.DateRange)", null, true)
        )
        .ForForm();
    }

    public static ClassDefinition BookTM()
    {
      return new ClassDefinition()
        .ForEntityType<SchulungDbContext, BookContainer>()
        .WithPropertiesFromEntity<BookContainer>(b => new { b.Id, b.Title, b.Description, b.Isbn, b.AuthorName, b.ChangedAt, b.ChangedBy, b.CreatedAt, b.CreatedBy })
        .WithConstructorId();
    }

    public static ClassDefinition BookEditTM()
    {
      return new ClassDefinition()
        .ForEntityType<SchulungDbContext, BookContainer>()
        .WithPropertiesFromEntity<BookContainer>(b => new { b.Id, b.Title, b.Description, b.AuthorId, b.ChangedAt, b.ChangedBy, b.CreatedAt, b.CreatedBy, b.Isbn })
        .WithPropertyForTM("Author", AuthorEditTM, nameof(BookContainer.AuthorId), nameof(BookContainer.AuthorRoll), false)
        .CustomizeProperty(nameof(BookContainer.CreatedAt), a => a.IgnoreInForm())
        .CustomizeProperty(nameof(BookContainer.CreatedBy), a => a.IgnoreInForm())
        .CustomizeProperty(nameof(BookContainer.ChangedAt), a => a.IgnoreInForm())
        .CustomizeProperty(nameof(BookContainer.ChangedBy), a => a.IgnoreInForm())
        .CustomizeProperty(nameof(BookContainer.Description), a => a.WithAttribute(new AllowHtmlAttribute()))
        .WithConstructorId()
        .Patchable()
        .ForForm();
    }

    public static ClassDefinition AuthorEditTM()
    {
      return new ClassDefinition()
        .ForEntityType<SchulungDbContext, AuthorContainer>()
        .WithPropertiesFromEntity<AuthorContainer>(b => new { b.Id, b.Firstname, b.Lastname })
        .WithConstructorId()
        .Patchable()
        .ForForm();
    }
  }
}
