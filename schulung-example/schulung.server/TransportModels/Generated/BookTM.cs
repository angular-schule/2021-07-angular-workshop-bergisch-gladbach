using ON.Web.Api.Models;
using ON.Web.Api.Models.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1506 // Avoid excessive class coupling
namespace Schulung.Server
{
  public partial class BookTM
  {
    public BookTM() { }
    public BookTM(System.Int32 id, System.String title, System.String description, System.String isbn, System.String authorName, System.DateTime changedAt, System.String changedBy, System.DateTime createdAt, System.String createdBy)
    {
      this.Id = id;
      this.Title = title;
      this.Description = description;
      this.Isbn = isbn;
      this.AuthorName = authorName;
      this.ChangedAt = changedAt;
      this.ChangedBy = changedBy;
      this.CreatedAt = createdAt;
      this.CreatedBy = createdBy;
    }

    public BookTM(BookTM old)
    {
      old = old ?? throw new ArgumentNullException(nameof(old));
      this.Id = old.Id;
      this.Title = old.Title;
      this.Description = old.Description;
      this.Isbn = old.Isbn;
      this.AuthorName = old.AuthorName;
      this.ChangedAt = old.ChangedAt;
      this.ChangedBy = old.ChangedBy;
      this.CreatedAt = old.CreatedAt;
      this.CreatedBy = old.CreatedBy;
    }

    [Required]
    public System.Int32 Id { get; set; }
    [Required]
    public System.String Title { get; set; }
    public System.String Description { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 0)]
    public System.String Isbn { get; set; }
    public System.String AuthorName { get; set; }
    [Required]
    public System.DateTime ChangedAt { get; set; }
    public System.String ChangedBy { get; set; }
    [Required]
    public System.DateTime CreatedAt { get; set; }
    public System.String CreatedBy { get; set; }

  }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1506 // Avoid excessive class coupling
