using ON.Web.Api;
using ON.Web.Api.Attributes;
using ON.Web.Api.Mapping;
using ON.Web.Api.Models;
using ON.Web.Api.Startup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ON.Defense;
using ON.DependencyInjection;
using Schulung.Core;
using Schulung.Core.Database;
using Schulung.Server.TransportModels;
using ON.Data.EF;
using ON.Data.Common;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1506 // Avoid excessive class coupling
namespace Schulung.Server
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling", Justification = "Da das hier(generierte) ExtensionMethods sind, können wir die Komplexität in Kauf nehmen.")]
  public static class QueryableExtensionMethods
  {
#pragma warning disable CA1801 // Review unused parameters
    public static async Task<BookListTM[]> ToBookListTM(this IQueryable<BookContainer> query, SchulungDbContext context, IUser user)
#pragma warning restore CA1801 // Review unused parameters
    {
      context = context ?? throw new ArgumentNullException(nameof(context));
      var dbEntries = await query.Select(item => item.Id).ToArrayAsync().ConfigureAwait(false);
      if (dbEntries.Length == 0)
      {
        return Array.Empty<BookListTM>();
      }
      var param = new ON.Data.SqlClient.OnSqlParameterCollection(1) { { "ids", string.Join(",", dbEntries) } };
      var dks = Schulung.Core.Book.LoadList("WHERE id in (select * from " + ON.Configuration.ConfigurationManager.PraefixForGlobalFunctions + "fnSplitterInt(@ids))", null, null, param, null, null, context.ConnectionString, user, -1);
      var hash = new Dictionary<Int32, Schulung.Core.Book>(dks.Count);
      foreach (var e in dks)
      {
      hash[(Int32)e.Id.SQLObject] = e;
      }
      var ret = new BookListTM[dks.Count];
      var count = 0;
      foreach (var i in dbEntries)
      {
      ret[count] = hash[i].ToBookListTM();
      count++;
      }
      return ret;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    public static BookListTM ToBookListTM(this Schulung.Core.Book @object)
    {
      #pragma warning disable ON1057 // NullTestDL
      if (@object == null) { return null; }
      #pragma warning restore ON1057 // NullTestDL
      #pragma warning disable IDE0075 // Simplify conditional expression
      var tm = new BookListTM
      {
        Id = @object.CheckRight("Id").HasFlag(Rights.Read) ? (System.Int32)@object.Id.SQLObject : default,
        Title = @object.CheckRight("Title").HasFlag(Rights.Read) ? @object.Title : default,
        Isbn = @object.CheckRight("Isbn").HasFlag(Rights.Read) ? @object.Isbn : default,
        CreatedAt = @object.CheckRight("CreatedAt").HasFlag(Rights.Read) ? @object.CreatedAt : default,
        AuthorName = @object.CheckRight("AuthorName").HasFlag(Rights.Read) ? @object.AuthorName : default
      }
      ;
      return tm;
      #pragma warning restore IDE0075 // Simplify conditional expression
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006: DoNotNestGenericTypesInMemberSignatures", Justification = "Lässt sich hier nicht wirklich vermeiden.")]
#pragma warning disable CA1801 // Review unused parameters
    public static async Task<BookTM> BookTMFromIdAsync(this SchulungDbContext context, System.Int32 id, IUser user, Func<IQueryable<BookContainer>, IQueryable<BookContainer>> additionalFilter = null)
#pragma warning restore CA1801 // Review unused parameters
    {
      context = context ?? throw new ArgumentNullException(nameof(context));
      IQueryable<BookContainer> objectsToSearch = context.Books;
      if (additionalFilter != null)
      {
        objectsToSearch = additionalFilter(context.Books);
      }
      var dbEntryId = await objectsToSearch.Select(item => item.Id).SingleOrDefaultAsync(dbid => dbid == id).ConfigureAwait(false);
#pragma warning disable ON1064
      var dbEntry = Schulung.Core.Book.Get(Schulung.Core.Book.Dummy.Id.CreateId(dbEntryId), null, null, context.ConnectionString, user);
#pragma warning restore ON1064
      if (dbEntry.Id.IsNew)
      {
        return null;
      }
      else
      {
        return dbEntry.ToBookTM();
      }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    public static BookTM ToBookTM(this Schulung.Core.Book @object)
    {
      #pragma warning disable ON1057 // NullTestDL
      if (@object == null) { return null; }
      #pragma warning restore ON1057 // NullTestDL
      #pragma warning disable IDE0075 // Simplify conditional expression
      var tm = new BookTM
      {
        Id = @object.CheckRight("Id").HasFlag(Rights.Read) ? (System.Int32)@object.Id.SQLObject : default,
        Title = @object.CheckRight("Title").HasFlag(Rights.Read) ? @object.Title : default,
        Description = @object.CheckRight("Description").HasFlag(Rights.Read) ? @object.Description : default,
        Isbn = @object.CheckRight("Isbn").HasFlag(Rights.Read) ? @object.Isbn : default,
        AuthorName = @object.CheckRight("AuthorName").HasFlag(Rights.Read) ? @object.AuthorName : default,
        ChangedAt = @object.CheckRight("ChangedAt").HasFlag(Rights.Read) ? @object.ChangedAt : default,
        ChangedBy = @object.CheckRight("ChangedBy").HasFlag(Rights.Read) ? @object.ChangedBy : default,
        CreatedAt = @object.CheckRight("CreatedAt").HasFlag(Rights.Read) ? @object.CreatedAt : default,
        CreatedBy = @object.CheckRight("CreatedBy").HasFlag(Rights.Read) ? @object.CreatedBy : default
      }
      ;
      return tm;
      #pragma warning restore IDE0075 // Simplify conditional expression
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006: DoNotNestGenericTypesInMemberSignatures", Justification = "Lässt sich hier nicht wirklich vermeiden.")]
#pragma warning disable CA1801 // Review unused parameters
    public static async Task<BookEditTM> BookEditTMFromIdAsync(this SchulungDbContext context, System.Int32 id, IUser user, Func<IQueryable<BookContainer>, IQueryable<BookContainer>> additionalFilter = null)
#pragma warning restore CA1801 // Review unused parameters
    {
      context = context ?? throw new ArgumentNullException(nameof(context));
      IQueryable<BookContainer> objectsToSearch = context.Books;
      if (additionalFilter != null)
      {
        objectsToSearch = additionalFilter(context.Books);
      }
      var dbEntryId = await objectsToSearch.Select(item => item.Id).SingleOrDefaultAsync(dbid => dbid == id).ConfigureAwait(false);
#pragma warning disable ON1064
      var dbEntry = Schulung.Core.Book.Get(Schulung.Core.Book.Dummy.Id.CreateId(dbEntryId), null, null, context.ConnectionString, user, new ActivationDelegateCollection(1){Schulung.Core.Book.authorRollDelegate});
#pragma warning restore ON1064
      if (dbEntry.Id.IsNew)
      {
        return null;
      }
      else
      {
        return dbEntry.ToBookEditTM();
      }
    }

#pragma warning disable ON1081 // NoMoreThan3Overloads
    public static Schulung.Core.Book LoadAndPatch(this BookEditTM model, string connectionString, IUser user)
    {
      if (model == null)
      {
        throw new ArgumentNullException(nameof(model));
      }
      Schulung.Core.Book dbEntry;
#pragma warning disable ON1064
      dbEntry = Schulung.Core.Book.Get(Schulung.Core.Book.Dummy.Id.CreateId(model.Id), connectionString, user);
#pragma warning restore ON1064
      model.Patch(dbEntry);
      return dbEntry;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity", Justification = "Je nach Anzahl an Sortcolumns kann die Komplexität sehr hoch werden.Da Generiert, können wir das hier guten Gewissens ignorieren.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505: AvoidExcessiveComplexity", Justification = "Je nach Anzahl an Sortcolumns kann die Komplexität sehr hoch werden.Da Generiert, können wir das hier guten Gewissens ignorieren.")]
    public static void Patch(this BookEditTM model, Schulung.Core.Book dbEntry )
    {
      if (model == null)
      {
        throw new ArgumentNullException(nameof(model));
      }
      if (dbEntry == null)
      {
        throw new ArgumentNullException(nameof(dbEntry));
      }
      if (model.MarkAsDeleted)
      {
        dbEntry.DeleteMark = true;
      }
      dbEntry.Title = model.Title;
      dbEntry.Description = model.Description;
      dbEntry.AuthorId = new IntPrimaryKey(model.AuthorId);
      dbEntry.Isbn = model.Isbn;

      if (model.Author != null)
      {
        dbEntry.AuthorRoll = model.Author.LoadAndPatch(dbEntry.ConnectionString, dbEntry.Owner);
      }
    }

#pragma warning restore ON1081 // NoMoreThan3Overloads
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    public static BookEditTM ToBookEditTM(this Schulung.Core.Book @object)
    {
      #pragma warning disable ON1057 // NullTestDL
      if (@object == null) { return null; }
      #pragma warning restore ON1057 // NullTestDL
      #pragma warning disable IDE0075 // Simplify conditional expression
      var tm = new BookEditTM
      {
        Id = @object.CheckRight("Id").HasFlag(Rights.Read) ? (System.Int32)@object.Id.SQLObject : default,
        Title = @object.CheckRight("Title").HasFlag(Rights.Read) ? @object.Title : default,
        Description = @object.CheckRight("Description").HasFlag(Rights.Read) ? @object.Description : default,
        AuthorId = @object.CheckRight("AuthorId").HasFlag(Rights.Read) ? (System.Int32)@object.AuthorId.SQLObject : default,
        ChangedAt = @object.CheckRight("ChangedAt").HasFlag(Rights.Read) ? @object.ChangedAt : default,
        ChangedBy = @object.CheckRight("ChangedBy").HasFlag(Rights.Read) ? @object.ChangedBy : default,
        CreatedAt = @object.CheckRight("CreatedAt").HasFlag(Rights.Read) ? @object.CreatedAt : default,
        CreatedBy = @object.CheckRight("CreatedBy").HasFlag(Rights.Read) ? @object.CreatedBy : default,
        Isbn = @object.CheckRight("Isbn").HasFlag(Rights.Read) ? @object.Isbn : default,
        Author = @object.CheckRight("Author").HasFlag(Rights.Read) ? @object.AuthorRoll.ToAuthorEditTM() : default
      }
      ;
      return tm;
      #pragma warning restore IDE0075 // Simplify conditional expression
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006: DoNotNestGenericTypesInMemberSignatures", Justification = "Lässt sich hier nicht wirklich vermeiden.")]
#pragma warning disable CA1801 // Review unused parameters
    public static async Task<AuthorEditTM> AuthorEditTMFromIdAsync(this SchulungDbContext context, System.Int32 id, IUser user, Func<IQueryable<AuthorContainer>, IQueryable<AuthorContainer>> additionalFilter = null)
#pragma warning restore CA1801 // Review unused parameters
    {
      context = context ?? throw new ArgumentNullException(nameof(context));
      IQueryable<AuthorContainer> objectsToSearch = context.Authors;
      if (additionalFilter != null)
      {
        objectsToSearch = additionalFilter(context.Authors);
      }
      var dbEntryId = await objectsToSearch.Select(item => item.Id).SingleOrDefaultAsync(dbid => dbid == id).ConfigureAwait(false);
#pragma warning disable ON1064
      var dbEntry = Schulung.Core.Author.Get(Schulung.Core.Author.Dummy.Id.CreateId(dbEntryId), null, null, context.ConnectionString, user);
#pragma warning restore ON1064
      if (dbEntry.Id.IsNew)
      {
        return null;
      }
      else
      {
        return dbEntry.ToAuthorEditTM();
      }
    }

#pragma warning disable ON1081 // NoMoreThan3Overloads
    public static Schulung.Core.Author LoadAndPatch(this AuthorEditTM model, string connectionString, IUser user)
    {
      if (model == null)
      {
        throw new ArgumentNullException(nameof(model));
      }
      Schulung.Core.Author dbEntry;
#pragma warning disable ON1064
      dbEntry = Schulung.Core.Author.Get(Schulung.Core.Author.Dummy.Id.CreateId(model.Id), connectionString, user);
#pragma warning restore ON1064
      model.Patch(dbEntry);
      return dbEntry;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity", Justification = "Je nach Anzahl an Sortcolumns kann die Komplexität sehr hoch werden.Da Generiert, können wir das hier guten Gewissens ignorieren.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505: AvoidExcessiveComplexity", Justification = "Je nach Anzahl an Sortcolumns kann die Komplexität sehr hoch werden.Da Generiert, können wir das hier guten Gewissens ignorieren.")]
    public static void Patch(this AuthorEditTM model, Schulung.Core.Author dbEntry )
    {
      if (model == null)
      {
        throw new ArgumentNullException(nameof(model));
      }
      if (dbEntry == null)
      {
        throw new ArgumentNullException(nameof(dbEntry));
      }
      if (model.MarkAsDeleted)
      {
        dbEntry.DeleteMark = true;
      }
      dbEntry.Firstname = model.Firstname;
      dbEntry.Lastname = model.Lastname;
    }

#pragma warning restore ON1081 // NoMoreThan3Overloads
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    public static AuthorEditTM ToAuthorEditTM(this Schulung.Core.Author @object)
    {
      #pragma warning disable ON1057 // NullTestDL
      if (@object == null) { return null; }
      #pragma warning restore ON1057 // NullTestDL
      #pragma warning disable IDE0075 // Simplify conditional expression
      var tm = new AuthorEditTM
      {
        Id = @object.CheckRight("Id").HasFlag(Rights.Read) ? (System.Int32)@object.Id.SQLObject : default,
        Firstname = @object.CheckRight("Firstname").HasFlag(Rights.Read) ? @object.Firstname : default,
        Lastname = @object.CheckRight("Lastname").HasFlag(Rights.Read) ? @object.Lastname : default
      }
      ;
      return tm;
      #pragma warning restore IDE0075 // Simplify conditional expression
    }

  }
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling", Justification = "Da das hier(generierte) ExtensionMethods sind, können wir die Komplexität in Kauf nehmen.")]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1081: NoMoreThan3Overloads", Justification = "Bei Extensionmethods sollte das kein Problem sein.")]
  public static class RequestExtensionMethods
  {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable", Justification = "Der Fehler tritt nicht immer auf, aber wenn, ist der in der Generierung auch nicht behebbar.")]
    public static IQueryable<BookContainer> Filter(this IQueryable<BookContainer> query, BookListRequestTM request)
    {
      if (request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }
      if (request.Id != null)
      {
        query = query.Where(o => o.Id == request.Id);
      }
      if (!string.IsNullOrEmpty(request.Title))
      {
        query = query.Where(o => o.Title.Contains(request.Title));
      }
      if (!string.IsNullOrEmpty(request.Isbn))
      {
        query = query.Where(o => o.Isbn.Contains(request.Isbn));
      }
      if (!string.IsNullOrEmpty(request.AuthorName))
      {
        query = query.Where(o => o.AuthorRoll.Firstname.Contains(request.AuthorName) || o.AuthorRoll.Lastname.Contains(request.AuthorName));
      }
      if (request.DateRange != null && request.DateRange.Any())
      {
        query = query.DateRange(request.DateRange);
      }
      return query;
    }


    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable", Justification = "Der Fehler tritt nicht immer auf, aber wenn, ist der in der Generierung auch nicht behebbar.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity", Justification = "Je nach Anzahl an Sortcolumns kann die Komplexität sehr hoch werden.Da Generiert, können wir das hier guten Gewissens ignorieren.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011: ConsiderPassingBaseTypesAsParameters", Justification = "request und query müssen typisiert sein, damit eine eindeutige Zuordnung möglich ist")]
    public static IQueryable<BookContainer> ApplyOrderAndPaging(this IQueryable<BookContainer> query, BookListRequestTM request, int maxPageSize = 100)
    {
      if (request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }
      if (request.SortOrder == ON.Web.Api.Models.SortOrder.Unspecified)
      {
        request.SortOrder = ON.Web.Api.Models.SortOrder.Ascending;
      }
      switch (request.Sort?.ToLower())
      {
        case "id":
          if (request.SortOrder == ON.Web.Api.Models.SortOrder.Descending)
          {
            query = query.OrderByDescending(item => item.Id);
          }
          else
          {
            query = query.OrderBy(item => item.Id);
          }
          break;
        case "title":
          if (request.SortOrder == ON.Web.Api.Models.SortOrder.Descending)
          {
            query = query.OrderByDescending(item => item.Title);
          }
          else
          {
            query = query.OrderBy(item => item.Title);
          }
          break;
        case "createdat":
          if (request.SortOrder == ON.Web.Api.Models.SortOrder.Descending)
          {
            query = query.OrderByDescending(item => item.CreatedAt);
          }
          else
          {
            query = query.OrderBy(item => item.CreatedAt);
          }
          break;
        case "authorname":
          if (request.SortOrder == ON.Web.Api.Models.SortOrder.Descending)
          {
            query = query.OrderByDescending(item => item.AuthorRoll.Firstname + item.AuthorRoll.Lastname);
          }
          else
          {
            query = query.OrderBy(item => item.AuthorRoll.Firstname + item.AuthorRoll.Lastname);
          }
          break;
        default:
          if (request.SortOrder == ON.Web.Api.Models.SortOrder.Descending)
          {
            query = query.OrderByDescending(item => item.CreatedAt);
          }
          else
          {
            query = query.OrderBy(item => item.CreatedAt);
          }
          break;
      }
      return query.Paging(request, maxPageSize);
    }
  }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1506 // Avoid excessive class coupling
