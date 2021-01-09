namespace TransaksiPembayaranSiswa
{
    partial class ReportKwitansiDSPT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportKwitansiDSPT));
            this.buttonOK = new System.Windows.Forms.Button();
            this.crystalReportViewerDSPT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(904, 417);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(163, 45);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ke Halaman Utama";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // crystalReportViewerDSPT
            // 
            this.crystalReportViewerDSPT.ActiveViewIndex = -1;
            this.crystalReportViewerDSPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerDSPT.Location = new System.Drawing.Point(21, 24);
            this.crystalReportViewerDSPT.Name = "crystalReportViewerDSPT";
            this.crystalReportViewerDSPT.SelectionFormula = "";
            this.crystalReportViewerDSPT.Size = new System.Drawing.Size(1046, 366);
            this.crystalReportViewerDSPT.TabIndex = 1;
            this.crystalReportViewerDSPT.ViewTimeSelectionFormula = "";
            // 
            // ReportKwitansiDSPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1095, 474);
            this.ControlBox = false;
            this.Controls.Add(this.crystalReportViewerDSPT);
            this.Controls.Add(this.buttonOK);
            this.Name = "ReportKwitansiDSPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportKwitansiDSPT";
            this.Load += new System.EventHandler(this.ReportKwitansiDSPT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerDSPT;
    }
}