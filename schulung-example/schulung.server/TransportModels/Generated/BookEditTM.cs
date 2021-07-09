using ON.Web.Api.Models;
using ON.Web.Api.Models.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1506 // Avoid excessive class coupling
namespace Schulung.Server
{
  [SwaggerForForm]
  public partial class BookEditTM
  {
    public BookEditTM() { }
    public BookEditTM(System.Int32 id, System.String title, System.String description, System.Int32 authorId, System.DateTime changedAt, System.String changedBy, System.DateTime createdAt, System.String createdBy, System.String isbn, AuthorEditTM author)
    {
      this.Id = id;
      this.Title = title;
      this.Description = description;
      this.AuthorId = authorId;
      this.ChangedAt = changedAt;
      this.ChangedBy = changedBy;
      this.CreatedAt = createdAt;
      this.CreatedBy = createdBy;
      this.Isbn = isbn;
      this.Author = author;
    }

    public BookEditTM(BookEditTM old)
    {
      old = old ?? throw new ArgumentNullException(nameof(old));
      this.Id = old.Id;
      this.Title = old.Title;
      this.Description = old.Description;
      this.AuthorId = old.AuthorId;
      this.ChangedAt = old.ChangedAt;
      this.ChangedBy = old.ChangedBy;
      this.CreatedAt = old.CreatedAt;
      this.CreatedBy = old.CreatedBy;
      this.Isbn = old.Isbn;
      this.Author = old.Author;
    }

    [Required]
    public System.Int32 Id { get; set; }
    [Required]
    public System.String Title { get; set; }
    [AllowHtml]
    public System.String Description { get; set; }
    [IsIntForeignKeyAttribute]
    [Required]
    public System.Int32 AuthorId { get; set; }
    [Required]
    [SwaggerIgnoreForForm]
    public System.DateTime ChangedAt { get; set; }
    [SwaggerIgnoreForForm]
    public System.String ChangedBy { get; set; }
    [Required]
    [SwaggerIgnoreForForm]
    public System.DateTime CreatedAt { get; set; }
    [SwaggerIgnoreForForm]
    public System.String CreatedBy { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 0)]
    public System.String Isbn { get; set; }
    public AuthorEditTM Author { get; set; }
    public bool MarkAsDeleted { get; set; }

  }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1506 // Avoid excessive class coupling
