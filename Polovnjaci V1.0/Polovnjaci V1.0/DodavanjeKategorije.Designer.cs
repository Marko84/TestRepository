﻿namespace Polovnjaci_V1._0
{
	partial class DodavanjeKategorije
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
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.button1 = new System.Windows.Forms.Button( );
			this.button2 = new System.Windows.Forms.Button( );
			this.label1 = new System.Windows.Forms.Label( );
			this.listView1 = new System.Windows.Forms.ListView( );
			this.ch_nazivKategorije = ((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader( )));
			this.textBox1 = new System.Windows.Forms.TextBox( );
			this.button3 = new System.Windows.Forms.Button( );
			this.SuspendLayout( );
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 173, 65 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 23 );
			this.button1.TabIndex = 0;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point( 270, 176 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 23 );
			this.button2.TabIndex = 0;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 170, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 37, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Naziv:";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.ch_nazivKategorije} );
			this.listView1.Location = new System.Drawing.Point( 13, 13 );
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size( 151, 186 );
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listView1_ColumnClick );
			this.listView1.DoubleClick += new System.EventHandler( this.listView1_DoubleClick );
			// 
			// ch_nazivKategorije
			// 
			this.ch_nazivKategorije.Text = "Naziv kategorije";
			this.ch_nazivKategorije.Width = 140;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point( 173, 29 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 156, 20 );
			this.textBox1.TabIndex = 3;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 254, 65 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 75, 23 );
			this.button3.TabIndex = 0;
			this.button3.Text = "Delete";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.button3_Click );
			// 
			// DodavanjeKategorije
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 357, 218 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.listView1 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.button3 );
			this.Controls.Add( this.button1 );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DodavanjeKategorije";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DodavanjeKategorije";
			this.ResumeLayout( false );
			this.PerformLayout( );

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ColumnHeader ch_nazivKategorije;
		private System.Windows.Forms.Button button3;
	}
}