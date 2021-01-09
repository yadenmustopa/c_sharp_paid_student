namespace TransaksiPembayaranSiswa
{
    partial class ReportKwitansiDAT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportKwitansiDAT));
            this.buttonOK = new System.Windows.Forms.Button();
            this.crystalReportViewerDAT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
            this.buttonOK.Location = new System.Drawing.Point(957, 453);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(162, 46);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Ke Menu Utama";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // crystalReportViewerDAT
            // 
            this.crystalReportViewerDAT.ActiveViewIndex = -1;
            this.crystalReportViewerDAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerDAT.Location = new System.Drawing.Point(26, 12);
            this.crystalReportViewerDAT.Name = "crystalReportViewerDAT";
            this.crystalReportViewerDAT.SelectionFormula = "";
            this.crystalReportViewerDAT.Size = new System.Drawing.Size(1093, 419);
            this.crystalReportViewerDAT.TabIndex = 1;
            this.crystalReportViewerDAT.ViewTimeSelectionFormula = "";
            // 
            // ReportKwitansiDAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1144, 520);
            this.ControlBox = false;
            this.Controls.Add(this.crystalReportViewerDAT);
            this.Controls.Add(this.buttonOK);
            this.Name = "ReportKwitansiDAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KwitansiDAT";
            this.Load += new System.EventHandler(this.ReportKwitansiDAT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerDAT;
    }
}