using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace TransaksiPembayaranSiswa
{
    public partial class ReportKuitansiDSPB : Form
    {

        Koneksi koneksi = new Koneksi();

        public ReportKuitansiDSPB()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void ReportKuitansiDSPB_Load(object sender, EventArgs e)
        {
            string nis_active = ParameterNisActive.nisActive;

            string query = "SELECT * FROM data_siswa WHERE nis=" + nis_active;

            DataSet ds = koneksi.tampilkanData(query, "reportDSPB");

            DataTable dt = ds.Tables["reportDSPB"];
            CrystalReportKwitansiDSPB1 objRpt = new CrystalReportKwitansiDSPB1();
            objRpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            munculkanDashboard();
            keluarReport();
        }

        private void munculkanDashboard() {
            FormDashboard dashboard = new FormDashboard();
            dashboard.Show();
            dashboard.Activate();
        }

        private void keluarReport() {
            this.Close();
        }
    }
}
