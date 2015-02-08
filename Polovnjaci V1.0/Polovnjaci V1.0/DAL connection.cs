using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Polovnjaci_V1._0
{

	#region CLASS: MySQL_Connection
	//================================================================================.

	/// <summary>
	/// Implementira funkcije za pristup MySQL bazi uz implementaciju 'Singletone paterna' zarad moguce optimizacije pristupa bazi
	/// </summary>
	public class MySQL_Connection : _Connect
	{
		#region members
		//================================================================================.

		/// <summary>
		/// konekcija sa bazom
		/// </summary>
		private MySqlConnection connection = null;

		/// <summary>
		/// Singletone instanca
		/// </summary>
		protected static MySQL_Connection _instance = null;

		//================================================================================
		#endregion


		#region Konstruktor i GetInstance()
		//================================================================================

		/// <summary>
		/// Privatni konstruktor
		/// </summary>
		private MySQL_Connection ( )
		{
			connectionString = "server=127.0.0.1;uid=root;pwd=jessica;database=mydb;";
			connection = new MySqlConnection( connectionString );
		}

		/// <summary>
		/// Lazy konstruktor
		/// </summary>
		/// <returns>istanca MySQL_Connection</returns>
		public static MySQL_Connection GetInstance ( )
		{
			if (_instance == null)
				_instance = new MySQL_Connection( );

			return _instance;
		}

		//================================================================================
		#endregion


		#region IMPLEMENTACIJA
		//================================================================================

		/// <summary>
		/// Otvara konekciju
		/// </summary>
		public override void Open ( )
		{
			if (connection.State != System.Data.ConnectionState.Open)
				connection.Open( );
		}

		/// <summary>
		/// Zatvara konekciju ali je ne brise. Moze kasnije opet da se otvori
		/// </summary>
		public override void Close ( )
		{
			if (connection == null)
				throw new NullReferenceException( "poziv MySQL_Connect->Close()" );

			if (connection.State != System.Data.ConnectionState.Closed)
				connection.Close( );
		}

		/// <summary>
		/// Zatvara i brise konekciju
		/// </summary>
		public override void Dispose ( )
		{
			if (connection != null)
				connection.Close( );
			connection.Dispose( );
			connection = null;
		}

		/// <summary>
		/// Loaduje sve podatke iz navedene tabele
		/// </summary>
		/// <param name="tableName">Tabela koju loaduje</param>
		/// <param name="orderByColumn">Indeks kolone po kojoj zelimo sortiranje. Za -1 i indeks veci od dozvoljenog
		/// vraca tabelu kakva je u bazi.</param>
		/// <returns>Rezultat je lista koja sadrzi liste sa odgovarajucim brojem elemenata u zavisnosti od tabele</returns>
		public override List<List<object>> LoadAll ( string tableName, int orderByColumn = 0 )
		{
			List<List<object>> ret = new List<List<object>>( );

			MySqlCommand command = new MySqlCommand( );
			command.Connection = connection;

			MySqlDataReader reader = null;

			if (orderByColumn == 0) {
				command.CommandText = tableName;
				command.CommandType = System.Data.CommandType.TableDirect;
			}
			else {
				command.CommandText = "DESCRIBE " + tableName + ";";
				reader = command.ExecuteReader( );

				bool ok = true;
				for (int i = 0 ; i < orderByColumn ; i++)
					ok = reader.Read( );

				if (ok)
					command.CommandText = "SELECT * FROM " + tableName + " ORDER BY " + reader[0] + ";";
				else {
					command.CommandText = "SELECT * FROM " + tableName;
					Console.WriteLine( "###########" );
					Console.WriteLine( "pokusao si da u loadAll izvrsis sortiranje po nepostojecoj koloni!!!" );
					Console.WriteLine( "###########" );
				}

				reader.Close( );
			}

			reader = command.ExecuteReader( );

			List<object> tmp = null;
			while (reader.Read( )) {
				tmp = new List<object>( );
				for (int i = 0 ; i < reader.FieldCount ; i++)
					try {
						tmp.Add( reader[i] );
					}
					catch {
						tmp.Add( reader.GetMySqlDateTime( i ) );
					}
				ret.Add( tmp );
			}

			reader.Close( );

			return ret;
		}

		/// <summary>
		/// Loaduje jednu vrstu iz prosledjene tabele sa zadatim indeksom
		/// </summary>
		/// <param name="tableName">Tabela sa podacima</param>
		/// <param name="id">id elementa. Ako ne nadje, vraca praznu listu. Smatra se da je uvek prva kolona u 
		/// tabeli sadrzi id</param>
		/// <returns>Vraca listu sa onliko elemenata, koliko ima kolona</returns>
		public override List<object> Load ( string tableName, int id )
		{
			List<object> ret = new List<object>( );
			MySqlCommand command = new MySqlCommand( );
			command.Connection = connection;


			command.CommandText = "DESCRIBE " + tableName + ";";
			MySqlDataReader reader = command.ExecuteReader( );
			reader.Read( );

			command.CommandText = "SELECT * "
									+ "FROM " + tableName + " "
									+ "WHERE " + tableName + "." + reader[0] + " = " + id.ToString( );

			reader.Close( );
			reader = command.ExecuteReader( );
			if (reader.Read( )) {
				for (int i = 0 ; i < reader.FieldCount ; i++)
					try {
						ret.Add( reader[i] );
					}
					catch
					{
						ret.Add( reader.GetMySqlDateTime( i ) );
					}
			}

			reader.Close( );
			return ret;
		}


		/// <summary>
		/// Dodaje element u tabelu
		/// </summary>
		/// <param name="tableName">Tabela u koju se dodaje element</param>
		/// <param name="values">Vrednosti za sve elemente jedog reda u tabeli. Prvi je uvek ID i ukoliko je manji od 1,
		/// program ce sam dodeliti indeks</param>
		/// <returns>Novidodeljeni ili stari ID elementa koji je dodavan u tabelu</returns>
		public override int Insert ( string tableName, List<string> values )
		{
			MySqlCommand command = new MySqlCommand( );
			command.Connection = connection;

			string cName = "";
			command.CommandText = "DESCRIBE " + tableName + ";";
			MySqlDataReader reader = command.ExecuteReader( );
			reader.Read( );
			cName = (string) reader[0];
			reader.Close( );

			int id = int.Parse( values[0] );
			if (id < 1) {
				command.CommandText = "SELECT " + cName + " FROM " + tableName + " ORDER BY " + cName + ";";

				reader = command.ExecuteReader( );
				if (reader.Read( )) {
					int tmp = (int) reader[0];
					if (tmp == 1) {
						while (reader.Read( )) {
							if (tmp + 1 != (int) reader[0])
								break;
							tmp = (int) reader[0];
						}
						id = tmp + 1;
					}
					else
						id = 1;
				}
				else
					id = 1;

				reader.Close( );
			}

			command.CommandText = "INSERT INTO " + tableName
								+ " VALUES('" + id.ToString( ) + "'";
			for (int i = 1 ; i < values.Count ; i++) {
				command.CommandText += ",'" + values[i] + "'";
			}
			command.CommandText += ");";

			command.ExecuteNonQuery( );
			reader.Close( );

			return id;
		}

		/// <summary>
		/// Brise element iz tabele sa zadatim id
		/// </summary>
		/// <param name="tableName">Tabela u kojoj se vrsi brisanje</param>
		/// <param name="id">id elementa koji se brise</param>
		public override void Delete ( string tableName, int id )
		{
			MySqlCommand command = new MySqlCommand( );
			command.Connection = connection;

			command.CommandText = "DESCRIBE " + tableName + ";";
			MySqlDataReader reader = command.ExecuteReader( );
			reader.Read( );


			command.CommandText = "DELETE FROM " + tableName + " "
									+ "WHERE " + tableName + "." + (string) reader[0] + " = '" + id.ToString( ) + "';";

			reader.Close( );
			command.ExecuteNonQuery( );

			reader.Close( );
		}

		/// <summary>
		/// Dodaje element u tabelu
		/// </summary>
		/// <param name="tableName">Tabela u koju se dodaje element</param>
		/// <param name="id">ID elementa koji se edituje</param>
		/// <param name="values">Vrednosti za sve elemente jedog reda u tabeli. Prvi je uvek ID i ukoliko je manji od 1,
		/// program ce sam dodeliti indeks</param>
		public override void Edit ( string tableName, int id, List<string> values )
		{
			MySqlCommand command = new MySqlCommand( );
			command.Connection = connection;

			command.CommandText = "DESCRIBE " + tableName + ";";
			MySqlDataReader reader = command.ExecuteReader( );
			reader.Read( );
			string tmp = (string)reader[0];

			command.CommandText = "UPDATE " + tableName + " SET ";

			int br = 0;
			while(reader.Read())
			{
				if(br == 0)
					command.CommandText += (string)reader[0] + " = '" + values[br] + "'";
				else
					command.CommandText += ", " + (string)reader[0] + " = '" + values[br] + "'";

				br++;
			}

			command.CommandText += " WHERE " + tmp + " = '" + id.ToString( ) + "';";

			reader.Close( );
			command.ExecuteNonQuery( );

			reader.Close( );
		}

		//public override List<string> GetColumnList ( string tableName )
		//{
		//    List<string> ret = new List<string>( );

		//    MySqlCommand command = new MySqlCommand( );
		//    command.Connection = connection;

		//    command.CommandText = "DESCRIBE " + tableName + ";";
		//    MySqlDataReader reader = command.ExecuteReader( );

		//    while (reader.Read( )) {
		//        ret.Add( (string)reader[0] );
		//    }

		//    reader.Close( );

		//    return ret;
		//}

		//================================================================================
		#endregion
	}

	//================================================================================.
	#endregion


}