using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Polovnjaci_V1._0
{

	public enum ObjectState
	{
		isLoaded,
		isEdited,
		isNew,
		isDeleted,
		None
	}

	#region CLASS: _DataObject
	//================================================================================
	/// <summary>
	/// Abstraktni objekat koji implementacijom predstavlja red u nekoj od tabela u bazi. 
	/// </summary>
    public abstract class _DataObject
	{

		#region members & propertys
		//================================================================================

		/// <summary>
		/// Stanje u kojem se nalazi objekat
		/// </summary>
		protected ObjectState state = ObjectState.None;

		/// <summary>
		/// Ime tabele
		/// </summary>
		protected string tableName = "";

		/// <summary>
		/// Ime baze u kojoj se nalazi tabela
		/// </summary>
		protected string dbName = "mydb";

		/// <summary>
		/// Vraca naziv tabele u kombinaciji sa bazom db.table
		/// </summary>
		/// <returns>string db.table</returns>
		public string GetDBTable ( )
		{
			return dbName + "." + tableName;
		}

		/// <summary>
		/// Vraca ime tabele, readonly.
		/// </summary>
		public string TableName
		{
			get { return this.tableName; }
		}

		//================================================================================
		#endregion

		#region Konstruktor i ostale funkcije
		//================================================================================

		/// <summary>
		/// konstruktor
		/// </summary>
		/// <param name="tName">Ime tabele, mora biti identicno onom u bazi</param>
		public _DataObject ( String tName )
		{
			tableName = tName;
		}

		/// <summary>
		/// Oznacava da je element nov i da nema postavljene vrednosti atributa
		/// </summary>
		public void AddNew ( )
		{
			Reset( );
			state = ObjectState.isNew;
		}

		/// <summary>
		/// Oznava da je element potrebno obrisati pri narednom pozivu Save
		/// </summary>
		public void MarkForDelete ( )
		{
			state = ObjectState.isDeleted;
		}

		/// <summary>
		/// Oznacava da je element editovan. Moze da sluzi i za dodavanje na drugaciji nacin
		/// </summary>
		public void MarkAsEdited ( )
		{
			state = ObjectState.isEdited;
		}

		//public List<string> ColumnList ( _Connect conn )
		//{
		//    return conn.GetColumnList( tableName );
		//}

		//================================================================================
		#endregion

		#region INTERFACE
		//================================================================================

		/// <summary>
		/// Resetovanje parametara klase
		/// </summary>
		public abstract void Reset ( );

		/// <summary>
		/// Snimanje promena. Paziti da se implementira isEdited u okviru propery-ja klase
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		public abstract void Save ( _Connect conn );

		/// <summary>
		/// Ucitavanje jednog sloga iz baze u objekat koji je pozvao f-ju
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <param name="id">ID elementa koji se ucitava</param>
        public abstract void Load (_Connect conn, int id );

		/// <summary>
		/// Ucitava sve elemente tabele koju predstavlja klasa
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <returns>Lista elemenata gde svaki element istanca klase koja predstavlja red u bazi</returns>
		public abstract List<object> LoadAll ( _Connect conn );

		//================================================================================
		#endregion

    }
	//================================================================================
	#endregion


	#region CLASS: _Connect
	//================================================================================

	/// <summary>
	/// Apstraktna klasa koja predstavlja konekciju sa bazom
	/// </summary>
	public abstract class _Connect : IDisposable
	{
		#region members
		//================================================================================

		/// <summary>
		/// konekcioni string
		/// </summary>
		protected string connectionString = "";

		//================================================================================
		#endregion

		#region INTERFACE FUNCTIONS
		//================================================================================

		/// <summary>
		/// Otvara konekciju
		/// </summary>
		public abstract void Open ( );

		/// <summary>
		/// Zatvara konekciju ali je ne brise. Moze kasnije opet da se otvori
		/// </summary>
		public abstract void Close ( );

		/// <summary>
		/// Zatvara i brise konekciju
		/// </summary>
		public abstract void Dispose ( );

		/// <summary>
		/// Loaduje sve podatke iz navedene tabele
		/// </summary>
		/// <param name="tableName">Tabela koju loaduje</param>
		/// <param name="orderByColumn">Indeks kolone po kojoj zelimo sortiranje. Za -1 i indeks veci od dozvoljenog
		/// vraca tabelu kakva je u bazi.</param>
		/// <returns>Rezultat je lista koja sadrzi liste sa odgovarajucim brojem elemenata u zavisnosti od tabele</returns>
		public abstract List<List<object>> LoadAll ( string tableName, int orderByColumn );

		/// <summary>
		/// Loaduje jednu vrstu iz prosledjene tabele sa zadatim indeksom
		/// </summary>
		/// <param name="tableName">Tabela sa podacima</param>
		/// <param name="id">id elementa. Ako ne nadje, vraca praznu listu. Smatra se da je uvek prva kolona u 
		/// tabeli sadrzi id</param>
		/// <returns>Vraca listu sa onliko elemenata, koliko ima kolona</returns>
		public abstract List<object> Load ( string tableName, int id );

		/// <summary>
		/// Dodaje element u tabelu
		/// </summary>
		/// <param name="tableName">Tabela u koju se dodaje element</param>
		/// <param name="values">Vrednosti za sve elemente jedog reda u tabeli. Prvi je uvek ID i ukoliko je manji od 1,
		/// program ce sam dodeliti indeks</param>
		/// <returns>Novidodeljeni ili stari ID elementa koji je dodavan u tabelu</returns>
		public abstract int Insert(string tableName, List<string> values);

		/// <summary>
		/// Dodaje element u tabelu
		/// </summary>
		/// <param name="tableName">Tabela u koju se dodaje element</param>
		/// <param name="id">ID elementa koji se edituje</param>
		/// <param name="values">Vrednosti za sve elemente jedog reda u tabeli. Prvi je uvek ID i ukoliko je manji od 1,
		/// program ce sam dodeliti indeks</param>
		public abstract void Edit ( string tableName, int id, List<string> values );

		/// <summary>
		/// Brise element iz tabele sa zadatim id
		/// </summary>
		/// <param name="tableName">Tabela u kojoj se vrsi brisanje</param>
		/// <param name="id">id elementa koji se brise</param>
		public abstract void Delete(string tableName, int id);

		//public abstract List<string> GetColumnList ( string tableName );

		//================================================================================
		#endregion
	}

	//================================================================================
	#endregion



}