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
	public partial class DodavanjeKomponete : Form
	{
		Dictionary<string, Kategorije> dataKatategorije = new Dictionary<string, Kategorije>( );
		Dictionary<string, Trgovac> dataTrgovac = new Dictionary<string, Trgovac>( );

		PolovneKomponente pKomponeta = null;

//		private bool isEdited = false;


		public DodavanjeKomponete ( )
		{
			InitializeComponent( );
			ResetAll( );
		}

		public void ResetAll ( )
		{
			lID.Text = "";
			tbNaziv.Text = "";
			if (cbKategorije.Items.Count > 0)
				cbKategorije.SelectedIndex = 0;
			if (cbRezervisano.Items.Count > 0)
				cbRezervisano.SelectedIndex = 0;

			dtKupovina.Value = DateTime.Now;
			if (cbKupio.Items.Count > 0)
				cbKupio.SelectedIndex = 0;
			nudCenaKupovine.Value = 0;

			dtProdaja.Value = DateTime.Now;
			if (cbProdao.Items.Count > 0)
				cbProdao.SelectedIndex = 0;
			nudCenaProdaje.Value = 0;

			if (pKomponeta != null)
				pKomponeta = null;
		}

		public void LoadCBInfo ( )
		{
			dataKatategorije.Clear( );
			dataTrgovac.Clear( );
			cbKategorije.Items.Clear( );
			cbProdao.Items.Clear( );
			cbKupio.Items.Clear( );
			cbRezervisano.Items.Clear( );

			MySQL_Connection.GetInstance( ).Open( );

			foreach (Kategorije k in new Kategorije( ).LoadAll( MySQL_Connection.GetInstance( ) )) {
				dataKatategorije.Add(k.pNaziv_Kategorije, k);
				cbKategorije.Items.Add(k.pNaziv_Kategorije);
			}

			foreach (Trgovac t in new Trgovac( ).LoadAll( MySQL_Connection.GetInstance( ) )) {
				dataTrgovac.Add( t.pIme, t );
				cbProdao.Items.Add( t.pIme );
				cbKupio.Items.Add( t.pIme );
			}

			cbRezervisano.Items.Add( "Nije" );
			cbRezervisano.Items.Add( "Jeste" );

			cbKategorije.SelectedIndex = 0;
			cbProdao.SelectedIndex = 0;
			cbKupio.SelectedIndex = 0;
			cbRezervisano.SelectedIndex = 0;

			MySQL_Connection.GetInstance( ).Close( );
		}

		public void LoadItem ( PolovneKomponente pk )
		{
			lID.Text = pk.pID_Polovne_Komponente.ToString( );
			tbNaziv.Text = pk.pNaziv_Komponente;
			cbKategorije.SelectedItem = GetKatName( pk.pID_Kategorije );
			cbRezervisano.SelectedIndex = Convert.ToInt32( pk.pRezervacija );

			if (pk.pDatum_Kupovine.GetDateTime( ) > dtKupovina.MinDate)
				dtKupovina.Value = pk.pDatum_Kupovine.GetDateTime( );
			else
				dtKupovina.Value = dtKupovina.MinDate;

			cbKupio.SelectedItem = GetTrgName( pk.pID_Trgovac_Kupovina );
			nudCenaKupovine.Value = pk.pCena_Pri_Kupovini;

			if (pk.pDatum_Prodaje.GetDateTime( ) > dtProdaja.MinDate)
				dtProdaja.Value = pk.pDatum_Prodaje.GetDateTime( );
			else
				dtProdaja.Value = dtProdaja.MinDate;

			cbProdao.SelectedItem = GetTrgName( pk.pID_Trgovac_Prodaja );
			nudCenaProdaje.Value = pk.pCena_Pri_Prodaji;

			pKomponeta = pk;
		}

		private string GetKatName ( int id )
		{
			string ret = "";
			foreach (Kategorije k in dataKatategorije.Values)
				if (k.pID_Kategorije == id)
					ret = k.pNaziv_Kategorije;

			return ret;
		}

		private string GetTrgName ( int id )
		{
			string ret = "";
			foreach (Trgovac t in dataTrgovac.Values)
				if (t.pID_Trgovac == id)
					ret = t.pIme;

			return ret;
		}

		private void btnSave_Click ( object sender, EventArgs e )
		{
			tbNaziv.Text = tbNaziv.Text.Trim( );
			if (tbNaziv.Text == "") {
				MessageBox.Show( this, "Naziv komponente je neispravan! Snimanje nije obavljeno", "Upozorenje:",
										MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}


			if (pKomponeta != null) {
				MySQL_Connection.GetInstance( ).Open( );
				pKomponeta.Save( MySQL_Connection.GetInstance( ) );
				MySQL_Connection.GetInstance( ).Close( );
				this.ResetAll( );
				this.Close( );
				return;
			}

			pKomponeta = new PolovneKomponente( );


			pKomponeta.pNaziv_Komponente = tbNaziv.Text;
			pKomponeta.pID_Kategorije = dataKatategorije[(string)cbKategorije.SelectedItem].pID_Kategorije;
			pKomponeta.pRezervacija = Convert.ToBoolean( cbRezervisano.SelectedIndex );

			pKomponeta.pDatum_Kupovine = dtKupovina.Value;
			pKomponeta.pID_Trgovac_Kupovina = dataTrgovac[(string) cbKupio.SelectedItem].pID_Trgovac;
			pKomponeta.pCena_Pri_Kupovini = (int) nudCenaKupovine.Value;

			pKomponeta.pDatum_Prodaje = dtProdaja.Value;
			pKomponeta.pID_Trgovac_Prodaja = dataTrgovac[(string) cbProdao.SelectedItem].pID_Trgovac;
			pKomponeta.pCena_Pri_Prodaji = (int) nudCenaProdaje.Value;

			MySQL_Connection.GetInstance( ).Open( );
			pKomponeta.Save( MySQL_Connection.GetInstance( ) );
			MySQL_Connection.GetInstance( ).Close( );

			this.ResetAll( );
		}

		private void btnClose_Click ( object sender, EventArgs e )
		{
			this.Close( );
		}

		private void tbNaziv_TextChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null)
				if (pKomponeta.pNaziv_Komponente != tbNaziv.Text)
					pKomponeta.pNaziv_Komponente = tbNaziv.Text;
		}

		private void cbKategorije_SelectedIndexChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null) {
				int tmp = dataKatategorije[(string) cbKategorije.SelectedItem].pID_Kategorije;
				if (pKomponeta.pID_Kategorije != tmp)
					pKomponeta.pID_Kategorije = tmp;
			}
		}

		private void cbRezervisano_SelectedIndexChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null) {
				bool tmp = Convert.ToBoolean( cbRezervisano.SelectedIndex );
				if (pKomponeta.pRezervacija != tmp)
					pKomponeta.pRezervacija = tmp;
			}
		}

		private void dtKupovina_ValueChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null)
				if (pKomponeta.pDatum_Kupovine.GetDateTime( ) != dtKupovina.Value)
					pKomponeta.pDatum_Kupovine = dtKupovina.Value;
		}

		private void cbKupio_SelectedIndexChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null) {
				int tmp = dataTrgovac[(string)cbKupio.SelectedItem].pID_Trgovac;
				if (pKomponeta.pID_Trgovac_Kupovina != tmp)
					pKomponeta.pID_Trgovac_Kupovina = tmp;

				if (dtKupovina.Value == dtKupovina.MinDate)
					dtKupovina.Value = DateTime.Now;
			}
		}

		private void nudCenaKupovine_ValueChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null) {
				int tmp = (int) nudCenaKupovine.Value;
				if (pKomponeta.pCena_Pri_Kupovini != tmp)
					pKomponeta.pCena_Pri_Kupovini = tmp;
			}
		}

		private void dtProdaja_ValueChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null)
				if (pKomponeta.pDatum_Prodaje.GetDateTime( ) != dtProdaja.Value)
					pKomponeta.pDatum_Prodaje = dtProdaja.Value;
		}

		private void cbProdao_SelectedIndexChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null) {
				int tmp = dataTrgovac[(string) cbProdao.SelectedItem].pID_Trgovac;
				if (pKomponeta.pID_Trgovac_Prodaja != tmp)
					pKomponeta.pID_Trgovac_Prodaja = tmp;

				if (dtProdaja.Value == dtProdaja.MinDate)
					dtProdaja.Value = DateTime.Now;
			}
		}

		private void nudCenaProdaje_ValueChanged ( object sender, EventArgs e )
		{
			if (pKomponeta != null) {
				int tmp = (int) nudCenaProdaje.Value;
				if (pKomponeta.pCena_Pri_Prodaji != tmp)
					pKomponeta.pCena_Pri_Prodaji = tmp;
			}
		}

		private void button1_Click ( object sender, EventArgs e )
		{
			if (sender == button1)
				dtProdaja.Value = DateTime.Now;
			else
				dtKupovina.Value = DateTime.Now;
		}
		
	}
}
