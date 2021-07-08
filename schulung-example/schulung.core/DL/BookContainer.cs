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
  [Table("Books", Schema = "dbo")]
  public partial class BookContainer : IEfChangeable, IEfCreatable, System.Runtime.Serialization.ISerializable
  {
    /// <summary>
    /// Leerer Constructor
    /// </summary>
    public BookContainer()
    {
    }
    private int authorId;

    /// <summary>
    /// 
    /// Liefert/setzt AuthorId
    /// Ändern der ID führt zu null in der Roll
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "roll und id sind gleichwertig")]
    [IsForeignKey("IntPrimaryKey")]
    public int AuthorId
    {
      get
      {
        return this.authorId;
      }
      set
      {
        if (this.authorId != value && this.authorId != default) //wenn es von -1 weg geht ... ist es nur speichern ...
        {
          authorRoll = null;
        }
        this.authorId = value;
      }
    }
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

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("Description")]
    public string Description { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("Isbn")]
    [Required]
    [StringLength(20)]
    public string Isbn { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("AuthorName")]
    [NotMapped]
    public string AuthorName { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    [Column("Title")]
    [Required]
    public string Title { get; set; }


    private AuthorContainer authorRoll;
    [ForeignKey("AuthorId")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "roll und key gleich behandeln")]
    public AuthorContainer AuthorRoll
    {
      get
      {
        return authorRoll;
      }
      set
      {
        authorRoll = value;
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
      info.AddValue(nameof(AuthorId), this.AuthorId);
      info.AddValue(nameof(ChangedAt), this.ChangedAt);
      info.AddValue(nameof(ChangedBy), this.ChangedBy);
      info.AddValue(nameof(CreatedAt), this.CreatedAt);
      info.AddValue(nameof(CreatedBy), this.CreatedBy);
      info.AddValue(nameof(Description), this.Description);
      info.AddValue(nameof(Isbn), this.Isbn);
      info.AddValue(nameof(AuthorName), this.AuthorName);
      info.AddValue(nameof(Title), this.Title);
      info.AddValue(nameof(authorRoll), this.authorRoll);
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
    protected BookContainer(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
#pragma warning restore CA1801 // Review unused parameters
    {
      if (info == null)
      {
        throw new ArgumentNullException(nameof(info));
      }
      AuthorId = (int)info.GetValue(nameof(AuthorId), typeof(int));
      this.ChangedAt = info.GetDateTime(nameof(ChangedAt));
      ChangedBy = info.GetString(nameof(ChangedBy));
      this.CreatedAt = info.GetDateTime(nameof(CreatedAt));
      CreatedBy = info.GetString(nameof(CreatedBy));
      Description = info.GetString(nameof(Description));
      Isbn = info.GetString(nameof(Isbn));
      AuthorName = info.GetString(nameof(AuthorName));
      Title = info.GetString(nameof(Title));
      this.authorRoll = (AuthorContainer)info.GetValue(nameof(authorRoll), typeof(Schulung.Core.AuthorContainer));
    }
  }//class
}//namespace
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
