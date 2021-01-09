using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TransaksiPembayaranSiswa
{
    public partial class ReportKwitansiDSPT : Form
    {

        Koneksi koneksi = new Koneksi();


        public ReportKwitansiDSPT()
        {
            InitializeComponent();
        }

        private void ReportKwitansiDSPT_Load(object sender, EventArgs e)
        {
            string nis_active = ParameterNisActive.nisActive;

            string str_formula = "";

            str_formula = "{data_siswa.nis} = " + nis_active;

            crystalReportViewerDSPT.SelectionFormula = str_formula;
            CrystalReportKwitansiDSPT objRpt = new CrystalReportKwitansiDSPT();
            crystalReportViewerDSPT.ReportSource = objRpt;
            crystalReportViewerDSPT.Refresh();
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            munculkanDashboard();
            keluarReport();
        }

        private void munculkanDashboard()
        {
            FormDashboard dashboard = new FormDashboard();
            dashboard.Show();
            dashboard.Activate();
        }

        private void keluarReport()
        {
            this.Close();
        }

       
    }
}
