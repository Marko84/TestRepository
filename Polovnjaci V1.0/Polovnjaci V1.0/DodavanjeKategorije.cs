using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Polovnjaci_V1._0
{
	public partial class DodavanjeKategorije : Form
	{

		private Dictionary<string, Kategorije> data;

		//private bool isEdited = false;
		//private Kategorije editeIndex = null;

		//public bool IsEdited
		//{
		//    get { return isEdited; }
		//}

		private ListViewItem selected = null;

		public DodavanjeKategorije ( )
		{
			InitializeComponent( );

			data = new Dictionary<string, Kategorije>( );
		}

		public void UcitajKategorije ( )
		{
			_Connect conn = MySQL_Connection.GetInstance( );
			conn.Open( );

			foreach (Kategorije k in new Kategorije( ).LoadAll( conn )) {
				data.Add( k.pNaziv_Kategorije, k );
				listView1.Items.Add( k.pNaziv_Kategorije );
				//listView1.Items[listView1.Items.Count-1].BackColor = 
			}

			conn.Close( );
		}

		private void listView1_ColumnClick ( object sender, ColumnClickEventArgs e )
		{
			if (listView1.Sorting == SortOrder.Ascending)
				listView1.Sorting = SortOrder.Descending;
			else
				listView1.Sorting = SortOrder.Ascending;

			listView1.ListViewItemSorter = new ListViewItemComparerKat( listView1.Sorting );
			listView1.Sort( );

		}

		private void listView1_DoubleClick ( object sender, EventArgs e )
		{
			if (listView1.SelectedItems.Count != 0) {
				textBox1.Text = listView1.SelectedItems[0].Text;

				if (selected != null)
					selected.BackColor = Color.White;

				selected = listView1.SelectedItems[0];
				selected.BackColor = Color.Beige;

				listView1.SelectedItems.Clear( );
			}
		}

		private void button1_Click ( object sender, EventArgs e )
		{
			if (data.ContainsKey( textBox1.Text ))
				return;

			//isEdited = true;

			if (selected == null) {
				Kategorije k = new Kategorije( );
				k.AddNew( );
				k.pNaziv_Kategorije = textBox1.Text;

				MySQL_Connection.GetInstance( ).Open( );
				k.Save( MySQL_Connection.GetInstance( ) );
				MySQL_Connection.GetInstance( ).Close( );

				data.Add( k.pNaziv_Kategorije, k );
				listView1.Items.Add( k.pNaziv_Kategorije );
				textBox1.Text = "";
			}
			else {
				Kategorije k = data[selected.Text];
				data.Remove( selected.Text );
				listView1.Items.Remove( selected );


				k.pNaziv_Kategorije = textBox1.Text;
				

				MySQL_Connection.GetInstance( ).Open( );
				k.Save( MySQL_Connection.GetInstance( ) );
				MySQL_Connection.GetInstance( ).Close( );

				data.Add( k.pNaziv_Kategorije, k );
				listView1.Items.Add( k.pNaziv_Kategorije );


				textBox1.Text = "";
				selected.BackColor = Color.White;
				selected = null;
			}
		}

		private void button3_Click ( object sender, EventArgs e )
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			if (MessageBox.Show( this, "Da li ste sigurni da zelite da obrisete kategoriju:\n" + listView1.SelectedItems[0].Text, "Upozorenje", 
									MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != System.Windows.Forms.DialogResult.Yes)
				return;


			Kategorije k = data[listView1.SelectedItems[0].Text];

			k.MarkForDelete( );

			try {
				MySQL_Connection.GetInstance( ).Open( );
				k.Save( MySQL_Connection.GetInstance( ) );
				MySQL_Connection.GetInstance( ).Close( );
			}
			catch {
				MessageBox.Show( this, "Neuspelo brisanje kategorije:\n" + listView1.SelectedItems[0].Text + "\n Verovatno postoji neka komponenta sa ovom kategorijom!", "Informacija",
						MessageBoxButtons.OK, MessageBoxIcon.Information );

				return;
			}

			ListViewItem tmp = listView1.SelectedItems[0];


			if (selected == tmp) {
				textBox1.Text = "";
				selected.BackColor = Color.White;
				selected = null;

			}

			listView1.SelectedItems.Clear( );
			listView1.Items.Remove( tmp );
			data.Remove( tmp.Text );

		}

		private void button2_Click ( object sender, EventArgs e )
		{
			this.Close( );
		}



	}

	class ListViewItemComparerKat : IComparer
	{
		private SortOrder order;

		public ListViewItemComparerKat ( )
		{
			order = SortOrder.Ascending;
		}

		public ListViewItemComparerKat (SortOrder order )
		{
			this.order = order;
		}

		public int Compare ( object x, object y )
		{
			int returnVal = -1;
			returnVal = String.Compare( ((ListViewItem) x).Text,
									((ListViewItem) y).Text );
			// Determine whether the sort order is descending.
			if (order == SortOrder.Descending)
				// Invert the value returned by String.Compare.
				returnVal *= -1;

			return returnVal;
		}
	}
}
