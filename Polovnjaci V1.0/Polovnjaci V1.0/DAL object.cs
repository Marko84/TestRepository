using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using MySql.Data.Types;

namespace Polovnjaci_V1._0
{
	#region CLASS: Kategorije
	//================================================================================

	/// <summary>
	/// Red u tabeli Kategorije
	/// </summary>
	public class Kategorije : _DataObject
	{
		#region PROPERTY
		//================================================================================

		private int id_kategorije = -1;
		/// <summary>
		/// Moguce je postaviti vrednost samo kada je objekat oblezen kao nov
		/// </summary>
		public int pID_Kategorije
		{
			get { return this.id_kategorije; }
			set {
				if (state == ObjectState.isNew || state == ObjectState.None)
					this.id_kategorije = value;
				else
					throw new Exception( "Pokusaj menjanja ID-a elementa (K Klasa) kada isti nije obelezen kao nov" );
			}
		}

		private string naziv_kategorije = "";
		public string pNaziv_Kategorije
		{
			get { return this.naziv_kategorije; }
			set
			{
				if(this.naziv_kategorije != value && state != ObjectState.isDeleted)
				{
					this.naziv_kategorije = value;
					if(state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		//================================================================================
		#endregion

		#region KONSTRUKTORI
		//================================================================================

		public Kategorije ( ) : base( "kategorije" ) { }

		public Kategorije (int id, string naziv ) : base( "kategorije" ) {
			id_kategorije = id;
			naziv_kategorije = naziv;
			state = ObjectState.isLoaded;
		}

		//================================================================================
		#endregion

		#region OVERRIDE
		//================================================================================

		/// <summary>
		/// Loaduje sve podakte iz tabele kategorije
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <returns>Vraca podatke u obliku liste cij su elementi objekti Kategorije</returns>
		public override List<object> LoadAll (_Connect conn )
		{
			List<object> ret = new List<object>( );

			List<List<object>> lista = conn.LoadAll( this.GetDBTable( ), 1 );

			foreach (List<object> l in lista)
				ret.Add( new Kategorije( (int) l[0], (string) l[1] ) );

			return ret;
		}

		/// <summary>
		/// Loaduje jedan red direktno u ovaj primerak klase
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <param name="id">ID elementa koji se loaduje</param>
		public override void Load (_Connect conn, int id )
		{
			List<object> lista = conn.Load( tableName, id );

			this.id_kategorije = (int)lista[0];
			this.naziv_kategorije = (string)lista[1];

			state = ObjectState.isLoaded;
		}

		/// <summary>
		/// Resetuje propery elemente klase
		/// </summary>
		public override void Reset ( )
		{
			this.id_kategorije = -1;
			this.naziv_kategorije = "";
			this.state = ObjectState.None;
		}


		/// <summary>
		/// Vrsi snimanje ili brisanje elementa u zavisnosti koja je funkcija pre toga pozvana
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		public override void Save ( _Connect conn )
		{
			switch (state) {
				case ObjectState.isNew:
					state = ObjectState.isLoaded;

					List<string> listaAdd = new List<string>( );
					listaAdd.Add( id_kategorije.ToString( ) );
					listaAdd.Add( naziv_kategorije );

					id_kategorije = conn.Insert( tableName, listaAdd );
					break;
				case ObjectState.isDeleted:
					state = ObjectState.None;

					conn.Delete( tableName, id_kategorije );

					Reset( );
					break;
				case ObjectState.isEdited:
					state = ObjectState.None;

					//conn.Delete( tableName, id_kategorije );

					List<string> listaEdit = new List<string>( );
					//listaEdit.Add( id_kategorije.ToString( ) );
					listaEdit.Add( naziv_kategorije );

					//conn.Insert( tableName, listaEdit );
					conn.Edit( tableName, id_kategorije, listaEdit );
					break;
			}
		}


		public override string ToString ( )
		{
			return "id_kategorije: " + id_kategorije.ToString( ) + ", naziv_kategorije: " + naziv_kategorije;
		}

		//================================================================================
		#endregion
	}

	//================================================================================
	#endregion

	#region CLASS: Trgovac
	//================================================================================

	/// <summary>
	/// Red u tabeli Trgovac
	/// </summary>
	public class Trgovac : _DataObject
	{
		#region PROPERTY
		//================================================================================

		private int id_trgovac = -1;
		public int pID_Trgovac
		{
			get { return id_trgovac; }
			set {
				if (state == ObjectState.isNew || state == ObjectState.None)
					this.id_trgovac = value;
				else
					throw new Exception( "Pokusaj menjanja ID-a (T klasa) elementa kada isti nije obelezen kao nov" );
			}
		}

		private string ime = "";
		public string pIme
		{
			get { return ime; }
			set {
				if (this.ime != value && state != ObjectState.isDeleted) {
					this.ime = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		//================================================================================
		#endregion

		#region KONSTRUKTORI
		//================================================================================

		public Trgovac ( ) : base( "trgovac" ) { }

		public Trgovac ( int id, string ime )
			: base( "trgovac" )
		{
			id_trgovac = id;
			this.ime = ime;
			state = ObjectState.isLoaded;
		}

		//================================================================================
		#endregion

		#region OVERRIDE
		//================================================================================

		/// <summary>
		/// Loaduje sve podakte iz tabele trgovac
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <returns>Vraca podatke u obliku liste cij su elementi objekti Trgovac</returns>
		public override List<object> LoadAll ( _Connect conn )
		{
			List<object> ret = new List<object>( );

			List<List<object>> lista = conn.LoadAll( tableName, 1 );

			foreach (List<object> l in lista)
				ret.Add( new Trgovac( (int) l[0], (string) l[1] ) );

			return ret;
		}

		/// <summary>
		/// Loaduje jedan red tabele trgovac direktno u ovaj primerak klase
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <param name="id">ID elementa koji se loaduje</param>
		public override void Load ( _Connect conn, int id )
		{
			List<object> lista = conn.Load( tableName, id );

			this.id_trgovac = (int) lista[0];
			this.ime = (string) lista[1];

			state = ObjectState.isLoaded;
		}

		/// <summary>
		/// Resetuje propery elemente klase
		/// </summary>
		public override void Reset ( )
		{
			this.id_trgovac = -1;
			this.ime = "";
			this.state = ObjectState.None;
		}



		/// <summary>
		/// Vrsi snimanje ili brisanje elementa u zavisnosti koja je funkcija pre toga pozvana
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		public override void Save ( _Connect conn )
		{
			switch (state) {
				case ObjectState.isNew:
					state = ObjectState.isLoaded;

					List<string> listaAdd = new List<string>( );
					listaAdd.Add( id_trgovac.ToString( ) );
					listaAdd.Add( ime );

					id_trgovac = conn.Insert( tableName, listaAdd );
					break;
				case ObjectState.isDeleted:
					state = ObjectState.None;

					conn.Delete( tableName, id_trgovac );

					Reset( );
					break;
				case ObjectState.isEdited:
					state = ObjectState.None;

					conn.Delete( tableName, id_trgovac );

					List<string> listaEdit = new List<string>( );
					listaEdit.Add( id_trgovac.ToString( ) );
					listaEdit.Add( ime );

					conn.Insert( tableName, listaEdit );
					break;
			}
		}

		public override string ToString ( )
		{
			return "id_trgovac: " + id_trgovac.ToString( ) + ", ime: " + ime;
		}

		//================================================================================
		#endregion
	}

	//================================================================================
	#endregion

	#region CLASS: PolovneKomponente
	//================================================================================

	/// <summary>
	/// Predstavlja red u tabeli polovne_komponente
	/// </summary>
	public class PolovneKomponente : _DataObject
	{
		//TO DO: dodatne informacije o trgovcima i kategorijama i njihov load u okviru funkcije LoadAditionalData

		#region PROPERTY
		//================================================================================

		private int id_polovne_komponente = -1;
		public int pID_Polovne_Komponente
		{
			get { return id_polovne_komponente; }
			set
			{
				if (state == ObjectState.isNew || state == ObjectState.None)
					this.id_polovne_komponente = value;
				else
					throw new Exception( "Pokusaj menjanja ID-a elementa (PK klasa) kada isti nije obelezen kao nov" );
			}
		}

		private string naziv_komponente = "";
		public string pNaziv_Komponente
		{
			get { return naziv_komponente; }
			set
			{
				if (this.naziv_komponente != value && state != ObjectState.isDeleted) {
					this.naziv_komponente = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private int id_kategorije = 1;
		public int pID_Kategorije
		{
			get { return id_kategorije; }
			set
			{
				if (this.id_kategorije != value && state != ObjectState.isDeleted) {
					this.id_kategorije = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private Kategorije kategorija = null;
		public Kategorije pKategorija
		{
			get { return kategorija; }
			set
			{
				if (value.pID_Kategorije != id_kategorije && state != ObjectState.isDeleted) {
					id_kategorije = value.pID_Kategorije;
					kategorija = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}


		private MyDate datum_kupovine = new MyDate( );
		public MyDate pDatum_Kupovine
		{
			get { return datum_kupovine; }
			set
			{
				if ( state != ObjectState.isDeleted) {
					this.datum_kupovine = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private int id_trgovac_kupovina = 1;
		public int pID_Trgovac_Kupovina
		{
			get { return id_trgovac_kupovina; }
			set
			{
				if (this.id_trgovac_kupovina != value && state != ObjectState.isDeleted) {
					this.id_trgovac_kupovina = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private Trgovac trgovac_kupovina = null;
		public Trgovac pTrgovac_Kupovina
		{
			get { return trgovac_kupovina; }
			set
			{
				if (value.pID_Trgovac != id_trgovac_kupovina && state != ObjectState.isDeleted) {
					id_trgovac_kupovina = value.pID_Trgovac;
					trgovac_kupovina = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private int cena_pri_kupovini = -1;
		public int pCena_Pri_Kupovini
		{
			get { return cena_pri_kupovini; }
			set
			{
				if (this.cena_pri_kupovini != value && state != ObjectState.isDeleted) {
					this.cena_pri_kupovini = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private MyDate datum_prodaje = new MyDate( );
		public MyDate pDatum_Prodaje
		{
			get { return datum_prodaje; }
			set
			{
				if (state != ObjectState.isDeleted) {
					this.datum_prodaje = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private int id_trgovac_prodaja = 1;
		public int pID_Trgovac_Prodaja
		{
			get { return id_trgovac_prodaja; }
			set
			{
				if (this.id_trgovac_prodaja != value && state != ObjectState.isDeleted) {
					this.id_trgovac_prodaja = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private Trgovac trgovac_prodaja = null;
		public Trgovac pTrgovac_Prodaja
		{
			get { return trgovac_prodaja; }
			set
			{
				if (value.pID_Trgovac != id_trgovac_prodaja && state != ObjectState.isDeleted) {
					id_trgovac_prodaja = value.pID_Trgovac;
					trgovac_prodaja = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private int cena_pri_prodaji = -1;
		public int pCena_Pri_Prodaji
		{
			get { return cena_pri_prodaji; }
			set
			{
				if (this.cena_pri_prodaji != value && state != ObjectState.isDeleted) {
					this.cena_pri_prodaji = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		private bool rezervacija = false;
		public bool pRezervacija
		{
			get { return rezervacija; }
			set
			{
				if (this.rezervacija != value && state != ObjectState.isDeleted) {
					this.rezervacija = value;
					if (state != ObjectState.isNew)
						state = ObjectState.isEdited;
				}
			}
		}

		//================================================================================
		#endregion

		#region KONSTRUKTORI
		//================================================================================

		public PolovneKomponente ( ) : base( "polovne_komponente" ) { }

		public PolovneKomponente ( int id, string naziv, int id_kat, object datumKupovine, int kupio, int cenaKupovine,
																	object datumProdaje, int prodao, int cenaProdaje, bool rez )
			: base( "polovne_komponente" )
		{
			this.id_polovne_komponente = id;
			this.naziv_komponente = naziv;
			this.id_kategorije = id_kat;
			this.id_trgovac_kupovina = kupio;
			this.cena_pri_kupovini = cenaKupovine;
			this.id_trgovac_prodaja = prodao;
			this.cena_pri_prodaji = cenaProdaje;
			this.rezervacija = rez;

			try {
				this.datum_kupovine = (MySqlDateTime) datumKupovine;
			}
			catch {
				this.datum_kupovine = (DateTime) datumKupovine;
			}

			try {
				this.datum_prodaje = (MySqlDateTime)datumProdaje;
			}
			catch {
				this.datum_prodaje = (DateTime)datumProdaje;
			}

			state = ObjectState.isLoaded;
		}

		public PolovneKomponente ( int id, string naziv )
			: base( "polovne_komponente" )
		{
			this.id_polovne_komponente = id;
			this.naziv_komponente = naziv;

			state = ObjectState.isLoaded;
		}

		public void LoadAditionalData ( _Connect conn )
		{
			if (kategorija == null) {
				kategorija = new Kategorije( );
				kategorija.Load( conn, id_kategorije );
			}
			else {
				if (kategorija.pID_Kategorije != id_kategorije) {
					kategorija.Load( conn, id_kategorije );
				}
			}

			if (trgovac_kupovina == null) {
				trgovac_kupovina = new Trgovac( );
				trgovac_kupovina.Load( conn, id_trgovac_kupovina );
			}
			else {
				if (trgovac_kupovina.pID_Trgovac != id_trgovac_kupovina) {
					trgovac_kupovina.Load( conn, id_trgovac_kupovina );
				}
			}

			if (trgovac_prodaja == null) {
				trgovac_prodaja = new Trgovac( );
				trgovac_prodaja.Load( conn, id_trgovac_prodaja );
			}
			else {
				if (trgovac_prodaja.pID_Trgovac != id_trgovac_prodaja) {
					trgovac_prodaja.Load( conn, id_trgovac_prodaja );
				}
			}
		}

		//================================================================================
		#endregion

		#region OVERRIDE
		//================================================================================

		/// <summary>
		/// Loaduje sve podakte iz tabele trgovac
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <returns>Vraca podatke u obliku liste cij su elementi objekti Trgovac</returns>
		public override List<object> LoadAll ( _Connect conn )
		{
			List<object> ret = new List<object>( );

			List<List<object>> lista = conn.LoadAll( tableName, 1 );

			foreach (List<object> l in lista)
					ret.Add( new PolovneKomponente( (int) l[0], (string) l[1], (int) l[2],
													l[3], (int) l[4], (int) l[5],
													l[6], (int) l[7], (int) l[8], (bool) l[9] ) );

			return ret;
		}

		/// <summary>
		/// Loaduje jedan red tabele trgovac direktno u ovaj primerak klase
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		/// <param name="id">ID elementa koji se loaduje</param>
		public override void Load ( _Connect conn, int id )
		{
			List<object> lista = conn.Load( tableName, id );

			this.id_polovne_komponente = (int)lista[0];
			this.naziv_komponente = (string)lista[1];
			this.id_kategorije = (int)lista[2];
			this.id_trgovac_kupovina = (int)lista[4];
			this.cena_pri_kupovini = (int)lista[5];
			this.id_trgovac_prodaja = (int)lista[7];
			this.cena_pri_prodaji = (int)lista[8];
			this.rezervacija = (bool)lista[9];

			try {
				this.datum_kupovine = (MySqlDateTime) lista[3];
			}
			catch {
				this.datum_kupovine = (DateTime) lista[3];
			}

			try {
				this.datum_prodaje = (MySqlDateTime) lista[6];
			}
			catch {
				this.datum_prodaje = (DateTime) lista[6];
			}

			state = ObjectState.isLoaded;
		}

		/// <summary>
		/// Resetuje propery elemente klase
		/// </summary>
		public override void Reset ( )
		{
			this.id_polovne_komponente = -1;
			this.naziv_komponente = "";
			this.id_kategorije = -1;
			this.datum_kupovine = new MyDate( );
			this.id_trgovac_kupovina = -1;
			this.cena_pri_kupovini = -1;
			this.datum_prodaje = new MyDate( );
			this.id_trgovac_prodaja = -1;
			this.cena_pri_prodaji = -1;
			this.rezervacija = false; 
			;
			this.state = ObjectState.None;
		}



		/// <summary>
		/// Vrsi snimanje ili brisanje elementa u zavisnosti koja je funkcija pre toga pozvana
		/// </summary>
		/// <param name="conn">Konekcija ka bazi</param>
		public override void Save ( _Connect conn )
		{
			switch (state) {
				case ObjectState.isNew:
					state = ObjectState.isLoaded;

					List<string> listaAdd = new List<string>( );

					listaAdd.Add( this.id_polovne_komponente.ToString( ) );
					listaAdd.Add( this.naziv_komponente );
					listaAdd.Add( this.id_kategorije.ToString( ) );
					listaAdd.Add( this.datum_kupovine.ToString( ) );
					listaAdd.Add( this.id_trgovac_kupovina.ToString( ) );
					listaAdd.Add( this.cena_pri_kupovini.ToString( ) );
					listaAdd.Add( this.datum_prodaje.ToString( ) );
					listaAdd.Add( this.id_trgovac_prodaja.ToString( ) );
					listaAdd.Add( this.cena_pri_prodaji.ToString( ) );
					listaAdd.Add( Convert.ToInt32(this.rezervacija).ToString( ) );

					id_polovne_komponente = conn.Insert( tableName, listaAdd );
					break;
				case ObjectState.isDeleted:
					state = ObjectState.None;

					conn.Delete( tableName, id_polovne_komponente );

					Reset( );
					break;
				case ObjectState.isEdited:
					state = ObjectState.None;

					//conn.Delete( tableName, id_polovne_komponente );

					List<string> listaEdit = new List<string>( );
					//listaEdit.Add( this.id_polovne_komponente.ToString( ) );
					listaEdit.Add( this.naziv_komponente );
					listaEdit.Add( this.id_kategorije.ToString( ) );
					listaEdit.Add( this.datum_kupovine.ToString( ) );
					listaEdit.Add( this.id_trgovac_kupovina.ToString( ) );
					listaEdit.Add( this.cena_pri_kupovini.ToString( ) );
					listaEdit.Add( this.datum_prodaje.ToString( ) );
					listaEdit.Add( this.id_trgovac_prodaja.ToString( ) );
					listaEdit.Add( this.cena_pri_prodaji.ToString( ) );
					listaEdit.Add( Convert.ToInt32( this.rezervacija ).ToString( ) );

					conn.Edit( tableName, id_polovne_komponente, listaEdit );

					//conn.Insert( tableName, listaEdit );
					break;
			}
		}

		public override string ToString ( )
		{
			return "ID P.K.: " + id_polovne_komponente.ToString( ) + ", Naziv: " + naziv_komponente +
					", ID kat: " + id_kategorije.ToString( ) + ", D. Kupovine: " + datum_kupovine.ToString( ) +
					", Kupio: " + id_trgovac_kupovina.ToString( ) + ", K. Cena: " + cena_pri_kupovini.ToString( ) +
					", D. Prodaje: " + datum_prodaje.ToString( ) + ", Prodao: " + id_trgovac_prodaja.ToString( ) +
					", P. Cena: " + cena_pri_prodaji.ToString( ) + ", Rezervacija: " + rezervacija.ToString( );
		}

		//================================================================================
		#endregion
	}

	//================================================================================
	#endregion


	public class MyDate
	{
		private MySqlDateTime datum = new MySqlDateTime( );

		public MyDate ( ) { }

		public MyDate ( int month, int day, int year )
		{
			datum.Day = day;
			datum.Month = month;
			datum.Year = year;
		}

		public MyDate ( int month, int day, int year, int hour, int minute, int second )
		{
			datum.Day = day;
			datum.Month = month;
			datum.Year = year;
			datum.Hour = hour;
			datum.Minute = minute;
			datum.Second = second;
		}

		public MyDate(MySqlDateTime mdt)
		{
			datum = mdt;
		}

		public bool IsNull
		{
			get { return datum.IsNull; }
		}

		public bool IsValidDate
		{
			get { return datum.IsValidDateTime; }
		}

		public DateTime GetDateTime ( )
		{
			try {
				return datum.GetDateTime( );
			}
			catch {
				return DateTime.MinValue;
			}
		}

		public int Day
		{
			get { return datum.Day; }
			set { datum.Day = value; }
		}

		public int Month
		{
			get { return datum.Month; }
			set { datum.Month = value; }
		}

		public int Year
		{
			get { return datum.Year; }
			set { datum.Year = value; }
		}

		public int Hour
		{
			get { return datum.Hour; }
			set { datum.Hour = value; }
		}

		public int Minute
		{
			get { return datum.Minute; }
			set { datum.Minute = value; }
		}

		public int Second
		{
			get { return datum.Second; }
			set { datum.Second = value; }
		}

		public override string ToString ( )
		{
			//if (datum.IsNull)
			//    return "null";
			//else
			return Year.ToString( ) + "/" + Month.ToString( ) + "/" + Day.ToString( ) +
					" " + Hour.ToString( ) + ":" + Minute.ToString( ) + ":" + Second.ToString( );
			
		}

		public static implicit operator MyDate ( MySqlDateTime mdt )
		{
			return new MyDate( mdt );
		}

		public static implicit operator MyDate ( DateTime mdt )
		{
			return new MyDate( mdt.Month, mdt.Day, mdt.Year, mdt.Hour, mdt.Minute, mdt.Second );
		}
	}
}