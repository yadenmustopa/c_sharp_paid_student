using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TransaksiPembayaranSiswa
{
    public partial class FormDetailHarian : Form
    {
        public FormDetailHarian()
        {
            InitializeComponent();
        }



        private void masukanItemLaporan() {
            comboLaporan.Items.Add("DSPB");
            comboLaporan.Items.Add("DSPT");
            comboLaporan.Items.Add("DAT");

            comboLaporan.Text = "DSPB";
        }


        private void masukanItemKelas() {
            comboKelas.Items.Add("SEMUA");
            comboKelas.Items.Add("X-A(FARMASI)");
            comboKelas.Items.Add("X-B(FARMASI)");
            comboKelas.Items.Add("X-A(TKJ)");
            comboKelas.Items.Add("X-B(TKJ)");
            comboKelas.Items.Add("XI-A(FARMASI)");
            comboKelas.Items.Add("XI-B(FARMASI)");
            comboKelas.Items.Add("XI-A(TKJ)");
            comboKelas.Items.Add("XI-B(TKJ)");
            comboKelas.Items.Add("XII-A(FARMASI)");
            comboKelas.Items.Add("XII-B(FARMASI)");
            comboKelas.Items.Add("XII-A(TKJ)");
            comboKelas.Items.Add("XII-B(TKJ)");

            comboKelas.Text = "SEMUA";
        }

        private void aturDefaultPeriode(){
            string cek_bulan_sekarang = DateTime.Now.ToString("MM");
            int cek_bulan_berikutnya  = (Int32.Parse(cek_bulan_sekarang)) + 1;
            string tahun_sekarang     = DateTime.Now.ToString("yyyy");

            string bulan_sekarang = getFullName(Int32.Parse(cek_bulan_sekarang));
            string bulan_berikutnya = getFullName(cek_bulan_berikutnya);

            string awal  = "01-" + bulan_sekarang + "-" + tahun_sekarang;
            string akhir = "01-" + bulan_berikutnya + "-" + tahun_sekarang;


            dateTimeDari.Text   = awal;
            dateTimeSampai.Text = akhir;

        }

        static string getFullName(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMMM");
        }  


        private void tampilkanReport() {
            string laporan = comboLaporan.Text;

            if (laporan == "DSPB") 
            {
                tampilkanReportDSPB();
            }
            else if (laporan == "DSPT")
            {
                tampilkanReportDSPT();
            }
            else
            {
                tampilkanReportDAT();
            }
           
        }


        private void tampilkanReportDSPB() {
            string kelas = comboKelas.Text;
            DateTime dari   = dateTimeDari.Value.Date;
            DateTime sampai = dateTimeSampai.Value.Date;

            
            if (kelas != "SEMUA")
            {
                string str_formula = "{data_siswa.kelas} ='"+ kelas +"'"; 
                crystalReportViewerTotal.SelectionFormula = str_formula;
            }

            
           
            CrystalReportHarianDSPB objRpt = new CrystalReportHarianDSPB();

            objRpt.DataDefinition.FormulaFields["MinDate"].Text = "CDate( '" + dari + "');";
            objRpt.DataDefinition.FormulaFields["MaxDate"].Text = "CDate( '" + sampai + "');";


            crystalReportViewerTotal.ReportSource = objRpt;
            crystalReportViewerTotal.Refresh();
        }


        private string[] split( string kata ) {
           char[] charSeparators = new char[] { '-' };

           return kata.Split(charSeparators);
        }


        private void tampilkanReportDSPT() {
            string kelas = comboKelas.Text;
            DateTime dari   = dateTimeDari.Value.Date;
            DateTime sampai = dateTimeSampai.Value.Date;

            
            if (kelas != "SEMUA")
            {
                string str_formula = "{data_siswa.kelas} ='"+ kelas +"'"; 
                crystalReportViewerTotal.SelectionFormula = str_formula;
            }

            CrystalReportHarianDSPT objRpt = new CrystalReportHarianDSPT();

            objRpt.DataDefinition.FormulaFields["MinDate"].Text = "CDate( '" + dari + "');";
            objRpt.DataDefinition.FormulaFields["MaxDate"].Text = "CDate( '" + sampai + "');";


            crystalReportViewerTotal.ReportSource = objRpt;
            crystalReportViewerTotal.Refresh();
        }


        private void tampilkanReportDAT() {
            string kelas = comboKelas.Text;
            DateTime dari = dateTimeDari.Value.Date;
            DateTime sampai = dateTimeSampai.Value.Date;


            if (kelas != "SEMUA")
            {
                string str_formula = "{data_siswa.kelas} ='" + kelas + "'";
                crystalReportViewerTotal.SelectionFormula = str_formula;
            }

            CrystalReportHarianDAT objRpt = new CrystalReportHarianDAT();

            objRpt.DataDefinition.FormulaFields["MinDate"].Text = "CDate( '" + dari + "');";
            objRpt.DataDefinition.FormulaFields["MaxDate"].Text = "CDate( '" + sampai + "');";


            crystalReportViewerTotal.ReportSource = objRpt;
            crystalReportViewerTotal.Refresh();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonTampilkan_Click(object sender, EventArgs e)
        {
            tampilkanReport();
        }

        private void FormDetailHarian_Load(object sender, EventArgs e)
        {
            masukanItemLaporan();
            masukanItemKelas();
            aturDefaultPeriode();
            tampilkanReport();
        }
    }
}
