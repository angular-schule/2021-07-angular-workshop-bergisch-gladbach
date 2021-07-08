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
  /// Kapselt den Datenzugriff auf eine Zeile der Tabelle Authors
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013: privateMemberpublicProperty"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1046:AvoidUselessToString"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1063:OnlyPrimitivKeysInHashes"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1066:StringOpInStringBuilderAppend"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1081:NoMoreThan3Overloads"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1072:JustifyAs"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1053:DontUseDataLayerConstructors", Justification = "ist ur MN"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1056:Justify", Justification = "generiert, die Justification wird nur außerhalb benötigt"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), Serializable]
  public class Author: ON.Data.Common.AbstractDataLayerObject, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable,IChangeable,ICreateable
  {
    /// <summary>
    /// Dummy für Replication und generics
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Author()
    {
      //leere id
      id = new IntPrimaryKey(-1);


      init();
    }


    /// <summary>
    /// Dummy Object zum Zugriff auf nicht statische Felder
    /// </summary>
    public static Author Dummy { get; } = new Author();
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
    public static DataLayerObjectCollection<Author> LoadList(string sqlWhere, string join, string order, OnSqlParameterCollection onSqlparameters, SqlTransaction trans, SqlConnection con, string connectionString, IUser owner, int top = -1, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, IDataLayerCache cache = null)
    {
      return LoadList<Author>(sqlWhere, join, order, onSqlparameters, trans, con, connectionString, owner, top, delegates, lang, externalDataSource ?? Dummy.ExternalDataSource, Dummy, cache);
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
    public static DataLayerObjectCollection<Author> LoadList(string where, OnSqlParameterCollection onSqlparameters, string ConnectionString, IUser Owner, ActivationDelegateCollection delegates = null, Languages Language = Languages.None)
    {
      return LoadList<Author>(where, null, null, onSqlparameters, null, null, ConnectionString, Owner, -1, delegates, Language, Dummy.ExternalDataSource, Dummy, null);
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
    public static DataLayerObjectCollection<Author> LoadSortedPage(string filter, string sort, string connectionString, IUser owner, string join, int pageSize, int pageIndex, SqlConnection con, SqlTransaction trans, ResultCount count, ActivationDelegateCollection delegates, string fieldsWithId, string tablename, string IdDbName, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, OnSqlParameterCollection sqlparams = null)
    {
      return LoadSortedPage<Author>(filter, sort, connectionString, owner, join, pageSize, pageIndex, con, trans, count, delegates, fieldsWithId, tablename, IdDbName, lang, externalDataSource ?? Dummy.ExternalDataSource, sqlparams);
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
    public static DataLayerObjectCollection<Author> LoadSortedPage(string filter, string sort, string connectionString, IUser owner, string join, int pageSize, int pageIndex, OnSqlParameterCollection sqlparams, ResultCount count = null, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null)
    {
      return LoadSortedPage<Author>(filter, sort, connectionString, owner, join, pageSize, pageIndex, null, null, count, delegates, Dummy.FIELDSWITHID,  Dummy.FullTABLENAME, Dummy.IdDbName, lang, externalDataSource ?? Dummy.ExternalDataSource, sqlparams);
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
    public static void Mix(DataLayerObjectCollection<Author> oldList, IEnumerable newList)
    {
      Mix<Author>(oldList, newList);
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
    public static Author Get(IPrimaryKey id, SqlTransaction trans, SqlConnection con, string cs, IUser owner, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, IDataLayerCache cache = null)
    {
      return Get<Author>(id, trans, con, cs, owner, delegates, lang, externalDataSource ?? Dummy.ExternalDataSource, cache);
    }

    /// <summary>
    /// Erzeugt ein neuen Objekt
    /// </summary>
    /// <param name="id">Id (PK)</param>
    /// <param name="cs">Connection string</param>
    /// <param name="owner">Besitzer (für logging)</param>
    public static Author Get(IPrimaryKey id, string cs, IUser owner)
    {
      return Get<Author>(id, null, null, cs, owner, null, Languages.None, Dummy.ExternalDataSource, null);
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
    public static Author Get(string sqlWhere, OnSqlParameterCollection onSqlparameters, SqlTransaction trans, SqlConnection con, string cs, IUser owner, ActivationDelegateCollection delegates = null, Languages lang = Languages.None, IExternalDataSource externalDataSource = null, IDataLayerCache cache = null)
    {
      return Get<Author>(sqlWhere, onSqlparameters, trans, con, cs, owner, delegates, lang, externalDataSource ?? Dummy.ExternalDataSource, cache);
    }

    /// <summary>
    /// Erzeugt ein neuen Objekt
    /// </summary>
    /// <param name="sqlWhere">SQL WHERE Klausel inkl. Schlüsselwort WHERE</param>
    /// <param name="onSqlparameters">SQL Parameter</param>
    /// <param name="cs">Connection string</param>
    /// <param name="owner">Besitzer (für logging)</param>
    public static Author Get(string sqlWhere, OnSqlParameterCollection onSqlparameters, string cs, IUser owner)
    {
      return Get<Author>(sqlWhere, onSqlparameters, null, null, cs, owner, null, Languages.None, Dummy.ExternalDataSource );
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

    private string firstname;
    public string Firstname
    {
      get
      {
        return this.firstname;
      }
      set
      {
        if ((CheckRight(nameof(Firstname)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(Firstname) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.firstname = value;
        IsChanged = true;
      }
    }

    private string lastname;
    public string Lastname
    {
      get
      {
        return this.lastname;
      }
      set
      {
        if ((CheckRight(nameof(Lastname)) & ON.Data.Common.Rights.Write) == 0)
        {
          throw new SecurityException("kein schreibender Zugriff auf " + nameof(Lastname) + " erlaubt");
        }
        value = PreventXss(value);
        // Wir entfernen hier schon die ControlCharacter, anstatt erst im ParseXsl
        value = value.RemoveControlCharacters();
        this.lastname = value;
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

    //Rollen

      //Collections
    /// <summary>
    /// 
    /// liefert die Liste der BookColl
    /// </summary>
    private DataLayerObjectCollection<Schulung.Core.Book> bookColl;

    /// <summary>
    /// zum automatischen Nachaktivieren
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "das ist immutable")]
    public static readonly ActivationDelegate bookCollDelegate = new ActivationDelegate(bookCollDelegateFunction);

    /// <summary>
    /// zum automatischen Nachaktivieren Count
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "das ist immutable")]
    public static readonly ActivationDelegate bookCollCountDelegate = new ActivationDelegate(bookCollCountDelegateFunction);

    /// <summary>
    /// liefert anzahl in der Liste der BookColl
    /// </summary>
    private int bookCollCount = -1;
    
    /// <summary>
    /// Liste der bookColl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public DataLayerObjectCollection<Schulung.Core.Book> BookColl
    {
      get
      {
       return bookColl;
      }
      set
      {
       bookColl = value;
        //IsChanged = true;
    }
    }

    
    /// <summary>
    /// Anzahl in der Liste der + bookColl
    /// </summary>
    public int BookCollCount
    {
      get
      {
        return bookCollCount;
      }
      set
      {
        bookCollCount = value;
      }
    }

    
    /// <summary>
    /// automatisches nachladen von BookColl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1072:JustifyAs", Justification = "Delegate bekommt unterschiedliche Objekte geliefert")]
    public static void bookCollDelegateFunction(ON.Data.Common.AbstractDataLayerObject data, ActivationDelegateCollection delegates)
    {
      var list = data as DatalayerCollectionWrapper;
      if (list != null)
      {
        if (list.List is DataLayerObjectCollection<Schulung.Core.Author> innerList)
        {
          MassActivateBookColl(innerList, null, delegates);
        }
      }
      else
      {
        Schulung.Core.Author obj = data as Schulung.Core.Author;
        obj?.activateBookColl(delegates);
      }
    }

    
    /// <summary>
    /// automatisches nachladen von BookColl Count
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1072:JustifyAs", Justification = "Delegate bekommt unterschiedliche Objekte geliefert")]
    public static void bookCollCountDelegateFunction(ON.Data.Common.AbstractDataLayerObject data, ActivationDelegateCollection delegates)
    {
      // ... massactivatecount
      //var list = data as DatalayerCollectionWrapper;
      //if (list != null)
      //{
      //  if (list.List is DataLayerObjectCollection<Schulung.Core.Author> innerList)
      //  {
      //    MassActivateBookColl(innerList, null, delegates);
      //  }
      //}
      //else
      //{
        Schulung.Core.Author obj = data as Schulung.Core.Author;
        obj?.activateCountBookColl();
      //}
    }

    /// <summary>
    /// (c4)
    /// nachladen der BookColl
    /// </summary>
    public void activateBookColl()
    {
      activateBookColl(EMPTY_DELEGATE_LIST);
    }


    /// <summary>
    /// (c5)
    /// nachladen der BookColl
    /// </summary>
    /// <param name="delegates">nachzuaktivieren ...</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void activateBookColl(ActivationDelegateCollection delegates)
    {
      if (this.bookColl == null)
      {
        OnSqlParameterCollection onSqlparameters = new OnSqlParameterCollection(1)
        {
          new OnSqlParameter("@id", Id.SQLObject)  //1
        };

        this.bookColl = LoadList("AuthorId=@id", null, null, onSqlparameters, null, null, ConnectionString, Owner, -1, delegates, Language, Schulung.Core.Book.Dummy.ExternalDataSource, Schulung.Core.Book.Dummy, null);
   this.bookCollCount = this.bookColl.Count;

      }
    }

    /// <summary>
    /// (c6)
    /// nachladen der BookColl
    /// </summary>
    /// <param name="target">zieltyp. Muss einen Constructor mit </param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void activateAsBookColl(Schulung.Core.Book target)
    {
      if (this.bookColl == null)
      {
        OnSqlParameterCollection onSqlparameters = new OnSqlParameterCollection(1)
        {
          new OnSqlParameter("@id", Id.SQLObject) //2
        };

        bookColl = LoadList("AuthorId=@id", null, null, onSqlparameters, null, null, ConnectionString, Owner, -1, null, Language, Schulung.Core.Book.Dummy.ExternalDataSource, target, null);

      }
    }


   /// <summary>
    /// Neue leere Collection ... es hat keinen Einfluss auf die DB!
    /// </summary>
    /// <param name="ifNotNull">Auch new, wenn nicht null? Dann könnte man besser Clear machen?</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public virtual void BookCollInit(bool ifNotNull = false)
    {
      if (this.bookColl == null || ifNotNull)
      {
        bookColl = new DataLayerObjectCollection<Schulung.Core.Book>(1);
      }
    }
    /// <summary>
    /// Konvertieren aller Elemente in der BookColl zum Type to Schulung.Core.Book haben
    /// </summary>
    /// <param name="to">zieltyp. Muss einen Constructor mit </param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void convertBookColl(Type to)
    {
      if (to == null)
      {
        throw new ArgumentNullException(nameof(to));
      }

      if (this.bookColl != null)
      {
        Type[] pars = {typeof(Schulung.Core.Book)};
        System.Reflection.ConstructorInfo c = to.GetConstructor(pars);
      DataLayerObjectCollection<Schulung.Core.Book> temp = new DataLayerObjectCollection<Schulung.Core.Book>(BookColl.Count);

        for (int i = 0; i < BookColl.Count; i++)
        {
          ON.Data.Common.AbstractDataLayerObject a = (ON.Data.Common.AbstractDataLayerObject)BookColl[i];
          object[] o = new object[1];
          o[0] = a;
          Schulung.Core.Book no = (Schulung.Core.Book)c.Invoke(o);
          temp.Add(no);
        }

        BookColl = temp;
      }
    }
    /// <summary>
    /// (c7)
    /// nachladen der BookColl
    /// Bemerkung: Nur mit order (ohne WHERE) ist nicht möglich, da dies 2 Methoden mit der
    /// selben Signatur ergeben würde. In diesem Fall ist bitte "1=1", order zu nutzen
    /// </summary>
    /// <param name="target">zieltyp. Muss einen Constructor mit </param>
    /// <param name="where">Where Klausel ohne Schlüsselwort WHERE</param>
    public void activateAsBookColl(string where, Schulung.Core.Book target)
    {
      activateAsBookColl(where, null, EMPTY_DELEGATE_LIST, target);
    }

    

    /// <summary>
    /// (c8)
    /// nachladen der BookColl
    /// mit where und order
    /// </summary>
    /// <param name="where">Where Klausel ohne. Schlüsselwort WHERE</param>
    /// <param name="order">Order Klausel ohne Schlüsselwort ORDER BY</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    /// <param name="target">zeiltyp</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void activateAsBookColl(string where, string order, ActivationDelegateCollection delegates, Schulung.Core.Book target)
    {
      if (string.IsNullOrEmpty(where))
      {
        where = "1=1";
      }
      if (this.bookColl == null)
      {
        OnSqlParameterCollection onSqlparameters = new OnSqlParameterCollection(1)
        {
          new OnSqlParameter("@fid", Id.SQLObject)
        };

        bookColl = LoadList(where + " AND [Books].AuthorId=@fid", null, order, onSqlparameters, null, null, ConnectionString, Owner, -1, delegates, Language,  Schulung.Core.Book.Dummy.ExternalDataSource, target, null);

      }
    }


    /// <summary>
    /// (c9)
    /// Nachladen der BookColl
    /// </summary>
    /// <param name="trans">aktuelle Transaction</param>
    /// <param name="con">aktuelle Connection</param>
    /// <param name="where">Where Klausel ohne Schlüsselwort WHERE</param>
    /// <param name="order">Order Klausel ohne Schlüsselwort ORDER BY</param>
    /// <param name="sqlParam">SQL Parameter</param>
    /// <param name="delegates">nachzuaktivieren ...</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void activateBookColl(string where, string order, SqlTransaction trans, SqlConnection con, ActivationDelegateCollection delegates, OnSqlParameterCollection sqlParam = null)
    {
      if (string.IsNullOrEmpty(where))
      {
        where = "1=1";
      }      
      if (this.bookColl == null)
      {
        if (sqlParam == null)
        {
          sqlParam =  new OnSqlParameterCollection(1);
        }
        sqlParam.Add(new OnSqlParameter("@fid", Id.SQLObject));

        bookColl = LoadList(where + " AND [Books].AuthorId=@fid", null, order, sqlParam, trans, con, ConnectionString, Owner, -1, delegates, Language,  Schulung.Core.Book.Dummy.ExternalDataSource, Schulung.Core.Book.Dummy, null);

      }
    }


    /// <summary>
    /// nachladen Anzahl in der BookColl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1076:AvoidNullEmptySQLParameterCollection", Justification = "where ist auch leer")]
    public void activateCountBookColl()
    {
      activateCountBookColl(String.Empty, null, null, null);
    }

    /// <summary>
    /// nachladen Anzahl in der BookColl
    /// </summary>
    public void activateCountBookColl(string where, OnSqlParameterCollection onSqlparameters)
    {
        activateCountBookColl(where, onSqlparameters, null, null);
      }

    /// <summary>
    /// Nachladen Anzahl in der BookColl
    /// </summary>
    /// <param name="where">where Klausel ohne Schlüsselwort WHERE</param>
    /// <param name="onSqlparameters"></param>
    /// <param name="trans">aktuelle Transaction</param>
    /// <param name="con">aktuelle Connection</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1064:CheckIfBoxingAvoidable", Justification = ".NET"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "false positiv"), System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1013:privateMemberpublicProperty", Justification = "wollen kein changed  bekommen")]
    public void activateCountBookColl(string where, OnSqlParameterCollection onSqlparameters, SqlTransaction trans, SqlConnection con)
    {
      if (string.IsNullOrEmpty(where))
      {
        where = "WHERE 1=1";
      }
      if (onSqlparameters == null)
      {
        onSqlparameters = new OnSqlParameterCollection(1);
      }
      onSqlparameters.Add(new OnSqlParameter("@fid", Id.SQLObject));
      
      where += " AND [Books].AuthorId=@fid";
      if (Schulung.Core.Book.Dummy.ExternalDataSource == null)
      {
        bool opened = false;
        SqlConnection myCon = null;
        try
        {
          if (con == null || !CommonUtilities.IsEqualConnection(con.ConnectionString, ConnectionString)) 
          {
            myCon = new SqlConnection(ConnectionString);
            con = myCon;
            trans = null; //so ganz richitig ist das nicht ... 
          }
          string sql = "SELECT Count(*) FROM " + Schulung.Core.Book.Dummy.FullTABLENAME.Replace("@language", ((int)Language).ToString()) + " " + where;

      using (SqlCommand cmd = new SqlCommand(sql, con))
      {
        if (con.State != System.Data.ConnectionState.Open)
        {
          con.Open();
          opened = true;
        }
        cmd.CommandType = CommandType.Text;
        if (onSqlparameters != null)
        {
          foreach (string SqlKey in onSqlparameters.Keys)
          {
            cmd.Parameters.AddWithValue(SqlKey, onSqlparameters[SqlKey].Val);
          }
        }
        if (trans != null) //obwohl uns transaction hier nur wenig interessiert
        {
          cmd.Transaction = trans;
        }
        this.bookCollCount = (int)cmd.ExecuteScalar();
      }
    }
        finally
        {
          if (myCon != null)
          {
            myCon.Dispose();
          }
          else if (opened)
          {
            if (con != null)
            {
              con.Close();
            }
          }
        }
      }
      else
      {
        this.bookCollCount = Schulung.Core.Book.Dummy.ExternalDataSource.GetCount(where, onSqlparameters);
      }
    }
    /// <summary>
    /// gleichzeitiges Nachladen aller BookColl Collections
    /// </summary>
    /// <param name="list"></param>
    /// <param name="loader">wenn null, dann der standard loadlist</param>
    /// <param name="delegates"></param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1063:OnlyPrimitivKeysInHashes", Justification = "IPrimaryKey ist ok"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1049: AvoidStringBuilderToString")]
    public static DataLayerObjectCollection<Book> MassActivateBookColl(DataLayerObjectCollection<Author> list, Func<string, OnSqlParameterCollection, string, IUser, ActivationDelegateCollection, Languages, DataLayerObjectCollection<Book>> loader = null, ActivationDelegateCollection delegates = null)
    { 
      if (list == null || list.Count == 0)
      {
        return new DataLayerObjectCollection<Book>(0);
      }
      if (loader == null) //default
      {
        loader = Schulung.Core.Book.LoadList;
      }

      StringBuilder ids = new StringBuilder(list.Count * 7);
      var lookUpList = new Dictionary<IPrimaryKey, Author>(list.Count * 4);
      foreach(var m in list)
      {
        if (m.BookColl == null && !m.Id.IsNew)
        {
          ids.Append(m.Id.ToString()).Append(',');
          lookUpList[m.Id] = m;
          m.bookColl = new DataLayerObjectCollection<Book>(0);
        }
      }

      if (ids.Length == 0)
      {
        return new DataLayerObjectCollection<Book>(0);
      }

      OnSqlParameterCollection param = new OnSqlParameterCollection(1)
      {
        { nameof(ids), ids.ToString().Trim(ON.Consts.SPLITTER_COMMA) }
      };
      var sortedList = loader("where AuthorId in (select * from " + ON.Configuration.ConfigurationManager.PraefixForGlobalFunctions +  "fnsplitterInt(@ids))", param, list[0].ConnectionString, list[0].Owner, delegates, list[0].Language);


      foreach (var c in sortedList)
      {
        var myList = lookUpList[c.AuthorId];
        if (!myList.BookColl.Any(e => (IntPrimaryKey)c.Id == (IntPrimaryKey)e.Id)) 
        {
          myList.BookColl.Add(c);
        }
      }

      return sortedList;
    }
    /// <summary>
    /// neue Liste anlegen und it count neuen Elementen füllen
    /// </summary>
    public void createBookColl(int count)
    {
      if (BookColl == null)
      {
        bookColl = new DataLayerObjectCollection<Book>(count);

        for (int i = 0; i < count; i++)
        {
          var temp = Schulung.Core.Book.Get(Dummy.Id.Empty, ConnectionString, Owner);
          BookColl.Add(temp);
        }
      }
    }


      //SQL
      [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1091:UseNameOf")]
    private const string tablename = "Authors";

    private const string fulltablename = @"[dbo].[Authors]"; //HINWEIS: Wenn Multilanguagefelder oder AdditionalFields in anderer DB liegen, dann läuft das nicht!
    private const string sqlschema = "dbo";

    private const string fieldsWId = @"[Authors].[Firstname],[Authors].[Lastname],[Authors].[ChangedAt],[Authors].[ChangedBy],[Authors].[CreatedAt],[Authors].[CreatedBy],[Authors].[Id]";
    private const string valuesWId = @"@Firstname,@Lastname,@ChangedAt,@ChangedBy,@CreatedAt,@CreatedBy,@Id";
    private const string fieldsWOId = @"[Authors].[Firstname],[Authors].[Lastname],[Authors].[ChangedAt],[Authors].[ChangedBy],[Authors].[CreatedAt],[Authors].[CreatedBy]";
    private const string valuesWOId = @"@Firstname,@Lastname,@ChangedAt,@ChangedBy,@CreatedAt,@CreatedBy";

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

Firstname = Firstname;
Lastname = Lastname;
ChangedAt = ChangedAt;
ChangedBy = ChangedBy;
CreatedAt = CreatedAt;
CreatedBy = CreatedBy;

#pragma warning restore CA2245 // Do not assign a property to itself.
}

    /// <summary>
    /// soll vor dem Speichern alles nochmal getestet werden?
    /// </summary>
    public override bool CheckOnSave => false;



    /// <summary>
    /// (4)
    /// Erzeugt ein neues Author Objekt aus vorhandenem
    /// indem alle Felder kopiert werden (vor allem für BL von interesse)
    /// Die Umwandeloperation gibt es nicht mit Delegates ... macht keinen Sinn
    /// </summary>
    /// <param name="old">das Quellobject</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502: AvoidExcessiveComplexity")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1053:DontUseDataLayerConstructors"),System.Diagnostics.CodeAnalysis.SuppressMessage("ONCodeAnalyse", "ON1057:NullTestDL"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506: AvoidExcessiveClassCoupling")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505: AvoidUnmaintainableCode")]
    public Author(Author old): base(old)
    {
      if (old == null)
      {
        throw new ArgumentNullException(nameof(old));
      }

      ConnectionString = old.ConnectionString;
      Owner = old.Owner;



      //alle felder kopieren

      firstname = old.firstname;
      lastname = old.lastname;
      changedAt = old.changedAt;
      changedBy = old.changedBy;
      createdAt = old.createdAt;
      createdBy = old.createdBy;
      id = old.id;
      BookCollCount = old.BookCollCount;
      bookColl = old.bookColl;
init();

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

      this.firstname = CommonUtilities.GetValue(this.firstname, row,0);
      this.lastname = CommonUtilities.GetValue(this.lastname, row,1);
      this.changedAt = CommonUtilities.GetValue(this.changedAt, row,2);
      this.changedBy = CommonUtilities.GetValue(this.changedBy, row,3);
      this.createdAt = CommonUtilities.GetValue(this.createdAt, row,4);
      this.createdBy = CommonUtilities.GetValue(this.createdBy, row,5);
			this.id = (IntPrimaryKey)CommonUtilities.GetValue(this.id, row,6);


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
        return 3500;
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


        if((CheckRight(nameof(Firstname)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Firstname != null)
          {
            sb.AppendXmlNode(nameof(firstname), ON.Text.TextUtilities.GetDefaultFormated(Firstname,Language).ReplaceEntities());
          }
        }

        if((CheckRight(nameof(Lastname)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Lastname != null)
          {
            sb.AppendXmlNode(nameof(lastname), ON.Text.TextUtilities.GetDefaultFormated(Lastname,Language).ReplaceEntities());
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

        if((CheckRight(nameof(Id)) & ON.Data.Common.Rights.Read) != 0)
        {

          sb.AppendXmlNode(nameof(id), Id.ToString().ReplaceEntities());



          sb.AppendXmlNode(nameof(id) + "4HTML", Id.HtmlName);


        }
      if(includeSubobjects)
      {

        if((CheckRight(nameof(BookColl)) & ON.Data.Common.Rights.Read) != 0)
        {
        if (bookColl != null)
        {
          sb.Append("<bookColl>");
          foreach(var temp in bookColl)
          {
            sb.AppendXmlNode(nameof(bookColl) + "Item", (sbInner) => temp.GetXml(true, false, sbInner));
          }
          sb.Append("</bookColl>");
        }


        sb.AppendXmlNode(nameof(bookCollCount), BookCollCount.ToString());
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
          
        sql += "Firstname=@firstname,";
        sql += "Lastname=@lastname,";
        sql += "ChangedAt=@changedAt,";
        sql += "ChangedBy=@changedBy,";
        sql += "CreatedAt=@createdAt,";
        sql += "CreatedBy=@createdBy,";
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

      SaveList(bookColl, con, trans);

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

      if (bookColl != null)
      {
        foreach (var temp in bookColl)
        {
          if ((IntPrimaryKey)temp.AuthorId  != (IntPrimaryKey)Id)
          {
            temp.AuthorId = (IntPrimaryKey)Id;
          }
        }
      }

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


       cmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.firstname) });
       cmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.lastname) });
       cmd.Parameters.Add(new SqlParameter("@changedAt", SqlDbType.DateTime2) { Value = CommonUtilities.SetValue(this.changedAt) });
       cmd.Parameters.Add(new SqlParameter("@changedBy", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.changedBy) });
       cmd.Parameters.Add(new SqlParameter("@createdAt", SqlDbType.DateTime2) { Value = CommonUtilities.SetValue(this.createdAt) });
       cmd.Parameters.Add(new SqlParameter("@createdBy", SqlDbType.NVarChar) { Value = CommonUtilities.SetValue(this.createdBy) });
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
        dt.Columns.Add(new DataColumn("Firstname", typeof(string)));
      }
      row["Firstname"] = CommonUtilities.SetValue(this.firstname);
	
      if (newTable)
      {
        dt.Columns.Add(new DataColumn("Lastname", typeof(string)));
      }
      row["Lastname"] = CommonUtilities.SetValue(this.lastname);
	
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
    
BookColl = null;

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
          var count = cache.getResultCount<Author>(Dummy, sqlWhere, onSqlparameters);

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
          cache.putResultCount<Author>(Dummy, sqlWhere, onSqlparameters, rc);
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

      info.AddValue(nameof(firstname), this.firstname);
      info.AddValue(nameof(lastname), this.lastname);
      info.AddValue(nameof(changedAt), this.changedAt);
      info.AddValue(nameof(changedBy), this.changedBy);
      info.AddValue(nameof(createdAt), this.createdAt);
      info.AddValue(nameof(createdBy), this.createdBy);
      info.AddValue(nameof(bookColl), this.bookColl);
      info.AddValue(nameof(bookCollCount), bookCollCount);
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
    protected Author(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
      if (info == null)
      {
        throw new ArgumentNullException(nameof(info));
      }


      this.firstname = info.GetString(nameof(firstname));
      this.lastname = info.GetString(nameof(lastname));
      this.changedAt = info.GetDateTime(nameof(changedAt));
      this.changedBy = info.GetString(nameof(changedBy));
      this.createdAt = info.GetDateTime(nameof(createdAt));
      this.createdBy = info.GetString(nameof(createdBy));
      bookColl = (DataLayerObjectCollection<Book>) info.GetValue(nameof(bookColl), typeof(DataLayerObjectCollection<Schulung.Core.Book>));
        bookCollCount = info.GetInt32(nameof(bookCollCount));
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
              Author field = (Author)list[i];
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
        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Firstname", "Firstname"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Lastname", "Lastname"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ChangedAt", "ChangedAt"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("ChangedBy", "ChangedBy"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CreatedAt", "CreatedAt"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CreatedBy", "CreatedBy"));        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Id", "Id"));
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
      System.Xml.XmlNodeList nodelist;
      node = doc.SelectSingleNode("*/firstname");
      if (node != null)
      {
        this.firstname = node.InnerText;
      }
      node = doc.SelectSingleNode("*/lastname");
      if (node != null)
      {
        this.lastname = node.InnerText;
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
      node = doc.SelectSingleNode("*/bookCollCount");
        bookCollCount =  Convert.ToInt32(node.InnerText);
      nodelist = doc.SelectNodes("*/bookColl/bookCollItem");
      if (nodelist != null)
      {
        DataLayerObjectCollection<Book> al = new DataLayerObjectCollection<Book>(nodelist.Count);
        for (int i = 0; i < nodelist.Count; i++)
        {
          string xmlgeneriert = nodelist[i].OuterXml;
          System.Xml.XmlReader xmlreader = null;
          System.IO.StringReader strreader = null;
            try
            {
    strreader = new System.IO.StringReader(xmlgeneriert);
              xmlreader = ON.Xml.XMLUtilities.CreateXmlReader(strreader);
    strreader = null;
              Schulung.Core.Book obj = Schulung.Core.Book.Get(Schulung.Core.Book.Dummy.Id, ConnectionString, Owner);//zzz
              obj.ReadXml(xmlreader);
              al.Add(obj);
            }
            finally
            {
              xmlreader?.Close();
              strreader?.Dispose();
          }
        }
        BookColl = al;
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
      if (propertyName.Equals(nameof(firstname), StringComparison.OrdinalIgnoreCase))
      {
        return "[Firstname]";
      }
      else if (propertyName.Equals("Authors.firstname", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[Firstname]";
      }
      else if (propertyName.Equals(nameof(lastname), StringComparison.OrdinalIgnoreCase))
      {
        return "[Lastname]";
      }
      else if (propertyName.Equals("Authors.lastname", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[Lastname]";
      }
      else if (propertyName.Equals(nameof(changedAt), StringComparison.OrdinalIgnoreCase))
      {
        return "[ChangedAt]";
      }
      else if (propertyName.Equals("Authors.changedAt", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[ChangedAt]";
      }
      else if (propertyName.Equals(nameof(changedBy), StringComparison.OrdinalIgnoreCase))
      {
        return "[ChangedBy]";
      }
      else if (propertyName.Equals("Authors.changedBy", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[ChangedBy]";
      }
      else if (propertyName.Equals(nameof(createdAt), StringComparison.OrdinalIgnoreCase))
      {
        return "[CreatedAt]";
      }
      else if (propertyName.Equals("Authors.createdAt", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[CreatedAt]";
      }
      else if (propertyName.Equals(nameof(createdBy), StringComparison.OrdinalIgnoreCase))
      {
        return "[CreatedBy]";
      }
      else if (propertyName.Equals("Authors.createdBy", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[CreatedBy]";
      }
      else if (propertyName.Equals(nameof(id), StringComparison.OrdinalIgnoreCase))
      {
        return "[Id]";
      }
      else if (propertyName.Equals("Authors.id", StringComparison.OrdinalIgnoreCase))
      {
        return "[Authors].[Id]";
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
      string sqlWhere = getPKWhere<Author>(Id, param, Language);
      return Get<Author>(sqlWhere, param, null, null, ConnectionString, Owner, null, Language, null, null,false);
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
      StringBuilder sb = new StringBuilder("<data>", 3500);
      if (action != Actions.Update) //full log
      {
        GetXml(false, false, sb);
      }
      else //diff xml
      {
        //alte Daten beschaffen

        Author oldVersion = ON.Data.Common.AbstractDataLayerObject.Get<Author>(Id, trans, con, ConnectionString, Owner, null, Language, ExternalDataSource, null);
        GetDiffXml(sb, oldVersion);

      }


      sb.Append("</data>");
      LogbuchEntry entry = new LogbuchEntry(Owner.LoggingIdentifier, null, "none", "Schulung.Core.Author", DateTime.UtcNow, sb.ToString(), Id.ToString(), action);


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
    public void GetDiffXml(StringBuilder sb, Author oldVersion, bool removeHtml = false, bool includeRolesAndCollections = false)
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
    public void GetDiffXml(StringBuilder sb, Author oldVersion, bool removeHtml, bool includeRolesAndCollections, SqlTransaction trans, SqlConnection con)
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
         GetDiffXml(sb, (Author)oldVersion, removeHtml, includeRolesAndCollections, trans, con);
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
        GetDiffXml(sb,  (Author) oldVersion, removeHtml, includeRoles, includeCollections, trans, con);
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
    public void GetDiffXml(StringBuilder sb, Author oldVersion, bool removeHtml, bool includeRoles, bool includeCollections, SqlTransaction trans, SqlConnection con)
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

      if (oldVersion.Firstname != this.Firstname)
      {
        sb.Append(@"<kommentar type=""string"" field=""Firstname"" label=""""><old>");

        if((CheckRight(nameof(Firstname)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.Firstname != null)
          {
            sb.AppendXmlNode(nameof(firstname), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.Firstname,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(Firstname)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Firstname != null)
          {
            sb.AppendXmlNode(nameof(firstname), ON.Text.TextUtilities.GetDefaultFormated(Firstname,Language).ReplaceEntities());
          }
        }
        sb.Append("</new></kommentar>");
      }

      if (oldVersion.Lastname != this.Lastname)
      {
        sb.Append(@"<kommentar type=""string"" field=""Lastname"" label=""""><old>");

        if((CheckRight(nameof(Lastname)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (oldVersion.Lastname != null)
          {
            sb.AppendXmlNode(nameof(lastname), ON.Text.TextUtilities.GetDefaultFormated(oldVersion.Lastname,Language).ReplaceEntities());
          }
        }
        sb.Append("</old><new>");

        if((CheckRight(nameof(Lastname)) & ON.Data.Common.Rights.Read) != 0)
        {
          if (Lastname != null)
          {
            sb.AppendXmlNode(nameof(lastname), ON.Text.TextUtilities.GetDefaultFormated(Lastname,Language).ReplaceEntities());
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


      }
      if(includeCollections)
      {
if (BookColl != null)
 {
   sb.Append(@"<collection field=""Books"" label="""">");


   oldVersion.activateBookColl(null, null, trans, con, null);

   foreach (var b2r in BookColl)
   {

     if (b2r.DeleteMark)
     {
         sb.AppendXmlNode("removed", b2r.FachlicherPk.ToString().ReplaceEntities());
     }
     else
     {
       
       var oldb2r = oldVersion.BookColl.FirstOrDefault(item => item.Id.Equals(b2r.Id));

       if (oldb2r == null)
       {
 
           sb.AppendXmlNode("added", b2r.FachlicherPk.ToString().ReplaceEntities());
       }
       else
       {
        sb.Append(@"<diffXML for=""" ).Append( b2r.FachlicherPk.ToString().ReplaceEntities() ).Append( @""">");
        b2r.GetDiffXml(sb, oldb2r, removeHtml, true, false, trans, con);
        sb.Append("</diffXML>");
       }
     }
   }

   sb.Append(@"</collection>");
 }
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
