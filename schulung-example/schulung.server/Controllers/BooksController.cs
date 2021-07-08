using ON.Data.Common;
using ON.Data.SqlClient;
using ON.Web.Api;
using ON.Web.Api.Attributes;
using ON.Web.Api.Controllers;
using ON.Web.Api.Models;
using schulung.core;
using Schulung.Core;
using Schulung.Core.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Schulung.Server.Controllers
{
  [RoutePrefix("api/books")]
  [SwaggerAdminService(CreateSingleAdminService = true,
    DefaultModelMethodName = nameof(Default),
    DeleteMethodName = nameof(Delete),
    GetForEditMethodName = nameof(Edit),
    SaveMethodName = nameof(Save),
    ListServiceName = "Books")]
  public class BooksController : AEntityApiController<SchulungDbContext>
  {

    [HttpGet]
    [Route("detail")]
    public async Task<BookTM> Detail(int id)
    {
      var model = await DbContext.BookTMFromIdAsync(id, OnUser).ConfigureAwait(false);
      if (model == null) throw ActionContext.NotFound();
      return model;
    }

    [HttpGet]
    [Route("edit")]
    public async Task<BookEditTM> Edit(int id)
    {
      var model = await DbContext.BookEditTMFromIdAsync(id, OnUser).ConfigureAwait(false);
      if (model == null) throw ActionContext.NotFound();
      return model;
    }

    [HttpGet]
    [Route("default")]
    public async Task<BookEditTM> Default()
    {
      return new BookEditTM
      {
        Title = "This is a new title",
        AuthorId = -1,
        Author = new AuthorEditTM()
      };
    }

    [HttpPost]
    [Route("save")]
    public async Task<int> Save(BookEditTM model)
    {
      model = model ?? throw new ArgumentNullException(nameof(model));
      using (var connection = new SqlConnection(DbContext.ConnectionString))
      {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
          try
          {
            var dbModel = model.LoadAndPatch(DbContext.ConnectionString, OnUser);
            if (!dbModel.Process(this, true, true, null))
            {
              throw ActionContext.BadRequest();
            }
            dbModel.Save(null, connection, transaction);
            transaction.Commit();
            return (int)dbModel.Id.SQLObject;
          }
          catch
          {
            try { transaction.Rollback(); } catch { }
            throw;
          }
        }
      }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task Delete(int id)
    {
      var model = Book.Get(new IntPrimaryKey(id), Globals.ConnectionString, OnUser);
      if (model.Id.IsNew)
      {
        throw ActionContext.NotFound();
      }
      model.Delete();
    }

    [HttpPost]
    [Route("list")]
    [SwaggerListService(LoadOnInit = false, InitialPageSize = 10)]
    public async Task<PagedResult<BookListTM>> List(BookListRequestTM request)
    {
      request = request ?? throw new ArgumentNullException(nameof(request));
      var query = DbContext.Books.AsQueryable();
      query = query.Filter(request);
      var pagedResult = new PagedResult<BookListTM>(
        request,
        await query.CountAsync().ConfigureAwait(false),
        await query.ApplyOrderAndPaging(request, 10).ToBookListTM(DbContext, OnUser).ConfigureAwait(false));
      return pagedResult;
    }
  }
}
