using ON.Web.Api.Models;
using ON.Web.Api.Models.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1506 // Avoid excessive class coupling
namespace Schulung.Server
{
  public partial class BookListTM
  {
    public BookListTM() { }
    public BookListTM(System.Int32 id, System.String title, System.String isbn, System.DateTime createdAt, System.String authorName)
    {
      this.Id = id;
      this.Title = title;
      this.Isbn = isbn;
      this.CreatedAt = createdAt;
      this.AuthorName = authorName;
    }

    public BookListTM(BookListTM old)
    {
      old = old ?? throw new ArgumentNullException(nameof(old));
      this.Id = old.Id;
      this.Title = old.Title;
      this.Isbn = old.Isbn;
      this.CreatedAt = old.CreatedAt;
      this.AuthorName = old.AuthorName;
    }

    [Required]
    public System.Int32 Id { get; set; }
    [Required]
    public System.String Title { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 0)]
    public System.String Isbn { get; set; }
    [Required]
    public System.DateTime CreatedAt { get; set; }
    public System.String AuthorName { get; set; }

  }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1506 // Avoid excessive class coupling
