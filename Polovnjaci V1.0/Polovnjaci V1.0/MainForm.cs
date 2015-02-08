using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Polovnjaci_V1._0
{
    public partial class MainForm : Form
    {
		List<Column> columnInfo = new List<Column>( );

        public MainForm ( )
        {
            InitializeComponent( );

			LoadColumnInfo( );
        }

		#region LoadColumnInfo
		private void LoadColumnInfo ( )
		{
			Column k = new Column( 0, 0, "ID", 30 );
			columnInfo.Add( k );
			k = new Column( 1, 1, "Naziv komponente", 110 );
			columnInfo.Add( k );
			k = new Column( 2, 2, "Kategorija", 100 );
			columnInfo.Add( k );
			k = new Column( 3, 3, "Datum kup.", 100 );
			columnInfo.Add( k );
			k = new Column( 4, 4, "Kupio", 70 );
			columnInfo.Add( k );
			k = new Column( 5, 5, "Cena kup.", 60 );
			columnInfo.Add( k );
			k = new Column( 6, 6, "Datum pro.", 100 );
			columnInfo.Add( k );
			k = new Column( 7, 7, "Prodao", 70 );
			columnInfo.Add( k );
			k = new Column( 8, 8, "Cena pro.", 60 );
			columnInfo.Add( k );
			k = new Column( 9, 9, "Rezervisano", 70 );
			columnInfo.Add( k );
		}
		#endregion

		private void button1_Click ( object sender, EventArgs e )
		{
			_Connect conn = MySQL_Connection.GetInstance( );
			conn.Open( );

			mainView.Items.Clear( );
			mainView.Columns.Clear( );

			PolovneKomponente pk = new PolovneKomponente();
			foreach (Column k in columnInfo)
				mainView.Columns.Add( k );

			ListViewItem lvi = null;
			foreach (PolovneKomponente p in pk.LoadAll( conn )) {
				lvi = new ListViewItem( );
				p.LoadAditionalData( conn );

				lvi.Text = p.pID_Polovne_Komponente.ToString( );

				lvi.SubItems.Add( p.pNaziv_Komponente );
				lvi.SubItems.Add( p.pKategorija.pNaziv_Kategorije );
				lvi.SubItems.Add( p.pDatum_Kupovine.ToString( ) );
				lvi.SubItems.Add( p.pTrgovac_Kupovina.pIme );
				lvi.SubItems.Add( p.pCena_Pri_Kupovini.ToString( ) );
				lvi.SubItems.Add( p.pDatum_Prodaje.ToString( ) );
				lvi.SubItems.Add( p.pTrgovac_Prodaja.pIme );
				lvi.SubItems.Add( p.pCena_Pri_Prodaji.ToString( ) );
				lvi.SubItems.Add( Convert.ToInt32( p.pRezervacija ).ToString( ) );

				mainView.Items.Add( lvi );
			}

			conn.Close( );
		}

		private void button2_Click ( object sender, EventArgs e )
		{
			DodavanjeKomponete dk = new DodavanjeKomponete( );
			dk.LoadCBInfo( );

			dk.ShowDialog( );
		}

		private void button3_Click ( object sender, EventArgs e )
		{
			DodavanjeKategorije dk = new DodavanjeKategorije( );
			dk.UcitajKategorije( );
			dk.ShowDialog( this );
		}

		private void mainView_DoubleClick ( object sender, EventArgs e )
		{
			if (mainView.SelectedItems.Count < 1)
				return;

			int i = int.Parse( mainView.SelectedItems[0].Text );

			MySQL_Connection.GetInstance( ).Open( );
			PolovneKomponente pk = new PolovneKomponente( );
			pk.Load( MySQL_Connection.GetInstance( ), i );
			MySQL_Connection.GetInstance( ).Close( );

			DodavanjeKomponete dk = new DodavanjeKomponete( );
			dk.ResetAll( );
			dk.LoadCBInfo( );
			dk.LoadItem( pk );
			dk.ShowDialog( this );
		}


    }

	public class Column: ColumnHeader
	{
		private int idList;
		public int ListID
		{
			get { return idList; }
			set { idList = value; }
		}
		public string ColumnName
		{
			get { return this.Text; }
			set { this.Text = value; }
		}
		private int idTable;
		public int TabeleID { get { return idTable; } }

		public Column ( int tableId, int listId, string name, int width )
		{
			this.idTable = tableId;
			this.idList = listId;
			this.Text = name;
			this.Width = width;
		}

		private Column ( ) { }
	}
}
