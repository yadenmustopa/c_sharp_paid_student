namespace TransaksiPembayaranSiswa
{
    partial class FormDetailHarian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailHarian));
            this.buttonOK = new System.Windows.Forms.Button();
            this.crystalReportViewerTotal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLaporan = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboKelas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeDari = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeSampai = new System.Windows.Forms.DateTimePicker();
            this.buttonTampilkan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(855, 650);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(156, 43);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ke Menu Utama";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // crystalReportViewerTotal
            // 
            this.crystalReportViewerTotal.ActiveViewIndex = -1;
            this.crystalReportViewerTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerTotal.Location = new System.Drawing.Point(22, 132);
            this.crystalReportViewerTotal.Name = "crystalReportViewerTotal";
            this.crystalReportViewerTotal.SelectionFormula = "";
            this.crystalReportViewerTotal.Size = new System.Drawing.Size(989, 502);
            this.crystalReportViewerTotal.TabIndex = 1;
            this.crystalReportViewerTotal.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Laporan :";
            // 
            // comboLaporan
            // 
            this.comboLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLaporan.FormattingEnabled = true;
            this.comboLaporan.Location = new System.Drawing.Point(86, 31);
            this.comboLaporan.Name = "comboLaporan";
            this.comboLaporan.Size = new System.Drawing.Size(108, 24);
            this.comboLaporan.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboKelas);
            this.groupBox1.Controls.Add(this.comboLaporan);
            this.groupBox1.Location = new System.Drawing.Point(23, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pilih Aksi ::";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(204, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kelas:";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboKelas
            // 
            this.comboKelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKelas.FormattingEnabled = true;
            this.comboKelas.Location = new System.Drawing.Point(255, 29);
            this.comboKelas.Name = "comboKelas";
            this.comboKelas.Size = new System.Drawing.Size(122, 24);
            this.comboKelas.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dari:";
            // 
            // dateTimeDari
            // 
            this.dateTimeDari.CustomFormat = "dd-MM-yyyy";
            this.dateTimeDari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDari.Location = new System.Drawing.Point(64, 28);
            this.dateTimeDari.Name = "dateTimeDari";
            this.dateTimeDari.Size = new System.Drawing.Size(138, 22);
            this.dateTimeDari.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sampai :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dateTimeSampai
            // 
            this.dateTimeSampai.CustomFormat = "dd-MM-yyyy";
            this.dateTimeSampai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeSampai.Location = new System.Drawing.Point(275, 29);
            this.dateTimeSampai.Name = "dateTimeSampai";
            this.dateTimeSampai.Size = new System.Drawing.Size(135, 22);
            this.dateTimeSampai.TabIndex = 5;
            // 
            // buttonTampilkan
            // 
            this.buttonTampilkan.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonTampilkan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTampilkan.Location = new System.Drawing.Point(18, 18);
            this.buttonTampilkan.Name = "buttonTampilkan";
            this.buttonTampilkan.Size = new System.Drawing.Size(79, 45);
            this.buttonTampilkan.TabIndex = 6;
            this.buttonTampilkan.Text = "Tampilkan";
            this.buttonTampilkan.UseVisualStyleBackColor = false;
            this.buttonTampilkan.Click += new System.EventHandler(this.buttonTampilkan_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimeDari);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateTimeSampai);
            this.groupBox2.Location = new System.Drawing.Point(444, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 80);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Periode Waktu ::";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonTampilkan);
            this.groupBox3.Location = new System.Drawing.Point(897, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(113, 80);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Click Aksi::";
            // 
            // FormDetailHarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1034, 705);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewerTotal);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormDetailHarian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReportDetailHarian";
            this.Load += new System.EventHandler(this.FormDetailHarian_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLaporan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimeSampai;
        private System.Windows.Forms.DateTimePicker dateTimeDari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboKelas;
        private System.Windows.Forms.Button buttonTampilkan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}