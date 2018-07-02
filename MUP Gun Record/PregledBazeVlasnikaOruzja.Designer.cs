namespace MUP_Gun_Record
{
    partial class PregledBazeVlasnikaOruzja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PregledBazeVlasnikaOruzja));
            this.gumbPovratak = new System.Windows.Forms.Button();
            this.vlasniciGridView = new System.Windows.Forms.DataGridView();
            this.oibColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jmbgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlasnikOruzjaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serijskiBrojColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proizvodacColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipOruzjaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumIstekaLijecnickogColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumeIstekaDozvoleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oznakaInfoDvostrukiKlik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vlasniciGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gumbPovratak
            // 
            this.gumbPovratak.Location = new System.Drawing.Point(12, 12);
            this.gumbPovratak.Name = "gumbPovratak";
            this.gumbPovratak.Size = new System.Drawing.Size(75, 58);
            this.gumbPovratak.TabIndex = 0;
            this.gumbPovratak.Text = "Povratak";
            this.gumbPovratak.UseVisualStyleBackColor = true;
            this.gumbPovratak.Click += new System.EventHandler(this.gumbPovratak_Click);
            // 
            // vlasniciGridView
            // 
            this.vlasniciGridView.AllowUserToAddRows = false;
            this.vlasniciGridView.AllowUserToDeleteRows = false;
            this.vlasniciGridView.AllowUserToOrderColumns = true;
            this.vlasniciGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vlasniciGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oibColumn,
            this.jmbgColumn,
            this.vlasnikOruzjaColumn,
            this.serijskiBrojColumn,
            this.proizvodacColumn,
            this.modelColumn,
            this.tipOruzjaColumn,
            this.datumIstekaLijecnickogColumn,
            this.datumeIstekaDozvoleColumn});
            this.vlasniciGridView.Location = new System.Drawing.Point(12, 76);
            this.vlasniciGridView.Name = "vlasniciGridView";
            this.vlasniciGridView.ReadOnly = true;
            this.vlasniciGridView.Size = new System.Drawing.Size(944, 323);
            this.vlasniciGridView.TabIndex = 3;
            this.vlasniciGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vlasniciGridView_DoubleClick);
            // 
            // oibColumn
            // 
            this.oibColumn.HeaderText = "OIB vlasnika oružja";
            this.oibColumn.Name = "oibColumn";
            this.oibColumn.ReadOnly = true;
            // 
            // jmbgColumn
            // 
            this.jmbgColumn.HeaderText = "JMBG vlasnika oružja";
            this.jmbgColumn.Name = "jmbgColumn";
            this.jmbgColumn.ReadOnly = true;
            // 
            // vlasnikOruzjaColumn
            // 
            this.vlasnikOruzjaColumn.HeaderText = "Vlasnik oružja";
            this.vlasnikOruzjaColumn.Name = "vlasnikOruzjaColumn";
            this.vlasnikOruzjaColumn.ReadOnly = true;
            // 
            // serijskiBrojColumn
            // 
            this.serijskiBrojColumn.HeaderText = "Serijski broj oružja";
            this.serijskiBrojColumn.Name = "serijskiBrojColumn";
            this.serijskiBrojColumn.ReadOnly = true;
            // 
            // proizvodacColumn
            // 
            this.proizvodacColumn.HeaderText = "Proizvođač oružja";
            this.proizvodacColumn.Name = "proizvodacColumn";
            this.proizvodacColumn.ReadOnly = true;
            // 
            // modelColumn
            // 
            this.modelColumn.HeaderText = "Model oružja";
            this.modelColumn.Name = "modelColumn";
            this.modelColumn.ReadOnly = true;
            // 
            // tipOruzjaColumn
            // 
            this.tipOruzjaColumn.HeaderText = "Tip oružja";
            this.tipOruzjaColumn.Name = "tipOruzjaColumn";
            this.tipOruzjaColumn.ReadOnly = true;
            // 
            // datumIstekaLijecnickogColumn
            // 
            this.datumIstekaLijecnickogColumn.HeaderText = "Datum isteka liječničkog pregleda";
            this.datumIstekaLijecnickogColumn.Name = "datumIstekaLijecnickogColumn";
            this.datumIstekaLijecnickogColumn.ReadOnly = true;
            // 
            // datumeIstekaDozvoleColumn
            // 
            this.datumeIstekaDozvoleColumn.HeaderText = "Datum isteka dozvole za oružje";
            this.datumeIstekaDozvoleColumn.Name = "datumeIstekaDozvoleColumn";
            this.datumeIstekaDozvoleColumn.ReadOnly = true;
            // 
            // oznakaInfoDvostrukiKlik
            // 
            this.oznakaInfoDvostrukiKlik.AutoSize = true;
            this.oznakaInfoDvostrukiKlik.Location = new System.Drawing.Point(289, 35);
            this.oznakaInfoDvostrukiKlik.Name = "oznakaInfoDvostrukiKlik";
            this.oznakaInfoDvostrukiKlik.Size = new System.Drawing.Size(423, 13);
            this.oznakaInfoDvostrukiKlik.TabIndex = 4;
            this.oznakaInfoDvostrukiKlik.Text = "Dvostruko kliknite na redak u tablici kako bi dobili detaljnije informacije o vla" +
    "sniku oružja.";
            // 
            // PregledBazeVlasnikaOruzja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 411);
            this.Controls.Add(this.oznakaInfoDvostrukiKlik);
            this.Controls.Add(this.vlasniciGridView);
            this.Controls.Add(this.gumbPovratak);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PregledBazeVlasnikaOruzja";
            this.Text = "Pregled baze podataka vlasnika oružja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pregledBazeVlasnikaOruzja_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pregledBazeVlasnikaOruzja_FormClosed);
            this.Load += new System.EventHandler(this.PregledBazeVlasnikaOruzja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vlasniciGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gumbPovratak;
        private System.Windows.Forms.DataGridView vlasniciGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn oibColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmbgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlasnikOruzjaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serijskiBrojColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proizvodacColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipOruzjaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumIstekaLijecnickogColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumeIstekaDozvoleColumn;
        private System.Windows.Forms.Label oznakaInfoDvostrukiKlik;
    }
}