namespace MUP_Gun_Record
{
    partial class PregledBazeOruzja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PregledBazeOruzja));
            this.gumbPovratak = new System.Windows.Forms.Button();
            this.oruzjeGridView = new System.Windows.Forms.DataGridView();
            this.serijskiBrojColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proizvodacColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipOruzjaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kalibarOruzjaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vrijednostOruzjaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.godinaProizvodnjeOruzjaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filtriranjeGroupbox = new System.Windows.Forms.GroupBox();
            this.gumbOcistiteFilter = new System.Windows.Forms.Button();
            this.gumbPrimijeniFilter = new System.Windows.Forms.Button();
            this.oznakaInfoDvostrukiKlik = new System.Windows.Forms.Label();
            this.oznakaTip = new System.Windows.Forms.Label();
            this.comboTip = new System.Windows.Forms.ComboBox();
            this.oznakaSortiranje = new System.Windows.Forms.Label();
            this.comboSortiranje = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.oruzjeGridView)).BeginInit();
            this.filtriranjeGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gumbPovratak
            // 
            this.gumbPovratak.Location = new System.Drawing.Point(12, 12);
            this.gumbPovratak.Name = "gumbPovratak";
            this.gumbPovratak.Size = new System.Drawing.Size(75, 56);
            this.gumbPovratak.TabIndex = 0;
            this.gumbPovratak.Text = "Povratak";
            this.gumbPovratak.UseVisualStyleBackColor = true;
            this.gumbPovratak.Click += new System.EventHandler(this.gumbPovratak_Click);
            // 
            // oruzjeGridView
            // 
            this.oruzjeGridView.AllowUserToAddRows = false;
            this.oruzjeGridView.AllowUserToDeleteRows = false;
            this.oruzjeGridView.AllowUserToOrderColumns = true;
            this.oruzjeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oruzjeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serijskiBrojColumn,
            this.proizvodacColumn,
            this.modelColumn,
            this.tipOruzjaColumn,
            this.kalibarOruzjaColumn,
            this.vrijednostOruzjaColumn,
            this.godinaProizvodnjeOruzjaColumn});
            this.oruzjeGridView.Location = new System.Drawing.Point(12, 74);
            this.oruzjeGridView.Name = "oruzjeGridView";
            this.oruzjeGridView.ReadOnly = true;
            this.oruzjeGridView.Size = new System.Drawing.Size(747, 323);
            this.oruzjeGridView.TabIndex = 1;
            this.oruzjeGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oruzjeGridView_DoubleClick);
            // 
            // serijskiBrojColumn
            // 
            this.serijskiBrojColumn.HeaderText = "Serijski broj";
            this.serijskiBrojColumn.Name = "serijskiBrojColumn";
            this.serijskiBrojColumn.ReadOnly = true;
            // 
            // proizvodacColumn
            // 
            this.proizvodacColumn.HeaderText = "Proizvođač";
            this.proizvodacColumn.Name = "proizvodacColumn";
            this.proizvodacColumn.ReadOnly = true;
            // 
            // modelColumn
            // 
            this.modelColumn.HeaderText = "Model";
            this.modelColumn.Name = "modelColumn";
            this.modelColumn.ReadOnly = true;
            // 
            // tipOruzjaColumn
            // 
            this.tipOruzjaColumn.HeaderText = "Tip";
            this.tipOruzjaColumn.Name = "tipOruzjaColumn";
            this.tipOruzjaColumn.ReadOnly = true;
            // 
            // kalibarOruzjaColumn
            // 
            this.kalibarOruzjaColumn.HeaderText = "Kalibar";
            this.kalibarOruzjaColumn.Name = "kalibarOruzjaColumn";
            this.kalibarOruzjaColumn.ReadOnly = true;
            // 
            // vrijednostOruzjaColumn
            // 
            this.vrijednostOruzjaColumn.HeaderText = "Vrijednost u HRK";
            this.vrijednostOruzjaColumn.Name = "vrijednostOruzjaColumn";
            this.vrijednostOruzjaColumn.ReadOnly = true;
            // 
            // godinaProizvodnjeOruzjaColumn
            // 
            this.godinaProizvodnjeOruzjaColumn.HeaderText = "Godina proizvodnje";
            this.godinaProizvodnjeOruzjaColumn.Name = "godinaProizvodnjeOruzjaColumn";
            this.godinaProizvodnjeOruzjaColumn.ReadOnly = true;
            // 
            // filtriranjeGroupbox
            // 
            this.filtriranjeGroupbox.Controls.Add(this.comboSortiranje);
            this.filtriranjeGroupbox.Controls.Add(this.oznakaSortiranje);
            this.filtriranjeGroupbox.Controls.Add(this.comboTip);
            this.filtriranjeGroupbox.Controls.Add(this.oznakaTip);
            this.filtriranjeGroupbox.Controls.Add(this.gumbOcistiteFilter);
            this.filtriranjeGroupbox.Controls.Add(this.gumbPrimijeniFilter);
            this.filtriranjeGroupbox.Location = new System.Drawing.Point(94, 25);
            this.filtriranjeGroupbox.Name = "filtriranjeGroupbox";
            this.filtriranjeGroupbox.Size = new System.Drawing.Size(665, 43);
            this.filtriranjeGroupbox.TabIndex = 2;
            this.filtriranjeGroupbox.TabStop = false;
            this.filtriranjeGroupbox.Text = "Filtriranje:";
            // 
            // gumbOcistiteFilter
            // 
            this.gumbOcistiteFilter.Location = new System.Drawing.Point(509, 8);
            this.gumbOcistiteFilter.Name = "gumbOcistiteFilter";
            this.gumbOcistiteFilter.Size = new System.Drawing.Size(75, 35);
            this.gumbOcistiteFilter.TabIndex = 1;
            this.gumbOcistiteFilter.Text = "Očistite filter";
            this.gumbOcistiteFilter.UseVisualStyleBackColor = true;
            this.gumbOcistiteFilter.Click += new System.EventHandler(this.gumbOcistiteFilter_Click);
            // 
            // gumbPrimijeniFilter
            // 
            this.gumbPrimijeniFilter.Location = new System.Drawing.Point(590, 8);
            this.gumbPrimijeniFilter.Name = "gumbPrimijeniFilter";
            this.gumbPrimijeniFilter.Size = new System.Drawing.Size(75, 35);
            this.gumbPrimijeniFilter.TabIndex = 0;
            this.gumbPrimijeniFilter.Text = "Primijenite filter";
            this.gumbPrimijeniFilter.UseVisualStyleBackColor = true;
            this.gumbPrimijeniFilter.Click += new System.EventHandler(this.gumbPrimijeniFilter_Click);
            // 
            // oznakaInfoDvostrukiKlik
            // 
            this.oznakaInfoDvostrukiKlik.AutoSize = true;
            this.oznakaInfoDvostrukiKlik.Location = new System.Drawing.Point(210, 9);
            this.oznakaInfoDvostrukiKlik.Name = "oznakaInfoDvostrukiKlik";
            this.oznakaInfoDvostrukiKlik.Size = new System.Drawing.Size(422, 13);
            this.oznakaInfoDvostrukiKlik.TabIndex = 3;
            this.oznakaInfoDvostrukiKlik.Text = "Dvostruko kliknite na redak u tablici kako bi dobili detaljnije informacije o kom" +
    "adu oružja.";
            // 
            // oznakaTip
            // 
            this.oznakaTip.AutoSize = true;
            this.oznakaTip.Location = new System.Drawing.Point(7, 20);
            this.oznakaTip.Name = "oznakaTip";
            this.oznakaTip.Size = new System.Drawing.Size(25, 13);
            this.oznakaTip.TabIndex = 2;
            this.oznakaTip.Text = "Tip:";
            // 
            // comboTip
            // 
            this.comboTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTip.FormattingEnabled = true;
            this.comboTip.Items.AddRange(new object[] {
            "",
            "pištolj",
            "revolver",
            "karabin",
            "bullpup",
            "sačmarica",
            "jurišna puška",
            "snajperska puška",
            "automatska puška (SMG)",
            "strojnica",
            "puška s višestrukom cijevi",
            "bestrzajno oružje",
            "ručni bacač granata"});
            this.comboTip.Location = new System.Drawing.Point(38, 16);
            this.comboTip.Name = "comboTip";
            this.comboTip.Size = new System.Drawing.Size(149, 21);
            this.comboTip.TabIndex = 3;
            // 
            // oznakaSortiranje
            // 
            this.oznakaSortiranje.AutoSize = true;
            this.oznakaSortiranje.Location = new System.Drawing.Point(194, 19);
            this.oznakaSortiranje.Name = "oznakaSortiranje";
            this.oznakaSortiranje.Size = new System.Drawing.Size(54, 13);
            this.oznakaSortiranje.TabIndex = 4;
            this.oznakaSortiranje.Text = "Sortiranje:";
            // 
            // comboSortiranje
            // 
            this.comboSortiranje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSortiranje.FormattingEnabled = true;
            this.comboSortiranje.Items.AddRange(new object[] {
            "",
            "godina proizvodnje - uzlazno",
            "godina proizvodnje - silazno",
            "vrijednost - uzlazno",
            "vrijednost - silazno"});
            this.comboSortiranje.Location = new System.Drawing.Point(254, 16);
            this.comboSortiranje.Name = "comboSortiranje";
            this.comboSortiranje.Size = new System.Drawing.Size(240, 21);
            this.comboSortiranje.TabIndex = 5;
            // 
            // PregledBazeOruzja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 410);
            this.Controls.Add(this.oznakaInfoDvostrukiKlik);
            this.Controls.Add(this.gumbPovratak);
            this.Controls.Add(this.filtriranjeGroupbox);
            this.Controls.Add(this.oruzjeGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PregledBazeOruzja";
            this.Text = "Pregled baze podataka oružja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pregledBazeOruzja_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pregledBazeOruzja_FormClosed);
            this.Load += new System.EventHandler(this.PregledBazeOruzja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oruzjeGridView)).EndInit();
            this.filtriranjeGroupbox.ResumeLayout(false);
            this.filtriranjeGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gumbPovratak;
        private System.Windows.Forms.DataGridView oruzjeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn serijskiBrojColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proizvodacColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipOruzjaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kalibarOruzjaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vrijednostOruzjaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn godinaProizvodnjeOruzjaColumn;
        private System.Windows.Forms.GroupBox filtriranjeGroupbox;
        private System.Windows.Forms.Button gumbPrimijeniFilter;
        private System.Windows.Forms.Button gumbOcistiteFilter;
        private System.Windows.Forms.ComboBox comboTip;
        private System.Windows.Forms.Label oznakaTip;
        private System.Windows.Forms.Label oznakaInfoDvostrukiKlik;
        private System.Windows.Forms.Label oznakaSortiranje;
        private System.Windows.Forms.ComboBox comboSortiranje;
    }
}