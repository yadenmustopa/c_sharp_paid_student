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
    public partial class ReportKwitansiDAT : Form
    {
        Koneksi koneksi = new Koneksi();

        public ReportKwitansiDAT()
        {
            InitializeComponent();
        }

        private void ReportKwitansiDAT_Load(object sender, EventArgs e)
        {
            string nis_active = ParameterNisActive.nisActive;

            string str_formula = "";

            str_formula = "{data_siswa.nis} = " + nis_active;

            crystalReportViewerDAT.SelectionFormula = str_formula;
            CrystalReportKwitansiDAT objRpt = new CrystalReportKwitansiDAT();
            crystalReportViewerDAT.ReportSource = objRpt;
            crystalReportViewerDAT.Refresh();
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
            keluarReport();
        }

        private void keluarReport()
        {
            this.Close();
        }
    }
}
