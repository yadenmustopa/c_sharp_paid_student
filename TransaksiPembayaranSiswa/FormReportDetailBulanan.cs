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
    public partial class FormReportDetailBulanan : Form
    {
        public FormReportDetailBulanan()
        {
            InitializeComponent();
        }

        Koneksi koneksi = new Koneksi();

        private void FormReportTotalDSPB_Load(object sender, EventArgs e)
        {
            masukanItemPilihLaporan();
            TampilkanReport();
        }

        private void TampilkanReport() {
            
            if (comboBoxPilihLaporan.Text == "DSPB") {
               
                CrystalReportBulananDSPB objRpt = new CrystalReportBulananDSPB();
                crystalReportViewerTotal.ReportSource = objRpt;
               
            }
            else if (comboBoxPilihLaporan.Text == "DSPT")
            {

                CrystalReportBulananDSPT objRpt = new CrystalReportBulananDSPT();
                crystalReportViewerTotal.ReportSource = objRpt;
            }
            else
            {
                CrystalReportBulananDAT objRpt = new CrystalReportBulananDAT();
                crystalReportViewerTotal.ReportSource = objRpt;
            }
            
            crystalReportViewerTotal.Refresh();
        }

        private void masukanItemPilihLaporan() {
            comboBoxPilihLaporan.Items.Add("DSPB");
            comboBoxPilihLaporan.Items.Add("DSPT");
            comboBoxPilihLaporan.Items.Add("DAT");

            comboBoxPilihLaporan.Text = "DSPB";
        }


        private void buttonOK_Click_1(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxPilihLaporan_TextChanged(object sender, EventArgs e)
        {
            TampilkanReport();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void dateTimeDari_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dateTimeSampai_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void comboBoxPilihLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

    }
}
