﻿namespace TransaksiPembayaranSiswa
{
    partial class FormReportDetailBulanan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportDetailBulanan));
            this.buttonOK = new System.Windows.Forms.Button();
            this.crystalReportViewerTotal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPilihLaporan = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(883, 667);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(171, 53);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ke Menu Utama";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click_1);
            // 
            // crystalReportViewerTotal
            // 
            this.crystalReportViewerTotal.ActiveViewIndex = -1;
            this.crystalReportViewerTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerTotal.Location = new System.Drawing.Point(27, 70);
            this.crystalReportViewerTotal.Name = "crystalReportViewerTotal";
            this.crystalReportViewerTotal.SelectionFormula = "";
            this.crystalReportViewerTotal.Size = new System.Drawing.Size(1027, 570);
            this.crystalReportViewerTotal.TabIndex = 1;
            this.crystalReportViewerTotal.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(785, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pilih Laporan :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxPilihLaporan
            // 
            this.comboBoxPilihLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPilihLaporan.FormattingEnabled = true;
            this.comboBoxPilihLaporan.Location = new System.Drawing.Point(914, 29);
            this.comboBoxPilihLaporan.Name = "comboBoxPilihLaporan";
            this.comboBoxPilihLaporan.Size = new System.Drawing.Size(140, 24);
            this.comboBoxPilihLaporan.TabIndex = 3;
            this.comboBoxPilihLaporan.SelectedIndexChanged += new System.EventHandler(this.comboBoxPilihLaporan_SelectedIndexChanged);
            this.comboBoxPilihLaporan.TextChanged += new System.EventHandler(this.comboBoxPilihLaporan_TextChanged);
            // 
            // FormReportDetailBulanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1079, 745);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxPilihLaporan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewerTotal);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormReportDetailBulanan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReportBulanan";
            this.Load += new System.EventHandler(this.FormReportTotalDSPB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPilihLaporan;
    }
}