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
  public partial class AuthorEditTM
  {
    public AuthorEditTM() { }
    public AuthorEditTM(System.Int32 id, System.String firstname, System.String lastname)
    {
      this.Id = id;
      this.Firstname = firstname;
      this.Lastname = lastname;
    }

    public AuthorEditTM(AuthorEditTM old)
    {
      old = old ?? throw new ArgumentNullException(nameof(old));
      this.Id = old.Id;
      this.Firstname = old.Firstname;
      this.Lastname = old.Lastname;
    }

    [Required]
    public System.Int32 Id { get; set; }
    [Required]
    public System.String Firstname { get; set; }
    [Required]
    public System.String Lastname { get; set; }
    public bool MarkAsDeleted { get; set; }

  }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1506 // Avoid excessive class coupling
