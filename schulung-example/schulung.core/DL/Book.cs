using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Principal;
using ON;
using ON.Data;
using ON.Data.EF;
using ON.Data.Common;
using ON.Data.SqlClient;
using ON.Diagnostics.Exceptions;
using ON.Globalization;
using ON.OnPublixFacade;
using System.Linq.Expressions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Schulung.Core
{
  /// <summary>
  /// 
  /// Kapselt den Datenzugriff auf eine Zeile der Tabelle Books
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013: privateMemberpublicProperty"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1046:AvoidUselessToString"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1063:OnlyPrimitivKeysInHashes"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1066:StringOpInStringBuilderAppend"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1081:NoMoreThan3Overloads"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1072:JustifyAs"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1053:DontUseDataLayerConstructors", Justification = "ist ur MN"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert, die Justification wird nur außerhalb benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), Serializable]
  public class Book: ON.Data.Common.AbstractDataLayerObject, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable,IChangeable,ICreateable
  {
    /// <summary>
    /// Dummy für Replication und generics
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Book()
    {
      //leere id
      id = new IntPrimaryKey(-1);


      init();
    }


    /// <summary>
    /// Dummy Object zum Zugriff auf nicht statische Felder
    /// </summary>
    public static Book Dummy { get; } = new Book();
    /// <summary>
    /// Sollen Rechte geprüft werden? NEIN = Warning
    /// </summary>
    [MustJustify("keine Rechteprüfung")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1089:EnableCheckRightNotFalse")]
    public override bool EnableCheckRight { get { return false; } }

    
    /// <summary>
    /// Liste von Objekten Laden
    /// </summary>
    /// <param name="sqlWhere">bestimmung der zu ladenden Liste</param>
    /// <param name="join">join bedingung inkl. aller Schlüsselwörter</param>
    /// <param name="order">ohne order by</param>
    /// <param name="onSqlparameters">SQL Parameter</param>
    /// <param name="trans">offene Transaction</param>
    /// <param name="con">offene Connection</param>
    /// <param name="connectionString">connectionString</param>
    /// <param name="lang">gewünschte Sprache</param>
    /// <param name="owner">owner</param>
    /// <param name="top">anzahl der zu ladenden objekte (TOP top)</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    /// <param name="externalDataSource">Externe Datenquelle</param>
    /// <param name="cache"></param>
    /// <returns>geladene objekte</returns>
    public static DataLayerObjectCollection<Book> LoadList(string sqlWhere, string join, string order, OnSqlParameterCollection onSqlparameters, SqlTransaction trans, SqlConnection con, string connectionString, IUser owner, int top = -1, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, IDataLayerCache cache = null)
    {
      return LoadList<Book>(sqlWhere, join, order, onSqlparameters, trans, con, connectionString, owner, top, delegates, lang, externalDataSource ?? Dummy.ExternalDataSource, Dummy, cache);
    }

    /// <summary>
    /// Liste von objekten laden
    /// </summary>
    /// <param name="where"></param>
    /// <param name="onSqlparameters">SQL Parameter</param>
    /// <param name="ConnectionString"></param>
    /// <param name="Owner"></param>
    /// <param name="delegates"></param>
    /// <param name="Language"></param>
    /// <returns></returns>
    public static DataLayerObjectCollection<Book> LoadList(string where, OnSqlParameterCollection onSqlparameters, string ConnectionString, IUser Owner, ActivationDelegateCollection delegates = null, Languages Language = Languages.None)
    {
      return LoadList<Book>(where, null, null, onSqlparameters, null, null, ConnectionString, Owner, -1, delegates, Language, Dummy.ExternalDataSource, Dummy, null);
    }

    /// <summary>
    /// Laden einer sortierten Liste
    /// </summary>
    /// <param name="fieldsWithId">csv der Datenbankfelder</param>
    /// <param name="tablename">Tabellenname (nur der Name nix join und so), pflicht</param>
    /// <param name="filter">SQL Where Klausel EXKL. Schlüsselwort Where. Beginnend mit einem Verknüpfungoperator. IdR AND</param>
    /// <param name="connectionString">ConnectionString</param>
    /// <param name="owner">Besitzer (für logging)</param>
    /// <param name="join">Join bedingung inkl. schlüsselwort join, optional</param>
    /// <param name="pageSize">Anzahl der Einträge pro Seite</param>
    /// <param name="pageIndex">Aktuelle Seite. 1 based!!!</param>
    /// <param name="sort">sql sort klause OHNE schlüsselwort Orderby ... Pflicht!!!</param>
    /// <param name="con">aktuelle SQL Connection</param>
    /// <param name="trans">Aktuelle SQL Transaction</param>
    /// <param name="count">Anzahl der Ergebnisse</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    /// <param name="IdDbName">ID Spalte</param>
    /// <param name="lang">Sprachversion</param>
    /// <param name="externalDataSource">externalDataSource</param>
    /// <param name="sqlparams">SqlParameter</param>
    /// <returns>geladene objekte</returns>
    public static DataLayerObjectCollection<Book> LoadSortedPage(string filter, string sort, string connectionString, IUser owner, string join, int pageSize, int pageIndex, SqlConnection con, SqlTransaction trans, ResultCount count, ActivationDelegateCollection delegates, string fieldsWithId, string tablename, string IdDbName, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, OnSqlParameterCollection sqlparams = null)
    {
      return LoadSortedPage<Book>(filter, sort, connectionString, owner, join, pageSize, pageIndex, con, trans, count, delegates, fieldsWithId, tablename, IdDbName, lang, externalDataSource ?? Dummy.ExternalDataSource, sqlparams);
    }

    /// <summary>
    /// Laden einer sortierten Liste
    /// </summary>
    /// <param name="filter">SQL Where Klausel EXKL. Schlüsselwort Where. Beginnend mit einem Verknüpfungoperator. IdR AND</param>
    /// <param name="connectionString">ConnectionString</param>
    /// <param name="owner">Besitzer (für logging)</param>
    /// <param name="join">Join bedingung inkl. schlüsselwort join, optional</param>
    /// <param name="pageSize">Anzahl der Einträge pro Seite</param>
    /// <param name="pageIndex">Aktuelle Seite. 1 based!!!</param>
    /// <param name="sort">sql sort klause OHNE schlüsselwort Orderby ... Pflicht!!!</param>
    /// <param name="count">Anzahl der Ergebnisse</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    /// <param name="lang">Sprachversion</param>
    /// <param name="externalDataSource">externalDataSource</param>
    /// <param name="sqlparams">SqlParameter</param>
    /// <returns>geladene objekte</returns>
    public static DataLayerObjectCollection<Book> LoadSortedPage(string filter, string sort, string connectionString, IUser owner, string join, int pageSize, int pageIndex, OnSqlParameterCollection sqlparams, ResultCount count = null, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null)
    {
      return LoadSortedPage<Book>(filter, sort, connectionString, owner, join, pageSize, pageIndex, null, null, count, delegates, Dummy.FIELDSWITHID,  Dummy.FullTABLENAME, Dummy.IdDbName, lang, externalDataSource ?? Dummy.ExternalDataSource, sqlparams);
    }


    /// <summary>
    /// Mischt die alte und die neue Liste. Genau heisst dies:
    ///  - Alles was nicht in der neuen Liste ist wird aus der alten gelöscht und als delete geflagged (delete)
    ///  - Alles was in der neuen aber nicht in der alten Liste ist wird zur neuen hinzugefügt (insert) ... foreignKey werden nicht automatisch gesetzt
    ///  - Alles was in der neuen Liste und der alten ist wird in der alten aktualisiert (update)
    ///  Gleichheit wird mittels logicalEqual ermittelt. Update wird mittels update ausgeführt
    /// </summary>
    /// <param name="oldList"></param>
    /// <param name="newList"></param>
    public static void Mix(DataLayerObjectCollection<Book> oldList, IEnumerable newList)
    {
      Mix<Book>(oldList, newList);
    }
    /// <summary>
    /// Erzeugt ein neuen Objekt
    /// </summary>
    /// <param name="id">Id (PK)</param>
    /// <param name="cs">Connection string</param>
    /// <param name="lang">gewünschte Sprache</param>
    /// <param name="owner">Besitzer (für logging)</param>
    /// <param name="trans">aktuelle Transaktion</param>
    /// <param name="con">aktuelle Datenbankverbindung</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    /// <param name="externalDataSource">Externe Datenquelle</param>
    /// <param name="cache"></param>
    public static Book Get(IPrimaryKey id, SqlTransaction trans, SqlConnection con, string cs, IUser owner, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, IDataLayerCache cache = null)
    {
      return Get<Book>(id, trans, con, cs, owner, delegates, lang, externalDataSource ?? Dummy.ExternalDataSource, cache);
    }

    /// <summary>
    /// Erzeugt ein neuen Objekt
    /// </summary>
    /// <param name="id">Id (PK)</param>
    /// <param name="cs">Connection string</param>
    /// <param name="owner">Besitzer (für logging)</param>
    public static Book Get(IPrimaryKey id, string cs, IUser owner)
    {
      return Get<Book>(id, null, null, cs, owner, null, Languages.None, Dummy.ExternalDataSource, null);
    }


    /// <summary>
    /// Erzeugt ein neuen Objekt
    /// Das hier ist der entscheidende ...
    /// Brauchen wir hier ggf ein JOIN?
    /// </summary>
    /// <param name="sqlWhere">where anweisung</param>
    /// <param name="onSqlparameters">SQL Parameter</param>
    /// <param name="cs">Connection string</param>
    /// <param name="lang">gewünschte Sprache</param>
    /// <param name="owner">Besitzer (für logging)</param>
    /// <param name="trans">aktuelle Transaktion</param>
    /// <param name="con">aktuelle Datenbankverbindung</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    /// <param name="externalDataSource">Externe Datenquelle</param>
    /// <param name="cache">hier werden die Daten gecacht</param>
    public static Book Get(string sqlWhere, OnSqlParameterCollection onSqlparameters, SqlTransaction trans, SqlConnection con, string cs, IUser owner, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, IDataLayerCache cache = null)
    {
      return Get<Book>(sqlWhere, onSqlparameters, trans, con, cs, owner, delegates, lang, externalDataSource ?? Dummy.ExternalDataSource, cache);
    }

    /// <summary>
    /// Erzeugt ein neuen Objekt
    /// </summary>
    /// <param name="sqlWhere">SQL WHERE Klausel inkl. Schlüsselwort WHERE</param>
    /// <param name="onSqlparameters">SQL Parameter</param>
    /// <param name="cs">Connection string</param>
    /// <param name="owner">Besitzer (für logging)</param>
    public static Book Get(string sqlWhere, OnSqlParameterCollection onSqlparameters, string cs, IUser owner)
    {
      return Get<Book>(sqlWhere, onSqlparameters, null, null, cs, owner, null, Languages.None, Dummy.ExternalDataSource );
    }


    private static readonly Languages[] supportedLanguages = LanguageUtilities.None;


    /// <summary>
    /// Diese Sprachen werden unterstützt
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
    public static new Languages[] SupportedLanguages
    {
      get
      {
        return supportedLanguages;
      }
    }

    /// <summary>
    /// Typ Prüfung
    /// </summary>
    /// <param name="idToCheck"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1072:JustifyAs")]
    protected override void chechPKType(IPrimaryKey idToCheck)
    {
      if (!(idToCheck is IntPrimaryKey))
      {
        throw new LogicalException("PK hat falschen Typ: " + idToCheck);
      }
    }
    
    /// <summary>
    /// id auf eine neues (isNew) Id-Object setzen
    /// </summary>
    protected override void SetDefaultId()
    {

    Id = new IntPrimaryKey(-1);

    }

    /// <summary>
    /// Wird bei der Erzeugung eines neuen Objektes aufgerufen und setzt default Werte
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1062:NoEmptyOverride", Justification = "generiert")]
    protected override void NewObject()
    {


      base.NewObject();
    }


    /// <summary>
    /// Soll, wenn ein Datensatz nicht gefunden wurde eine Exception geworfen werden?
    /// </summary>
    public override bool ExceptionOnNotFound
    {
      get
      {
        return true;
      }
    }


  
    /// <summary>
    /// individuelle onSave
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="trans"></param>
    /// <param name="myId"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1062:NoEmptyOverride", Justification ="generiert")]
    protected override void OnSave(SqlConnection connection, SqlTransaction trans, IPrimaryKey myId)
    {


      base.OnSave(connection, trans, myId);
    }
    private IntPrimaryKey authorId = new IntPrimaryKey(-1);

    /// <summary>
    /// 
    /// Liefert/setzt AuthorId
    /// Ändern der ID führt zu null in der Roll
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "roll und id sind gleichwertig")]
    public IntPrimaryKey AuthorId
    {
      get
      {
        return this.authorId;
      }
      set
      {
        if ((CheckRight(nameof(AuthorId)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(AuthorId) + " erlaubt");
        }
        if (this.authorId != value && !this.authorId.IsNew) //wenn es von -1 weg geht ... ist es nur speichern ...
        {
          authorRoll = null;
        }
        this.authorId = value;
        IsChanged = true;
      }
    }

    private DateTime changedAt;
    public DateTime ChangedAt
    {
      get
      {
        return this.changedAt;
      }
      set
      {
        if ((CheckRight(nameof(ChangedAt)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(ChangedAt) + " erlaubt");
        }
        this.changedAt = value;
        IsChanged = true;
      }
    }

    private string changedBy;
    public string ChangedBy
    {
      get
      {
        return this.changedBy;
      }
      set
      {
        if ((CheckRight(nameof(ChangedBy)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(ChangedBy) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.changedBy = value;
        IsChanged = true;
      }
    }

    private DateTime createdAt;
    public DateTime CreatedAt
    {
      get
      {
        return this.createdAt;
      }
      set
      {
        if ((CheckRight(nameof(CreatedAt)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(CreatedAt) + " erlaubt");
        }
        this.createdAt = value;
        IsChanged = true;
      }
    }

    private string createdBy;
    public string CreatedBy
    {
      get
      {
        return this.createdBy;
      }
      set
      {
        if ((CheckRight(nameof(CreatedBy)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(CreatedBy) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.createdBy = value;
        IsChanged = true;
      }
    }

    private string description;
    public string Description
    {
      get
      {
        return this.description;
      }
      set
      {
        if ((CheckRight(nameof(Description)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(Description) + " erlaubt");
        }
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.description = value;
        IsChanged = true;
      }
    }

    private string isbn;
    public string Isbn
    {
      get
      {
        return this.isbn;
      }
      set
      {
        if ((CheckRight(nameof(Isbn)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(Isbn) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
	if (value != null && value.Length > 20)
				{
					throw new ON.Diagnostics.Exceptions.FormatException("Ungültiger Länge für Isbn: " + value, "Geben Sie bitte eine gültigen Wert ein!", Owner.LoggingIdentifier);
				}

        this.isbn = value;
        IsChanged = true;
      }
    }

    private string authorName;
    public string AuthorName
    {
      get
      {
        return this.authorName;
      }
      set
      {
        if ((CheckRight(nameof(AuthorName)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(AuthorName) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.authorName = value;
        IsChanged = true;
      }
    }

    private string title;
    public string Title
    {
      get
      {
        return this.title;
      }
      set
      {
        if ((CheckRight(nameof(Title)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(Title) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.title = value;
        IsChanged = true;
      }
    }

    //Rollen

    /// <summary>
    /// zum automatischen Nachaktivieren
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "das ist immutable")]
    public static readonly ActivationDelegate authorRollDelegate = new ActivationDelegate(authorRollDelegateFunction);


    private Author authorRoll;
    /// <summary>
    /// 
    /// liefert / setzt AuthorRoll
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "roll und key gleich behandeln")]

    public Author AuthorRoll
    {
      get
      {
        return this.authorRoll;
      }

      set
      {
         bool realChange = false;
        this.authorRoll = value;
        if (this.authorRoll != null && ((IntPrimaryKey)authorId != (IntPrimaryKey)this.authorRoll.Id || this.authorRoll.Id.IsNew))
        {
          IsChanged = true;
          realChange = true;
          authorId = (IntPrimaryKey)this.authorRoll.Id;
        }
        else if (this.authorRoll == null)
        {
          IsChanged = true;
          realChange = true;
          authorId = (IntPrimaryKey)Schulung.Core.Author.Dummy.Id.Empty;
        }
        if (realChange)
        {
          if ((CheckRight(nameof(AuthorRoll)) & ON.Data.Common.Rights.Write) == 0)
          {
            throw new SecurityException("kein schreibender Zugriff auf " + nameof(AuthorRoll) + " erlaubt");
          }
        }
      }
    }


    /// (r1)
    /// <summary>
    /// automatisches nachladen von AuthorRoll
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1072:JustifyAs", Justification = "Delegate bekommt unterschiedliche Objekte geliefert")]
    public static void authorRollDelegateFunction(ON.Data.Common.AbstractDataLayerObject data, ActivationDelegateCollection delegates)
    {
      var list = data as DatalayerCollectionWrapper;
      if (list != null)
      {
        if (list.List is DataLayerObjectCollection<Book> innerList)
        {
          MassActivateAuthorRoll(innerList, null, delegates);
        }
      }
      else
      {
        Book obj = data as Book;
        obj?.activateAuthorRoll(delegates);
      }
    }


    /// <summary>
    /// (r2)
    /// nachladen von AuthorRoll
    /// </summary>
    public void activateAuthorRoll()
    {
      activateAuthorRoll(EMPTY_DELEGATE_LIST);
    }

    /// <summary>
    /// (r3)
    /// nachladen von AuthorRoll
    /// </summary>
    /// <param name="delegates">nachzuaktivieren ...</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void activateAuthorRoll(ActivationDelegateCollection delegates)
    {
      if (!AuthorId.IsNew && this.authorRoll == null)
      {
        this.authorRoll = ON.Data.Common.AbstractDataLayerObject.Get<Schulung.Core.Author>(AuthorId, null, null, ConnectionString, Owner, delegates, Language, Schulung.Core.Author.Dummy.ExternalDataSource, null);
      }
    }

    /// <summary>
    /// (r4)
    /// nachladen von AuthorRoll
    /// </summary>
    /// <param name="trans">aktuelle Transaktion</param>
    /// <param name="con">aktuelle Datenbankverbindung</param>
    public void activateAuthorRoll(SqlTransaction trans, SqlConnection con)
    {
      activateAuthorRoll(trans, con, EMPTY_DELEGATE_LIST);
    }

    /// <summary>
    /// (r5)
    /// nachladen von AuthorRoll
    /// </summary>
    /// <param name="trans">aktuelle Transaktion</param>
    /// <param name="con">aktuelle Datenbankverbindung</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed bekommen")]
    public void activateAuthorRoll(SqlTransaction trans, SqlConnection con, ActivationDelegateCollection delegates)
    {
      if (!AuthorId.IsNew && this.authorRoll == null)
      {
        authorRoll = ON.Data.Common.AbstractDataLayerObject.Get<Schulung.Core.Author>(AuthorId, trans, con, ConnectionString, Owner, delegates, Language, Schulung.Core.Author.Dummy.ExternalDataSource, null);
      }
    }



    /// <summary>
    /// gleichzeitiges Nachladen aller AuthorRoll
    /// </summary>
    /// <param name="list"></param>
    /// <param name="loader">wenn null, dann der standard loadlist</param>
    /// <param name="delegates"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1063:OnlyPrimitivKeysInHashes", Justification = "IPrimaryKey passt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1049: AvoidStringBuilderToString")]
    public static DataLayerObjectCollection<Author> MassActivateAuthorRoll(DataLayerObjectCollection<Book> list, Func<string, OnSqlParameterCollection, string, IUser, ActivationDelegateCollection, Languages, DataLayerObjectCollection<Author>> loader = null, ActivationDelegateCollection delegates = null)
    {
      if (list == null || list.Count == 0)
      {
        return new DataLayerObjectCollection<Author>(0);
      }
      if (loader == null) //default
      {
        loader = Schulung.Core.Author.LoadList;
      }

      StringBuilder ids = new StringBuilder(list.Count * 7);
      foreach (var m in list)
      {
        if (m.AuthorRoll == null && !m.AuthorId.IsNew)
        {
          ids.Append(m.AuthorId.SQLObject).Append(',');
        }
      }

      if (ids.Length == 0)
      {
        return new DataLayerObjectCollection<Author> (0);
      }

      OnSqlParameterCollection param = new OnSqlParameterCollection(1)
      {
        { nameof(ids), ids.ToString().Trim(ON.Consts.SPLITTER_COMMA) }
      };
      var sortedList = loader("where Id in (select * from " + ON.Configuration.ConfigurationManager.PraefixForGlobalFunctions +  "fnSplitterInt(@ids))", param, list[0].ConnectionString, list[0].Owner, delegates, list[0].Language);
      var lookUpList = new Dictionary<IPrimaryKey, Author>(sortedList.Count * 4);
      foreach (var c in sortedList)
      {
        lookUpList[c.Id] = c;
      }

      foreach (var m in list)
      {
        if (m.AuthorRoll == null && !m.AuthorId.IsNew)
        {
          if (!lookUpList.ContainsKey(m.AuthorId))
          {
            throw new LogicalException($"Nicht in lookUpList: m.AuthorId: { m.AuthorId.SQLObject}");
          }
    m.AuthorRoll = lookUpList[m.AuthorId];
        }
      }

      return sortedList;
    }
    /// <summary>
    /// neues Leeres Rollenobject anlegen, wenn es noch keins gibt
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL")]
    public void createAuthorRoll()
    {
      if (AuthorRoll == null)
      {
        AuthorRoll = Schulung.Core.Author.Get(Dummy.Id.Empty, ConnectionString, Owner);
      }
    }

      //Collections


      //SQL
      [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    private const string tablename = "Books";

    private const string fulltablename = @"[dbo].[Books]"; //HINWEIS: Wenn Multilanguagefelder oder AdditionalFields in anderer DB liegen, dann läuft das nicht!
    private const string sqlschema = "dbo";

    private const string fieldsWId = @"[Books].[AuthorId],[Books].[ChangedAt],[Books].[ChangedBy],[Books].[CreatedAt],[Books].[CreatedBy],[Books].[Description],[Books].[Isbn], (SELECT Firstname + ' ' + Lastname FROM Authors WHERE Authors.Id = Books.AuthorId)  AS [AuthorName],[Books].[Title],[Books].[Id]";
    private const string valuesWId = @"@AuthorId,@ChangedAt,@ChangedBy,@CreatedAt,@CreatedBy,@Description,@Isbn,@AuthorName,@Title,@Id";
    private const string fieldsWOId = @"[Books].[AuthorId],[Books].[ChangedAt],[Books].[ChangedBy],[Books].[CreatedAt],[Books].[CreatedBy],[Books].[Description],[Books].[Isbn],[Books]. (SELECT Firstname + ' ' + Lastname FROM Authors WHERE Authors.Id = Books.AuthorId)  AS [AuthorName],[Books].[Title]";
    private const string valuesWOId = @"@AuthorId,@ChangedAt,@ChangedBy,@CreatedAt,@CreatedBy,@Description,@Isbn,@AuthorName,@Title";

    private string resolveSchema(string input)
    {
      return input;

    }

    /// <summary>
    /// Der Tabellenname (readonly)
    /// </summary>
    public override string TABLENAME => tablename;

    /// <summary>
    /// Mit Schema, oder auch mit JOIN auf multilanguageTable
    /// </summary>
    public override string FullTABLENAME => resolveSchema(fulltablename);

    /// <summary>
    /// Liste der Feldbezeichnungen inkl. Id (readonly)
    /// </summary>
    public override string FIELDSWITHID => fieldsWId;

    /// <summary>
    /// Liste der Feldbezeichnungen ohne ID (readonly)
    /// </summary>
    public override string FIELDSWITHOUTID => fieldsWOId;

    /// <summary>
    /// Liste der Values (@Feldbezeichnungen) inkl. ID (readonly)
    /// </summary>
    public override string VALUESWITHID => valuesWId;

    /// <summary>
    /// Liste der Values (@Feldbezeichnungen) ohne ID (readonly)
    /// </summary>
    public override string VALUESWITHOUTID => valuesWOId;

    /// <summary>
    /// Das verwendete SQL Schema (readonly)
    /// </summary>
    public override string SQLSchema => resolveSchema(sqlschema);

    /// <summary>
    /// wird diese Klasse gecacht?
    /// </summary>
    public override bool Cacheable => false;

    /// <summary>
    /// prüft die Korrektheit aller Attribute.
    /// Es wird jedem Attribut einfach der eigene Wert zugewiesen
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert, die Justification wird nur außerhalb benötigt")]
    public override void Check()
    {
#pragma warning disable CA2245 // Do not assign a property to itself.

AuthorId = AuthorId;
ChangedAt = ChangedAt;
ChangedBy = ChangedBy;
CreatedAt = CreatedAt;
CreatedBy = CreatedBy;
Description = Description;
Isbn = Isbn;
AuthorName = AuthorName;
Title = Title;

#pragma warning restore CA2245 // Do not assign a property to itself.
}

    /// <summary>
    /// soll vor dem Speichern alles nochmal getestet werden?
    /// </summary>
    public override bool CheckOnSave => false;



    /// <summary>
    /// (4)
    /// Erzeugt ein neues Book Objekt aus vorhandenem
    /// indem alle Felder kopiert werden (vor allem für BL von interesse)
    /// Die Umwandeloperation gibt es nicht mit Delegates ... macht keinen Sinn
    /// </summary>
    /// <param name="old">das Quellobject</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1053:DontUseDataLayerConstructors"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505: AvoidUnmaintainableCode")]
    public Book(Book old): base(old)
    {
      if (old == null)
      {
        throw new ArgumentNullException(nameof(old));
      }

      ConnectionString = old.ConnectionString;
      Owner = old.Owner;



      //alle felder kopieren

      authorId = old.authorId;
      changedAt = old.changedAt;
      changedBy = old.changedBy;
      createdAt = old.createdAt;
      createdBy = old.createdBy;
      description = old.description;
      isbn = old.isbn;
      authorName = old.authorName;
      title = old.title;
      id = old.id;
init();
      if (old.authorRoll != null)
      {
        authorRoll = old.authorRoll;
      }

      _changed = old._changed; //nicht auf die Property, denn ein event wollen wir hier nicht

}

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
      private void init()
      {
EnableLogging = false;

    }


    /// <summary>
    /// Befüllt ein Objekt mit allen daten der übergebenen datarow
    /// </summary>
    /// <param name="row">DataRow aus Select</param>
    /// <param name="con"></param>
    /// <param name="trans"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    public override void FillFromRow(IDataRecord row, SqlConnection con, SqlTransaction trans)
    {
      if (row == null)
      {
        throw new ArgumentNullException(nameof(row));
      }

      this.authorId = (IntPrimaryKey)CommonUtilities.GetValue(this.authorId, row,0);

      this.changedAt = CommonUtilities.GetValue(this.changedAt, row,1);
      this.changedBy = CommonUtilities.GetValue(this.changedBy, row,2);
      this.createdAt = CommonUtilities.GetValue(this.createdAt, row,3);
      this.createdBy = CommonUtilities.GetValue(this.createdBy, row,4);
      this.description = CommonUtilities.GetValue(this.description, row,5);
      this.isbn = CommonUtilities.GetValue(this.isbn, row,6);
      this.authorName = CommonUtilities.GetValue(this.authorName, row,7);
      this.title = CommonUtilities.GetValue(this.title, row,8);
			this.id = (IntPrimaryKey)CommonUtilities.GetValue(this.id, row,9);


      IsChanged = false; //denn es ist ja frisch geladen

checkActionRight(ON.Data.Common.Rights.Read, true);

      }

    /// <summary>
    /// erwartete Länge des XML ... damit gut SB größe
    /// </summary>
    protected override int defaultSBLength
    {
      get
      {
        return 5000;
      }
    }



    /// <summary>
    /// Liefert alle Attribute dieses Objekts als XML (kein root Element)
    /// </summary>
    /// <param name="includeSubobjects">
    /// Rollen und Collections
    /// </param>
    /// <param name="includeBinaryData">
    /// Wenn true, werden Binärdaten Base64 Kodiert ebenfalls im Xml ausgegeben
    /// </param>
    /// <param name="sb"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "includeBinaryData")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable", Justification = "reflection"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert, die Justification wird nur außerhalb benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein automatisches nachaktivieren bei lazy")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    public override void GetXml(bool includeSubobjects, bool includeBinaryData, StringBuilder sb)
    {
      if (sb == null)
      {
        throw new ArgumentNullException(nameof(sb));
      }

      if (GettingXML)
      {
//        LogManager.LogDebug("DataLayer", "getXML: " + GetType().FullName + "StackTrace: " + ON.GeneralUtilities.StackTrace, null);
        sb.Append("<breakingCycle/>");
        return;
      }
      GettingXML = true;
      if (XmlFormater != null)
      {
        XmlFormater.GetXml(includeSubobjects, false, sb);
        GettingXML = false;
        return;
      }
      else if (XmlFormaterString != null)
      {
        Type t = System.Type.GetType(XmlFormaterString);
        System.Reflection.MethodInfo m = t.GetMethod(nameof(GetXml), XmlFormaterStringonSqlparameters);
        m.Invoke(null, new object[3]{includeSubobjects, this, sb});
        GettingXML = false;
        return;
      }
      else
      {


        if((CheckRight(nameof(AuthorId)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.AppendXmlNode(nameof(authorId), AuthorId.ToString());
        if (AuthorId != null)
        {
          sb.AppendXmlNode(nameof(authorId) + "4HTML", AuthorId.HtmlName);
        }
        }

        if((CheckRight(nameof(ChangedAt)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.Append("<changedAt ticks=\"").Append(ChangedAt.Ticks).Append("\" cultureNeutral=\"").Append(ChangedAt.ToString(ON.Text.TextUtilities.DATETIME_FORMAT_ISO)).Append("\">" + ON.Text.TextUtilities.GetDefaultFormated(ChangedAt,Language).ReplaceEntities()).Append("</changedAt>");
        }

        if((CheckRight(nameof(ChangedBy)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (ChangedBy != null)
          {
            sb.AppendXmlNode(nameof(changedBy), ON.Text.TextUtilities.GetDefaultFormated(ChangedBy,Language).ReplaceEntities());
          }
        }

        if((CheckRight(nameof(CreatedAt)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.Append("<createdAt ticks=\"").Append(CreatedAt.Ticks).Append("\" cultureNeutral=\"").Append(CreatedAt.ToString(ON.Text.TextUtilities.DATETIME_FORMAT_ISO)).Append("\">" + ON.Text.TextUtilities.GetDefaultFormated(CreatedAt,Language).ReplaceEntities()).Append("</createdAt>");
        }

        if((CheckRight(nameof(CreatedBy)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (CreatedBy != null)
          {
            sb.AppendXmlNode(nameof(createdBy), ON.Text.TextUtilities.GetDefaultFormated(CreatedBy,Language).ReplaceEntities());
          }
        }

        if((CheckRight(nameof(Description)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Description != null)
          {
            sb.AppendXmlNode(nameof(description), ON.Text.TextUtilities.GetDefaultFormated(Description,Language)?.ReplaceEntities());
          }
        }

        if((CheckRight(nameof(Isbn)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Isbn != null)
          {
            sb.AppendXmlNode(nameof(isbn), ON.Text.TextUtilities.GetDefaultFormated(Isbn,Language).ReplaceEntities());
          }
        }

        if((CheckRight(nameof(AuthorName)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (AuthorName != null)
          {
            sb.AppendXmlNode(nameof(authorName), ON.Text.TextUtilities.GetDefaultFormated(AuthorName,Language).ReplaceEntities());
          }
        }

        if((CheckRight(nameof(Title)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Title != null)
          {
            sb.AppendXmlNode(nameof(title), ON.Text.TextUtilities.GetDefaultFormated(Title,Language).ReplaceEntities());
          }
        }

        if((CheckRight(nameof(Id)) & ON.Data.Common.Rights.Read) != 0)
        {

          sb.AppendXmlNode(nameof(id), Id.ToString().ReplaceEntities());



          sb.AppendXmlNode(nameof(id) + "4HTML", Id.HtmlName);


        }
      if(includeSubobjects)
      {

        if((CheckRight(nameof(AuthorRoll)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (authorRoll != null)
          {
            sb.AppendXmlNode(nameof(authorRoll), (sbInner) => authorRoll.GetXml(true, false, sbInner));
          }
        }

}
   
        base.GetXml(includeSubobjects, includeBinaryData, sb);
   
        GettingXML = false;
}

      }
        /// <summary>
    /// speichert alle Rollen dieses Objektes
    /// </summary>
    /// <param name="con">aktuelle Connection</param>
    /// <param name="trans">aktuelle Transaktion</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    protected override void SaveRoles(SqlConnection con, SqlTransaction trans)
    {

      if (authorRoll != null)
      {
        authorRoll.Save(con, trans);

authorId = (IntPrimaryKey)authorRoll.Id;


      }


}

    /// <summary>
    /// kaskadierendes löschen von Rollen
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="connection"></param>
    protected override void ProcessCascadeDeleteRolls(SqlTransaction trans, SqlConnection connection)
    {


}

     /// <summary>
    /// macht auch process des deletemarks der Roll: Merken der Roll, null Setzen der roll
    /// </summary>
    /// <param name="connection"></param>
    /// <param name="trans"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    protected override IEnumerable<ON.Data.Common.AbstractDataLayerObject> ProcessDeletedRolls(SqlConnection connection, SqlTransaction trans)
    {
      var ret = new List<ON.Data.Common.AbstractDataLayerObject>(1);

#pragma warning disable ON1057 // NullTestDL
      if (authorRoll != null && authorRoll.DeleteMark)
#pragma warning restore ON1057 // NullTestDL
      {
        ret.Add(authorRoll);
        AuthorRoll = null;
      }

      return ret;
    }


    /// <summary>
    /// Liefert die SQL Update Anweisung
    /// </summary>
    /// <returns>SQL Updateanweisung</returns>
    protected override string UpdateSql
    {
      get
      {
        string sql = string.Empty;
          
        sql += "AuthorId=@authorId,";
        sql += "ChangedAt=@changedAt,";
        sql += "ChangedBy=@changedBy,";
        sql += "CreatedAt=@createdAt,";
        sql += "CreatedBy=@createdBy,";
        sql += "Description=@description,";
        sql += "Isbn=@isbn,";
        sql += "Title=@title,";
        sql += "Id=@id,";
        return sql;
      }
    }


    /// <summary>
    /// Speichert alle Collections
    /// </summary>
    /// <param name="con">aktuelle Connection</param>
    /// <param name="trans">aktuelle Transaktion</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1076:AvoidNullEmptySQLParameterCollection", Justification = "where ist auch null"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public override void SaveCollections(SqlConnection con, SqlTransaction trans)
    {

    }



    /// <summary>
    /// Setzt bei allen Elementen der geladenen Collection die (neue) Id / Guid dieses 
    /// Objektes als foreign Key
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505: AvoidUnmaintainableCode")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1053:DontUseDataLayerConstructors"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    public override void UpdateCollections()
    {

    }


        /// <summary>
    /// Setzen der SQL Parameter (@) für delete (ohne pk und language)
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="onSqlparameters"></param>
    /// <param name="con"></param>
    /// <param name="trans"></param>
    public override void SetSqlDeleteParameters(SqlCommand cmd, OnSqlParameterCollection onSqlparameters, SqlConnection con, SqlTransaction trans)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

    }


        /// <summary>
    /// Setzt die SQL Parameter (alle Attribute) in dem übergebenen SQL Command
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="con"></param>
    /// <param name="trans"></param>
    /// <param name="iAmSaving"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    public override void SetSqlParameters(SqlCommand cmd, SqlConnection con, SqlTransaction trans, bool iAmSaving)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }


       cmd.Parameters.AddWithValue("@authorId", CommonUtilities.SetIdValue(this.authorId));
       cmd.Parameters.Add(new SqlParameter("@changedAt", SqlDbType.DateTime2) { Value = CommonUtilities.SetValue(this.changedAt) });
       cmd.Parameters.Add(new SqlParameter("@changedBy", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.changedBy) });
       cmd.Parameters.Add(new SqlParameter("@createdAt", SqlDbType.DateTime2) { Value = CommonUtilities.SetValue(this.createdAt) });
       cmd.Parameters.Add(new SqlParameter("@createdBy", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.createdBy) });
       cmd.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.description) });
       cmd.Parameters.Add(new SqlParameter("@isbn", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.isbn) });
       cmd.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.title) });
			  cmd.Parameters.AddWithValue("@id", CommonUtilities.SetIdValue(this.id));
    }


    /// <summary>
    /// Löschen aller abhäniger DataObjects
    /// </summary>
    protected override void deleteDataObjects(SqlConnection con, SqlTransaction trans)
    {
  
    
    }


    /// <summary>
    /// Stellt einen DataTable zusammen, der dieses Objekt repräsentiert
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1011:AvoidDataTableDataSetSQLDataAdapter", Justification = "für WebServices"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positiv?"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable",Justification = "schnittstelle")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091: UseNameOf")]
    public override DataTable BuildDataTable(DataTable dt)
    {
      bool newTable = false;
      DataTable dtTemp = null;
      try
      {
        if (dt == null)
        {
          dtTemp = new DataTable();
          dt = dtTemp;
          newTable = true;
        }
        DataRow row = dt.NewRow();
  
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("AuthorId", typeof(int)));
      }
      row["AuthorId"] = CommonUtilities.SetValueNF(this.authorId);
  
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("ChangedAt", typeof(DateTime)));
      }
      row["ChangedAt"] = CommonUtilities.SetValue(this.changedAt);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("ChangedBy", typeof(string)));
      }
      row["ChangedBy"] = CommonUtilities.SetValue(this.changedBy);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("CreatedAt", typeof(DateTime)));
      }
      row["CreatedAt"] = CommonUtilities.SetValue(this.createdAt);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
      }
      row["CreatedBy"] = CommonUtilities.SetValue(this.createdBy);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("Description", typeof(string)));
      }
      row["Description"] = CommonUtilities.SetValue(this.description);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("Isbn", typeof(string)));
      }
      row["Isbn"] = CommonUtilities.SetValue(this.isbn);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("AuthorName", typeof(string)));
      }
      row["AuthorName"] = CommonUtilities.SetValue(this.authorName);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("Title", typeof(string)));
      }
      row["Title"] = CommonUtilities.SetValue(this.title);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("Id", typeof(int)));
      }
      row["Id"] = CommonUtilities.SetValueNF(this.id);
	
    
        if (newTable)
        {
          DataColumn[] pk = new DataColumn[1];
          pk[0] = dt.Columns["Id"];
          dt.PrimaryKey = pk;
        }
      if (newTable)
      {
        dt.Columns.Add(new DataColumn(nameof(DeleteMark), typeof(bool)));
      }
      row[nameof(DeleteMark)] = DeleteMark;

        dt.Rows.Add(row);
        dtTemp = null;
        return dt;
      }
      finally
      {
        if (dtTemp != null)
        {
          dtTemp.Dispose();
        }
      }
    }


    /// <summary>
    /// wird gerufen beim Kopieren eines Datensatzes aus dem Adminsimulator. Kopiert Collections, 
    /// setzt publizierte Feld aus Empty wenn dies konfiguriert ist
    /// </summary>
    public override void prepareForCopy()
    {
    

    }


    
    /// <summary>
    /// true, wenn es dieses Object in der DB gibt
    /// </summary>
    /// <param name="id">id des Objektes</param>
    /// <param name="connectionString">ConnectionString</param>
    /// <returns>true, wenn es dieses Object in der DB gibt</returns>
    public static bool Exists(IGetSqlObject id, string connectionString)
    {
      if (id == null)
      {
        throw new ArgumentNullException(nameof(id));
      }

      OnSqlParameterCollection onSqlparameters = new OnSqlParameterCollection(1)
      {
        new OnSqlParameter("@id", id.SQLObject) //3
      };


			return Exists("Id=@id", onSqlparameters, connectionString);


    }


    /// <summary>
    /// true, w?    /// true, wenn es dieses Object in der DB gibt
    /// </summary>
    /// <param name="sqlWhere">SQL Where Klausel inkl. Schlüsselwort Where</param>
    /// <param name="onSqlparameters"></param>
    /// <param name="connectionString">ConnectionString</param>
    /// <returns>true, wenn es dieses Object in der DB gibt</returns>
    public static bool Exists(string sqlWhere, OnSqlParameterCollection onSqlparameters, string connectionString)
    {
      return Count(sqlWhere, onSqlparameters, connectionString, Languages.None, Dummy.ExternalDataSource) > 0;
    }

    /// <summary>
    /// true, w?    /// true, wenn es dieses Object in der DB gibt
    /// </summary>
    /// <param name="sqlWhere">SQL Where Klausel inkl. Schlüsselwort Where</param>
    /// <param name="onSqlparameters"></param>
    /// <param name="connectionString">ConnectionString</param>
    /// <param name="lang">Languages</param>
    /// <returns>true, wenn es dieses Object in der DB gibt</returns>
    public static bool Exists(string sqlWhere, OnSqlParameterCollection onSqlparameters, string connectionString, Languages lang)
    {
      return Count(sqlWhere, onSqlparameters, connectionString, lang, Dummy.ExternalDataSource) > 0;
    }

    /// <summary>
    /// Anzahl der Treffer
    /// </summary>
    /// <param name="sqlWhere">SQL Where Klausel inkl. Schlüsselwort Where</param>
    /// <param name="onSqlparameters"></param>
    /// <param name="connectionString">ConnectionString</param>
    /// <returns>Anzahl der Treffer</returns>
    public static int Count(string sqlWhere, OnSqlParameterCollection onSqlparameters, string connectionString)
    {
      return Count(sqlWhere, onSqlparameters, connectionString, Languages.None, Dummy.ExternalDataSource);
    }

    /// <summary>
    /// Anzahl der Treffer
    /// </summary>
    /// <param name="sqlWhere">SQL Where Klausel inkl. Schlüsselwort Where</param>
    /// <param name="onSqlparameters"></param>
    /// <param name="connectionString">ConnectionString</param>
    /// <param name="lang">Languages</param>
    /// <param name="externalDataSource">externalDataSource</param>
    /// <returns>Anzahl der Treffer</returns>
    public static int Count(string sqlWhere, OnSqlParameterCollection onSqlparameters, string connectionString, Languages lang, IExternalDataSource externalDataSource)
    {
      var cache = Dummy.GetDataLayerCache();
      int ret;

      if (externalDataSource == null)
      {
        externalDataSource = Dummy.ExternalDataSource;
      }

      if (externalDataSource != null)
      {
        ret = externalDataSource.GetCount(sqlWhere, onSqlparameters);
      }
      else
      {
        if (cache != null)
        {
          var count = cache.getResultCount<Book>(Dummy, sqlWhere, onSqlparameters);

          if (count != null)
          {
            return count.Count;
          }
        }

        ret = CommonUtilities.Count(sqlWhere, onSqlparameters, connectionString, Dummy.FullTABLENAME.Replace("@language", ((int)lang).ToString()), externalDataSource);

        if (cache != null)
        {
          var rc = new ResultCount()
          {
            Count = ret
          };
          cache.putResultCount<Book>(Dummy, sqlWhere, onSqlparameters, rc);
        }
      }

      return ret;
    }



    /// <summary>
    /// Now oder UTC Now
    /// </summary>    
    public override DateTime GetNow()
    {
      return DateTime.UtcNow;
    }

    /// <summary>
    /// Setzt den Change (=owner) falls vorhanden
    /// und bei bedarf published
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public override void SetChanger(DateTime now)
    {
      if (!Publishing)
      {
        changedBy = Owner.LoggingIdentifier;
      }

      if (!Publishing)
      {
        changedAt = now;
      }

      if(Id.IsNew)
      {

        createdBy = Owner.LoggingIdentifier;

        createdAt = now;


      }
    }

    /// <summary>
    /// liefert die Bezeichnung der PK (id/guid) Spalte in der DB
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    public override string IdDbName => "[Id]";


    /// <summary>
    /// liefert das Datum der letzten Änderung
    /// </summary>
    public DateTime ModifiedAt => ChangedAt;

    /// <summary>
    /// liefert den Benutzernamen der letzten Änderung
    /// </summary>
    public string ModifiedBy => ChangedBy;

    /// <summary>
    /// setzt ChangedAt/ChangedBy
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void SetModified(IUser user)
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      changedBy = user.LoggingIdentifier;
      changedAt = DateTime.UtcNow;
    }


    /// <summary>
    /// Liefert die 0-3 Zeilen aus erstellt von ... bearbeitet von ... 
    /// erstellt
    /// bearbeitet
    /// publiziert
    /// als string[] mit
    /// 0: Label
    /// 1: datum + person
    /// </summary>
    public override List<string[]> GetInfo
    {
      get
      {
        List<string[]> a = new List<string[]>(5);
        

        string[] result0 = new string[2];
        result0[0] = "ElementID:";
        result0[1] = Id.ToString();
        a.Add(result0);


        string[] result = new string[2];
        result[0] = "Erstellt:";


        result[1] = CreatedAt.GetStringShort() + " " + CreatedBy;

        a.Add(result);

        string[] result2 = new string[2];
        result2[0] = "Geändert:";


        result2[1] = ChangedAt.GetStringShort() + " " + ChangedBy;

        a.Add(result2);
        return a;
      }
    }

    /// <summary>
    /// Serialisiert das Objekt
    /// </summary>
#pragma warning disable ON1091 // UseNameOf
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "info")]
#pragma warning restore ON1091 // UseNameOf
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
    public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
      if (info == null)
      {
        throw new ArgumentNullException(nameof(info));
      }

      info.AddValue(nameof(authorId), this.authorId);
      info.AddValue(nameof(changedAt), this.changedAt);
      info.AddValue(nameof(changedBy), this.changedBy);
      info.AddValue(nameof(createdAt), this.createdAt);
      info.AddValue(nameof(createdBy), this.createdBy);
      info.AddValue(nameof(description), this.description);
      info.AddValue(nameof(isbn), this.isbn);
      info.AddValue(nameof(authorName), this.authorName);
      info.AddValue(nameof(title), this.title);
      info.AddValue(nameof(authorRoll), this.authorRoll);
      base.GetObjectData(info, context);
    }

    /// <summary>
    /// Deserialisiert das Objekt
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable", Justification = ".NET")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
    protected Book(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
      if (info == null)
      {
        throw new ArgumentNullException(nameof(info));
      }


      authorId = (IntPrimaryKey)info.GetValue(nameof(authorId), typeof(IntPrimaryKey));
      this.changedAt = info.GetDateTime(nameof(changedAt));
      this.changedBy = info.GetString(nameof(changedBy));
      this.createdAt = info.GetDateTime(nameof(createdAt));
      this.createdBy = info.GetString(nameof(createdBy));
      this.description = info.GetString(nameof(description));
      this.isbn = info.GetString(nameof(isbn));
      this.authorName = info.GetString(nameof(authorName));
      this.title = info.GetString(nameof(title));
      this.authorRoll = (Author)info.GetValue(nameof(authorRoll), typeof(Schulung.Core.Author));
   init();
    }
    

      /// <summary>
      /// Bulk save (nur insert) größerer Datenmengen
      /// </summary>
      /// <param name="list"></param>
      /// <param name="con"></param>
      /// <param name="trans"></param>
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "using: Offensichtlich false positiv")]
      [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
      public static void BulkSave(IList list, SqlConnection con, SqlTransaction trans)
      {
        using (SqlBulkCopy copy = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity, trans))
        {
          if (list != null && list.Count > 0)
          {
            string tn = string.Empty;
            DataTable table = null;
            for (int i = 0; i < list.Count; i++)
            {
              Book field = (Book)list[i];
              tn = field.FullTABLENAME;
              if (field.Id.IsNew)
              {
                field.Id = new GuidPrimaryKey(Guid.NewGuid());
              }
              else
              {
                throw new TechnicalException("BulkSave kann nur insert!!!");
              }
              table = field.BuildDataTable(table);
            }
            copy.DestinationTableName = tn;
        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("AuthorId", "AuthorId"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ChangedAt", "ChangedAt"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ChangedBy", "ChangedBy"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CreatedAt", "CreatedAt"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CreatedBy", "CreatedBy"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Description", "Description"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Isbn", "Isbn"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Title", "Title"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Id", "Id"));
            copy.WriteToServer(table);
          }
        }
      }    
    /// <summary>
    /// Serialisert das Objektr als XML
    /// </summary>
    /// <param name="writer"></param>
    public override void WriteXml(System.Xml.XmlWriter writer)
    {
      if (writer == null)
      {
        throw new ArgumentNullException(nameof(writer));
      }


      StringBuilder sb = new StringBuilder(defaultSBLength);
      this.GetXml(true, true, sb);
      writer.WriteRawStringBuilder(sb);
    }

    /// <summary>
    /// Gibt das Schema des Serialisierten Objekts zurück
    /// </summary>
    /// <returns></returns>
    public override System.Xml.Schema.XmlSchema GetSchema()
    {
      return null;
    }

    /// <summary>
    /// Deserialisert das Objekt aus dem XML
    /// </summary>
    /// <param name="reader"></param>
       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals", Justification = "generiert"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1038:AvoidMultipleGetData", Justification = "false positiv"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    public override void ReadXml(System.Xml.XmlReader reader)
    {
      System.Xml.XmlDocument doc = new System.Xml.XmlDocument(){ XmlResolver = null };
      doc.Load(reader);
      System.Xml.XmlNode node;
      node = doc.SelectSingleNode("*/authorId");
      if (node != null)
      {
        this.authorId = new IntPrimaryKey(Convert.ToInt32(node.InnerText));
      }
      node = doc.SelectSingleNode("*/changedAt");
      if (node != null)
      {
        this.changedAt = Convert.ToDateTime(node.Attributes["cultureNeutral"].Value);
      }
      node = doc.SelectSingleNode("*/changedBy");
      if (node != null)
      {
        this.changedBy = node.InnerText;
      }
      node = doc.SelectSingleNode("*/createdAt");
      if (node != null)
      {
        this.createdAt = Convert.ToDateTime(node.Attributes["cultureNeutral"].Value);
      }
      node = doc.SelectSingleNode("*/createdBy");
      if (node != null)
      {
        this.createdBy = node.InnerText;
      }
      node = doc.SelectSingleNode("*/description");
      if (node != null)
      {
        this.description = node.InnerText;
      }
      node = doc.SelectSingleNode("*/isbn");
      if (node != null)
      {
        this.isbn = node.InnerText;
      }
      node = doc.SelectSingleNode("*/authorName");
      if (node != null)
      {
        this.authorName = node.InnerText;
      }
      node = doc.SelectSingleNode("*/title");
      if (node != null)
      {
        this.title = node.InnerText;
      }
      node = doc.SelectSingleNode("*/authorRoll");
      if (node != null)
      {
        string xmlgeneriert = node.OuterXml;
        System.Xml.XmlReader xmlreader = null;
        System.IO.StringReader strreader = null;

        try
        {
          strreader = new System.IO.StringReader(xmlgeneriert);
          xmlreader = ON.Xml.XMLUtilities.CreateXmlReader(strreader);
          strreader = null;
          Schulung.Core.Author obj = Schulung.Core.Author.Get(Schulung.Core.Author.Dummy.Id, ConnectionString, Owner);//yyy
          obj.ReadXml(xmlreader);
          authorRoll = obj;
        }
        finally
        {
          xmlreader?.Close();
          strreader?.Dispose();
        }
      }
    }

    /// <summary>
    /// Liefert den SQL Spalten Namen zur Property
    /// </summary>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091: UseNameOf")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    public override string GetSQLName(string propertyName)
    {
      if (propertyName == null)
      {
        throw new ArgumentNullException(nameof(propertyName));
      }

     var org = propertyName;
  propertyName = propertyName.Replace("[", string.Empty).Replace("]", string.Empty);
      if (propertyName.Equals(nameof(authorId), StringComparison.OrdinalIgnoreCase))
      {
        return "[AuthorId]";
      }
      else if (propertyName.Equals("Books.authorId", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[AuthorId]";
      }
      else if (propertyName.Equals(nameof(changedAt), StringComparison.OrdinalIgnoreCase))
      {
        return "[ChangedAt]";
      }
      else if (propertyName.Equals("Books.changedAt", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[ChangedAt]";
      }
      else if (propertyName.Equals(nameof(changedBy), StringComparison.OrdinalIgnoreCase))
      {
        return "[ChangedBy]";
      }
      else if (propertyName.Equals("Books.changedBy", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[ChangedBy]";
      }
      else if (propertyName.Equals(nameof(createdAt), StringComparison.OrdinalIgnoreCase))
      {
        return "[CreatedAt]";
      }
      else if (propertyName.Equals("Books.createdAt", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[CreatedAt]";
      }
      else if (propertyName.Equals(nameof(createdBy), StringComparison.OrdinalIgnoreCase))
      {
        return "[CreatedBy]";
      }
      else if (propertyName.Equals("Books.createdBy", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[CreatedBy]";
      }
      else if (propertyName.Equals(nameof(description), StringComparison.OrdinalIgnoreCase))
      {
        return "[Description]";
      }
      else if (propertyName.Equals("Books.description", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[Description]";
      }
      else if (propertyName.Equals(nameof(isbn), StringComparison.OrdinalIgnoreCase))
      {
        return "[Isbn]";
      }
      else if (propertyName.Equals("Books.isbn", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[Isbn]";
      }
      else if (propertyName.Equals(nameof(authorName), StringComparison.OrdinalIgnoreCase))
      {
        return "[AuthorName]";
      }
      else if (propertyName.Equals("Books.authorName", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[AuthorName]";
      }
      else if (propertyName.Equals(nameof(title), StringComparison.OrdinalIgnoreCase))
      {
        return "[Title]";
      }
      else if (propertyName.Equals("Books.title", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[Title]";
      }
      else if (propertyName.Equals(nameof(id), StringComparison.OrdinalIgnoreCase))
      {
        return "[Id]";
      }
      else if (propertyName.Equals("Books.id", StringComparison.OrdinalIgnoreCase))
      {
        return "[Books].[Id]";
      }
      else
      {
        return base.GetSQLName(org);
      }
  }


    /// <summary>
    /// reload von sich selber liefern
    /// Neue Transaction, keine ExceptionOnNotFound
    /// </summary>
    /// <returns></returns>
    public override ON.Data.Common.AbstractDataLayerObject GetOldVersion()
    {
      OnSqlParameterCollection param = new OnSqlParameterCollection(2);
      string sqlWhere = getPKWhere<Book>(Id, param, Language);
      return Get<Book>(sqlWhere, param, null, null, ConnectionString, Owner, null, Language, null, null,false);
    }

    /// <summary>
    /// Funktion kommt durch die Datenklasse
    /// </summary>
    /// <param name="dataObject"></param>
    /// <param name="action"></param>
    /// <param name="con"></param>
    /// <param name="trans"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert, die Justification wird nur außerhalb benötigt"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "action", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1049:AvoidStringBuilderToString", Justification = "Wird nicht weiter ergänzt")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    public override void OnPublixLogbuchArchiver(ON.Data.Common.AbstractDataLayerObject dataObject, Actions action, SqlConnection con, SqlTransaction trans)
    {
      StringBuilder sb = new StringBuilder("<data>", 5000);
      if (action != Actions.Update) //full log
      {
        GetXml(false, false, sb);
      }
      else //diff xml
      {
        //alte Daten beschaffen

        Book oldVersion = ON.Data.Common.AbstractDataLayerObject.Get<Book>(Id, trans, con, ConnectionString, Owner, null, Language, ExternalDataSource, null);
        GetDiffXml(sb, oldVersion);

      }


      sb.Append("</data>");
      LogbuchEntry entry = new LogbuchEntry(Owner.LoggingIdentifier, null, "none", "Schulung.Core.Book", DateTime.UtcNow, sb.ToString(), Id.ToString(), action);


      OnPublixLogbuch.Write(entry);
    }


    /// <summary>
    /// Ein Diff XML zwischen diesem Objekt und dem übergebenen erzeugen
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="oldVersion"></param>
    /// <param name="removeHtml"></param>
    /// <param name="includeRolesAndCollections"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "removeHtml", Justification = ""), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL", Justification = "ist ein null check"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "generiert")]
    public void GetDiffXml(StringBuilder sb, Book oldVersion, bool removeHtml = false, bool includeRolesAndCollections = false)
    {
      GetDiffXml(sb, oldVersion, removeHtml, includeRolesAndCollections, null, null);
    }


    /// <summary>
    /// Ein Diff XML zwischen diesem Objekt und dem übergebenen erzeugen
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="oldVersion"></param>
    /// <param name="removeHtml"></param>
    /// <param name="includeRolesAndCollections"></param>
    /// <param name="con">offene Connection</param>
    /// <param name="trans">lauftende Transaction</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "con", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "trans", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "removeHtml", Justification = ""), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL", Justification = "ist ein null check"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "generiert")]
    public void GetDiffXml(StringBuilder sb, Book oldVersion, bool removeHtml, bool includeRolesAndCollections, SqlTransaction trans, SqlConnection con)
    {
      GetDiffXml(sb, oldVersion, removeHtml, includeRolesAndCollections, includeRolesAndCollections, trans, con);
    }


    /// <summary>
    /// Ein Diff XML zwischen diesem Objekt und dem übergebenen erzeugen
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="oldVersion"></param>
    /// <param name="removeHtml"></param>
    /// <param name="includeRolesAndCollections"></param>
    /// <param name="con">offene Connection</param>
    /// <param name="trans">lauftende Transaction</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "con", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "trans", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "removeHtml", Justification = ""), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL", Justification = "ist ein null check"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "generiert")]
    public override void GetDiffXml(StringBuilder sb, ON.Data.Common.AbstractDataLayerObject oldVersion, bool removeHtml, bool includeRolesAndCollections, SqlTransaction trans, SqlConnection con)
      {
         GetDiffXml(sb, (Book)oldVersion, removeHtml, includeRolesAndCollections, trans, con);
      }


    /// <summary>
    /// Ein Diff XML zwischen diesem Objekt und dem übergebenen erzeugen
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="oldVersion"></param>
    /// <param name="removeHtml"></param>
    /// <param name="includeRoles"></param>
    /// <param name="includeCollections"></param>
    /// <param name="con">offene Connection</param>
    /// <param name="trans">lauftende Transaction</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1076: AvoidNullEmptySQLParameterCollection")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "con", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "trans", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "removeHtml", Justification = ""), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL", Justification = "ist ein null check"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "generiert")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    public override void GetDiffXml(StringBuilder sb, ON.Data.Common.AbstractDataLayerObject oldVersion, bool removeHtml, bool includeRoles, bool includeCollections, SqlTransaction trans, SqlConnection con)
      {
        GetDiffXml(sb,  (Book) oldVersion, removeHtml, includeRoles, includeCollections, trans, con);
      }
        


    /// <summary>
    /// Ein Diff XML zwischen diesem Objekt und dem übergebenen erzeugen
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="oldVersion"></param>
    /// <param name="removeHtml"></param>
    /// <param name="includeRoles"></param>
    /// <param name="includeCollections"></param>
    /// <param name="con">offene Connection</param>
    /// <param name="trans">lauftende Transaction</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1076: AvoidNullEmptySQLParameterCollection")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809: AvoidExcessiveLocals")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "con", Justification = "für Rollen und collections benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "trans", Justification = "für Rollen und collections benötigt"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "removeHtml", Justification = ""), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL", Justification = "ist ein null check"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "generiert"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "generiert")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
#pragma warning disable IDE0060 // Remove unused parameter
    public void GetDiffXml(StringBuilder sb, Book oldVersion, bool removeHtml, bool includeRoles, bool includeCollections, SqlTransaction trans, SqlConnection con)
#pragma warning restore IDE0060 // Remove unused parameter
    {
      if (oldVersion == null)
      {
        throw new ArgumentNullException(nameof(oldVersion));
      }
      if (sb == null)
      {
        throw new ArgumentNullException(nameof(sb));
      }
      //alle felder durchlaufen und wenn alt != neu : loggen

      if (oldVersion.AuthorId != this.AuthorId)
      {
        sb.Append(@"<kommentar type=""foreignKey"" field=""AuthorId"" label=""""><old>");

        if((CheckRight(nameof(AuthorId)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.AppendXmlNode(nameof(authorId), oldVersion.AuthorId.ToString());
        if (oldVersion.AuthorId != null)
        {
          sb.AppendXmlNode(nameof(authorId) + "4HTML", oldVersion.AuthorId.HtmlName);
        }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(AuthorId)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.AppendXmlNode(nameof(authorId), AuthorId.ToString());
        if (AuthorId != null)
        {
          sb.AppendXmlNode(nameof(authorId) + "4HTML", AuthorId.HtmlName);
        }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.ChangedAt != this.ChangedAt)
      {
        sb.Append(@"<kommentar type=""DateTime"" field=""ChangedAt"" label=""""><old>");

        if((CheckRight(nameof(ChangedAt)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.Append("<changedAt ticks=\"").Append(oldVersion.ChangedAt.Ticks).Append("\" cultureNeutral=\"").Append(oldVersion.ChangedAt.ToString(ON.Text.TextUtilities.DATETIME_FORMAT_ISO)).Append("\">" + ON.Text.TextUtilities.GetDefaultFormated(oldVersion.ChangedAt,Language).ReplaceEntities()).Append("</changedAt>");
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(ChangedAt)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.Append("<changedAt ticks=\"").Append(ChangedAt.Ticks).Append("\" cultureNeutral=\"").Append(ChangedAt.ToString(ON.Text.TextUtilities.DATETIME_FORMAT_ISO)).Append("\">" + ON.Text.TextUtilities.GetDefaultFormated(ChangedAt,Language).ReplaceEntities()).Append("</changedAt>");
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.ChangedBy != this.ChangedBy)
      {
        sb.Append(@"<kommentar type=""string"" field=""ChangedBy"" label=""""><old>");

        if((CheckRight(nameof(ChangedBy)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.ChangedBy != null)
          {
            sb.AppendXmlNode(nameof(changedBy), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.ChangedBy,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(ChangedBy)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (ChangedBy != null)
          {
            sb.AppendXmlNode(nameof(changedBy), ON.Text.TextUtilities.GetDefaultFormated(ChangedBy,Language).ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.CreatedAt != this.CreatedAt)
      {
        sb.Append(@"<kommentar type=""DateTime"" field=""CreatedAt"" label=""""><old>");

        if((CheckRight(nameof(CreatedAt)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.Append("<createdAt ticks=\"").Append(oldVersion.CreatedAt.Ticks).Append("\" cultureNeutral=\"").Append(oldVersion.CreatedAt.ToString(ON.Text.TextUtilities.DATETIME_FORMAT_ISO)).Append("\">" + ON.Text.TextUtilities.GetDefaultFormated(oldVersion.CreatedAt,Language).ReplaceEntities()).Append("</createdAt>");
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(CreatedAt)) & ON.Data.Common.Rights.Read) != 0)
        {
        sb.Append("<createdAt ticks=\"").Append(CreatedAt.Ticks).Append("\" cultureNeutral=\"").Append(CreatedAt.ToString(ON.Text.TextUtilities.DATETIME_FORMAT_ISO)).Append("\">" + ON.Text.TextUtilities.GetDefaultFormated(CreatedAt,Language).ReplaceEntities()).Append("</createdAt>");
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.CreatedBy != this.CreatedBy)
      {
        sb.Append(@"<kommentar type=""string"" field=""CreatedBy"" label=""""><old>");

        if((CheckRight(nameof(CreatedBy)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.CreatedBy != null)
          {
            sb.AppendXmlNode(nameof(createdBy), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.CreatedBy,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(CreatedBy)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (CreatedBy != null)
          {
            sb.AppendXmlNode(nameof(createdBy), ON.Text.TextUtilities.GetDefaultFormated(CreatedBy,Language).ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.Description != this.Description)
      {
        sb.Append(@"<kommentar type=""string"" field=""Description"" label=""""><old>");

        if((CheckRight(nameof(Description)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.Description != null)
          {
            sb.AppendXmlNode(nameof(description), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.Description,Language).RemoveHtmlTags(removeHtml)?.ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(Description)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Description != null)
          {
            sb.AppendXmlNode(nameof(description), ON.Text.TextUtilities.GetDefaultFormated(Description,Language).RemoveHtmlTags(removeHtml)?.ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.Isbn != this.Isbn)
      {
        sb.Append(@"<kommentar type=""string"" field=""Isbn"" label=""""><old>");

        if((CheckRight(nameof(Isbn)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.Isbn != null)
          {
            sb.AppendXmlNode(nameof(isbn), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.Isbn,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(Isbn)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Isbn != null)
          {
            sb.AppendXmlNode(nameof(isbn), ON.Text.TextUtilities.GetDefaultFormated(Isbn,Language).ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.AuthorName != this.AuthorName)
      {
        sb.Append(@"<kommentar type=""string"" field=""AuthorName"" label=""""><old>");

        if((CheckRight(nameof(AuthorName)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.AuthorName != null)
          {
            sb.AppendXmlNode(nameof(authorName), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.AuthorName,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(AuthorName)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (AuthorName != null)
          {
            sb.AppendXmlNode(nameof(authorName), ON.Text.TextUtilities.GetDefaultFormated(AuthorName,Language).ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.Title != this.Title)
      {
        sb.Append(@"<kommentar type=""string"" field=""Title"" label=""""><old>");

        if((CheckRight(nameof(Title)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.Title != null)
          {
            sb.AppendXmlNode(nameof(title), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.Title,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(Title)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Title != null)
          {
            sb.AppendXmlNode(nameof(title), ON.Text.TextUtilities.GetDefaultFormated(Title,Language).ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if ((IntPrimaryKey)oldVersion.Id != (IntPrimaryKey)this.Id)
      {
        sb.Append(@"<kommentar type=""id"" field=""Id"" label=""""><old>");

        if((CheckRight(nameof(Id)) & ON.Data.Common.Rights.Read) != 0)
        {

          sb.AppendXmlNode(nameof(id), oldVersion.Id.ToString().ReplaceEntities());



          sb.AppendXmlNode(nameof(id) + "4HTML", oldVersion.Id.HtmlName);


        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(Id)) & ON.Data.Common.Rights.Read) != 0)
        {

          sb.AppendXmlNode(nameof(id), Id.ToString().ReplaceEntities());



          sb.AppendXmlNode(nameof(id) + "4HTML", Id.HtmlName);


        }
        sb.Append("</new></kommentar>");
      }

      if(includeRoles)
      {


        object oldvalue;
        object newvalue;

  oldvalue = string.Empty;
  newvalue = string.Empty;


activateAuthorRoll(trans, con);
  oldVersion.activateAuthorRoll(trans, con);

  if(oldVersion.AuthorRoll != null)
  {
     oldvalue = oldVersion.AuthorRoll.FachlicherPk;
  }

  if(AuthorRoll != null)
  {
     newvalue = AuthorRoll.FachlicherPk;
  }

  if (!oldvalue.Equals(newvalue))
  {
    sb.Append(@"<role roleId=""AuthorId"" field=""Author"" label="""">");
    string temp = oldvalue.ToString().ReplaceEntities();
    sb.Append(@"<old>").Append(temp).Append("</old>");
    temp = newvalue.ToString().ReplaceEntities();
    sb.Append(@"<new>").Append(temp).Append("</new>");
    sb.Append(@"</role>");
  }




      }
      if(includeCollections)
      {
      }
    }

    /// <summary>
    /// Speichervorverarbeitung
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="isPostback"></param>
    /// <param name="isValid"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    public override bool Process(object sender, bool isPostback, bool isValid, string command)
    {
      return true;
    }

  }//class
}//namespace
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
