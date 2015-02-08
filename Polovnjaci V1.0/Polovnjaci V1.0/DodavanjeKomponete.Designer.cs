namespace Polovnjaci_V1._0
{
	partial class DodavanjeKomponete
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if (disposing && (components != null)) {
				components.Dispose( );
			}
			base.Dispose( disposing );

			pKomponeta = null;
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.label1 = new System.Windows.Forms.Label( );
			this.label2 = new System.Windows.Forms.Label( );
			this.label3 = new System.Windows.Forms.Label( );
			this.lID = new System.Windows.Forms.Label( );
			this.dtKupovina = new System.Windows.Forms.DateTimePicker( );
			this.label6 = new System.Windows.Forms.Label( );
			this.label8 = new System.Windows.Forms.Label( );
			this.tbNaziv = new System.Windows.Forms.TextBox( );
			this.cbKategorije = new System.Windows.Forms.ComboBox( );
			this.nudCenaKupovine = new System.Windows.Forms.NumericUpDown( );
			this.cbKupio = new System.Windows.Forms.ComboBox( );
			this.gbInfo = new System.Windows.Forms.GroupBox( );
			this.label10 = new System.Windows.Forms.Label( );
			this.cbRezervisano = new System.Windows.Forms.ComboBox( );
			this.gbKupovina = new System.Windows.Forms.GroupBox( );
			this.label9 = new System.Windows.Forms.Label( );
			this.gbProdaja = new System.Windows.Forms.GroupBox( );
			this.label4 = new System.Windows.Forms.Label( );
			this.dtProdaja = new System.Windows.Forms.DateTimePicker( );
			this.nudCenaProdaje = new System.Windows.Forms.NumericUpDown( );
			this.cbProdao = new System.Windows.Forms.ComboBox( );
			this.label5 = new System.Windows.Forms.Label( );
			this.label7 = new System.Windows.Forms.Label( );
			this.btnClose = new System.Windows.Forms.Button( );
			this.btnSave = new System.Windows.Forms.Button( );
			this.button1 = new System.Windows.Forms.Button( );
			this.button2 = new System.Windows.Forms.Button( );
			((System.ComponentModel.ISupportInitialize) (this.nudCenaKupovine)).BeginInit( );
			this.gbInfo.SuspendLayout( );
			this.gbKupovina.SuspendLayout( );
			this.gbProdaja.SuspendLayout( );
			((System.ComponentModel.ISupportInitialize) (this.nudCenaProdaje)).BeginInit( );
			this.SuspendLayout( );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 42 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 93, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Naziv komponete:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 78, 20 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 21, 13 );
			this.label2.TabIndex = 0;
			this.label2.Text = "ID:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 42, 71 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 57, 13 );
			this.label3.TabIndex = 0;
			this.label3.Text = "Kategorija:";
			// 
			// lID
			// 
			this.lID.AutoSize = true;
			this.lID.Location = new System.Drawing.Point( 102, 20 );
			this.lID.Name = "lID";
			this.lID.Size = new System.Drawing.Size( 0, 13 );
			this.lID.TabIndex = 0;
			// 
			// dtKupovina
			// 
			this.dtKupovina.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtKupovina.Location = new System.Drawing.Point( 62, 46 );
			this.dtKupovina.MinDate = new System.DateTime( 2005, 1, 1, 0, 0, 0, 0 );
			this.dtKupovina.Name = "dtKupovina";
			this.dtKupovina.Size = new System.Drawing.Size( 101, 20 );
			this.dtKupovina.TabIndex = 1;
			this.dtKupovina.ValueChanged += new System.EventHandler( this.dtKupovina_ValueChanged );
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 19, 22 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 37, 13 );
			this.label6.TabIndex = 0;
			this.label6.Text = "Kupio:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 15, 52 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 41, 13 );
			this.label8.TabIndex = 0;
			this.label8.Text = "Datum:";
			// 
			// tbNaziv
			// 
			this.tbNaziv.Location = new System.Drawing.Point( 105, 39 );
			this.tbNaziv.MaxLength = 35;
			this.tbNaziv.Name = "tbNaziv";
			this.tbNaziv.Size = new System.Drawing.Size( 171, 20 );
			this.tbNaziv.TabIndex = 2;
			this.tbNaziv.TextChanged += new System.EventHandler( this.tbNaziv_TextChanged );
			// 
			// cbKategorije
			// 
			this.cbKategorije.DropDownHeight = 130;
			this.cbKategorije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbKategorije.FormattingEnabled = true;
			this.cbKategorije.IntegralHeight = false;
			this.cbKategorije.Location = new System.Drawing.Point( 105, 68 );
			this.cbKategorije.MaxDropDownItems = 10;
			this.cbKategorije.Name = "cbKategorije";
			this.cbKategorije.Size = new System.Drawing.Size( 171, 21 );
			this.cbKategorije.Sorted = true;
			this.cbKategorije.TabIndex = 3;
			this.cbKategorije.SelectedIndexChanged += new System.EventHandler( this.cbKategorije_SelectedIndexChanged );
			// 
			// nudCenaKupovine
			// 
			this.nudCenaKupovine.Location = new System.Drawing.Point( 62, 72 );
			this.nudCenaKupovine.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
			this.nudCenaKupovine.Name = "nudCenaKupovine";
			this.nudCenaKupovine.Size = new System.Drawing.Size( 100, 20 );
			this.nudCenaKupovine.TabIndex = 4;
			this.nudCenaKupovine.ValueChanged += new System.EventHandler( this.nudCenaKupovine_ValueChanged );
			// 
			// cbKupio
			// 
			this.cbKupio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbKupio.FormattingEnabled = true;
			this.cbKupio.Location = new System.Drawing.Point( 62, 19 );
			this.cbKupio.MaxDropDownItems = 4;
			this.cbKupio.Name = "cbKupio";
			this.cbKupio.Size = new System.Drawing.Size( 100, 21 );
			this.cbKupio.Sorted = true;
			this.cbKupio.TabIndex = 3;
			this.cbKupio.SelectedIndexChanged += new System.EventHandler( this.cbKupio_SelectedIndexChanged );
			// 
			// gbInfo
			// 
			this.gbInfo.Controls.Add( this.label10 );
			this.gbInfo.Controls.Add( this.cbRezervisano );
			this.gbInfo.Controls.Add( this.cbKategorije );
			this.gbInfo.Controls.Add( this.label1 );
			this.gbInfo.Controls.Add( this.label3 );
			this.gbInfo.Controls.Add( this.label2 );
			this.gbInfo.Controls.Add( this.lID );
			this.gbInfo.Controls.Add( this.tbNaziv );
			this.gbInfo.Location = new System.Drawing.Point( 20, 12 );
			this.gbInfo.Name = "gbInfo";
			this.gbInfo.Size = new System.Drawing.Size( 282, 147 );
			this.gbInfo.TabIndex = 6;
			this.gbInfo.TabStop = false;
			this.gbInfo.Text = "Informacije:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 30, 115 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 69, 13 );
			this.label10.TabIndex = 12;
			this.label10.Text = "Rezervisano:";
			// 
			// cbRezervisano
			// 
			this.cbRezervisano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRezervisano.FormattingEnabled = true;
			this.cbRezervisano.Location = new System.Drawing.Point( 105, 112 );
			this.cbRezervisano.MaxDropDownItems = 2;
			this.cbRezervisano.Name = "cbRezervisano";
			this.cbRezervisano.Size = new System.Drawing.Size( 79, 21 );
			this.cbRezervisano.TabIndex = 11;
			this.cbRezervisano.SelectedIndexChanged += new System.EventHandler( this.cbRezervisano_SelectedIndexChanged );
			// 
			// gbKupovina
			// 
			this.gbKupovina.Controls.Add( this.button1 );
			this.gbKupovina.Controls.Add( this.label8 );
			this.gbKupovina.Controls.Add( this.nudCenaKupovine );
			this.gbKupovina.Controls.Add( this.cbKupio );
			this.gbKupovina.Controls.Add( this.dtKupovina );
			this.gbKupovina.Controls.Add( this.label9 );
			this.gbKupovina.Controls.Add( this.label6 );
			this.gbKupovina.Location = new System.Drawing.Point( 308, 14 );
			this.gbKupovina.Name = "gbKupovina";
			this.gbKupovina.Size = new System.Drawing.Size( 199, 100 );
			this.gbKupovina.TabIndex = 7;
			this.gbKupovina.TabStop = false;
			this.gbKupovina.Text = "Informacije o kupovini:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 9, 74 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 46, 13 );
			this.label9.TabIndex = 0;
			this.label9.Text = "Po ceni:";
			// 
			// gbProdaja
			// 
			this.gbProdaja.Controls.Add( this.button2 );
			this.gbProdaja.Controls.Add( this.label4 );
			this.gbProdaja.Controls.Add( this.nudCenaProdaje );
			this.gbProdaja.Controls.Add( this.cbProdao );
			this.gbProdaja.Controls.Add( this.dtProdaja );
			this.gbProdaja.Controls.Add( this.label5 );
			this.gbProdaja.Controls.Add( this.label7 );
			this.gbProdaja.Location = new System.Drawing.Point( 308, 120 );
			this.gbProdaja.Name = "gbProdaja";
			this.gbProdaja.Size = new System.Drawing.Size( 199, 100 );
			this.gbProdaja.TabIndex = 8;
			this.gbProdaja.TabStop = false;
			this.gbProdaja.Text = "Informacije o prodaji:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 15, 52 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 41, 13 );
			this.label4.TabIndex = 0;
			this.label4.Text = "Datum:";
			// 
			// dtProdaja
			// 
			this.dtProdaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtProdaja.Location = new System.Drawing.Point( 62, 46 );
			this.dtProdaja.MinDate = new System.DateTime( 2005, 1, 1, 0, 0, 0, 0 );
			this.dtProdaja.Name = "dtProdaja";
			this.dtProdaja.Size = new System.Drawing.Size( 101, 20 );
			this.dtProdaja.TabIndex = 1;
			this.dtProdaja.ValueChanged += new System.EventHandler( this.dtProdaja_ValueChanged );
			// 
			// nudCenaProdaje
			// 
			this.nudCenaProdaje.Location = new System.Drawing.Point( 62, 72 );
			this.nudCenaProdaje.Maximum = new decimal( new int[] {
            100000,
            0,
            0,
            0} );
			this.nudCenaProdaje.Name = "nudCenaProdaje";
			this.nudCenaProdaje.Size = new System.Drawing.Size( 100, 20 );
			this.nudCenaProdaje.TabIndex = 4;
			this.nudCenaProdaje.ValueChanged += new System.EventHandler( this.nudCenaProdaje_ValueChanged );
			// 
			// cbProdao
			// 
			this.cbProdao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProdao.FormattingEnabled = true;
			this.cbProdao.Location = new System.Drawing.Point( 62, 19 );
			this.cbProdao.MaxDropDownItems = 4;
			this.cbProdao.Name = "cbProdao";
			this.cbProdao.Size = new System.Drawing.Size( 100, 21 );
			this.cbProdao.Sorted = true;
			this.cbProdao.TabIndex = 3;
			this.cbProdao.SelectedIndexChanged += new System.EventHandler( this.cbProdao_SelectedIndexChanged );
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 9, 74 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 46, 13 );
			this.label5.TabIndex = 0;
			this.label5.Text = "Po ceni:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 11, 22 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 44, 13 );
			this.label7.TabIndex = 0;
			this.label7.Text = "Prodao:";
			// 
			// btnClose
			// 
			this.btnClose.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)) );
			this.btnClose.Location = new System.Drawing.Point( 144, 184 );
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size( 101, 36 );
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)) );
			this.btnSave.Location = new System.Drawing.Point( 20, 184 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 101, 36 );
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)) );
			this.button1.Location = new System.Drawing.Point( 169, 49 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 20, 16 );
			this.button1.TabIndex = 11;
			this.button1.Text = "D";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)) );
			this.button2.Location = new System.Drawing.Point( 169, 48 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 20, 18 );
			this.button2.TabIndex = 11;
			this.button2.Text = "D";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button1_Click );
			// 
			// DodavanjeKomponete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 527, 237 );
			this.Controls.Add( this.btnClose );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.gbProdaja );
			this.Controls.Add( this.gbKupovina );
			this.Controls.Add( this.gbInfo );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DodavanjeKomponete";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dodavanje Komponete";
			((System.ComponentModel.ISupportInitialize) (this.nudCenaKupovine)).EndInit( );
			this.gbInfo.ResumeLayout( false );
			this.gbInfo.PerformLayout( );
			this.gbKupovina.ResumeLayout( false );
			this.gbKupovina.PerformLayout( );
			this.gbProdaja.ResumeLayout( false );
			this.gbProdaja.PerformLayout( );
			((System.ComponentModel.ISupportInitialize) (this.nudCenaProdaje)).EndInit( );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lID;
		private System.Windows.Forms.DateTimePicker dtKupovina;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbNaziv;
		private System.Windows.Forms.ComboBox cbKategorije;
		private System.Windows.Forms.NumericUpDown nudCenaKupovine;
		private System.Windows.Forms.ComboBox cbKupio;
		private System.Windows.Forms.GroupBox gbInfo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbRezervisano;
		private System.Windows.Forms.GroupBox gbKupovina;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox gbProdaja;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtProdaja;
		private System.Windows.Forms.NumericUpDown nudCenaProdaje;
		private System.Windows.Forms.ComboBox cbProdao;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}