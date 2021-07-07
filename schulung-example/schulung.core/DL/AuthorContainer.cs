using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using ON;
using ON.Data;
using ON.Data.EF;
using ON.Data.Common;
using ON.Data.SqlClient;
using ON.Diagnostics.Exceptions;
using ON.Diagnostics.Logging;
using ON.Globalization;
using ON.OnPublixFacade;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Schulung.Core
{
  /// <summary>
  /// Container für die Daten einer Tabellen Zeile
  /// </summary>
  [Serializable]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1066:StringOpInStringBuilderAppend")]
  [Table("Authors", Schema = "dbo")]
  public partial class AuthorContainer : IEfChangeable, IEfCreatable, System.Runtime.Serialization.ISerializable
  {
    /// <summary>
    /// Leerer Constructor
    /// </summary>
    public AuthorContainer()
    {
    }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("Firstname")]
    [Required]
    public string Firstname { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("Lastname")]
    [Required]
    public string Lastname { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("ChangedAt")]
    [Required]
    public DateTime ChangedAt { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("ChangedBy")]
    public string ChangedBy { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("CreatedAt")]
    [Required]
    public DateTime CreatedAt { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("CreatedBy")]
    public string CreatedBy { get; set; }

    private List<Schulung.Core.BookContainer> bookColl = new List<Schulung.Core.BookContainer>(5);
    /// <summary>
    /// Liste der bookColl
    /// </summary>
    [ForeignKey("AuthorId")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public List<Schulung.Core.BookContainer> BookColl
    {
      get
      {
        return bookColl;
      }
      set
      {
        bookColl = value;
      }
    }

    /// <summary>
    /// der Primärschlüssel
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Serialisiert das Objekt
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "info")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
      if (info == null)
      {
        throw new ArgumentNullException(nameof(info));
      }
      info.AddValue(nameof(Firstname), this.Firstname);
      info.AddValue(nameof(Lastname), this.Lastname);
      info.AddValue(nameof(ChangedAt), this.ChangedAt);
      info.AddValue(nameof(ChangedBy), this.ChangedBy);
      info.AddValue(nameof(CreatedAt), this.CreatedAt);
      info.AddValue(nameof(CreatedBy), this.CreatedBy);
      info.AddValue(nameof(bookColl), this.bookColl);
    }

    /// <summary>
    /// Deserialisiert das Objekt
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable", Justification = ".NET")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
#pragma warning disable CA1801 // Review unused parameters
    protected AuthorContainer(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
#pragma warning restore CA1801 // Review unused parameters
    {
      if (info == null)
      {
        throw new ArgumentNullException(nameof(info));
      }
      Firstname = info.GetString(nameof(Firstname));
      Lastname = info.GetString(nameof(Lastname));
      this.ChangedAt = info.GetDateTime(nameof(ChangedAt));
      ChangedBy = info.GetString(nameof(ChangedBy));
      this.CreatedAt = info.GetDateTime(nameof(CreatedAt));
      CreatedBy = info.GetString(nameof(CreatedBy));
      bookColl = (List<BookContainer>) info.GetValue(nameof(bookColl), typeof(List<Schulung.Core.BookContainer>));
    }
  }//class
}//namespace
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
