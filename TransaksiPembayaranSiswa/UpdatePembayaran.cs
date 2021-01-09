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
    public partial class UpdatePembayaran : Form
    {

        Koneksi koneksi = new Koneksi();
        
        private string tabel_biaya = "biaya";

        public UpdatePembayaran()
        {
            InitializeComponent();
            awal();
        }


        private void awal() {
            ambilBiayaDSPB();
            ambilBiayaDSPT();
            ambilBiayaDAT();
        }


        private void ambilBiayaDSPB() {
            string query = "SELECT dspb FROM "+ tabel_biaya + " WHERE biaya_id=1";

            DataSet ds = koneksi.tampilkanData(query, tabel_biaya);

            string biaya = ds.Tables[0].Rows[0]["dspb"].ToString();

            tempelkanBiayaDSPB( biaya );
        }

        private void tempelkanBiayaDSPB( string biaya ) {
            biaya = biaya;

            textBiayaDSPB.Text = biaya;
        }

        private void ambilBiayaDSPT() {
            string query = "SELECT dspt FROM " + tabel_biaya + " WHERE biaya_id=1";

            DataSet ds = koneksi.tampilkanData(query, tabel_biaya);

            string biaya = ds.Tables[0].Rows[0]["dspt"].ToString();

            tempelkanBiayaDSPT(biaya);
        }

        private void tempelkanBiayaDSPT(string biaya)
        {
            biaya = biaya;

            textBiayaDSPT.Text = biaya;
        }

        private void ambilBiayaDAT() {
            string query = "SELECT dat FROM " + tabel_biaya + " WHERE biaya_id=1";

            DataSet ds = koneksi.tampilkanData(query, tabel_biaya);

            string biaya = ds.Tables[0].Rows[0]["dat"].ToString();

            tempelkanBiayaDAT(biaya);
        }

        private void tempelkanBiayaDAT(string biaya)
        {
            biaya = biaya;

            textBiayaDAT.Text = biaya;
        }

        private void buttonEditDSPB_Click(object sender, EventArgs e)
        {
            string biaya = textBiayaDSPB.Text;
            string field_value = "dspb="+ biaya;
            string where = "biaya_id=1";
            koneksi.ubahData(tabel_biaya, field_value, where, "Biaya DSPB"); 
        }

        private void buttonEditDSPT_Click(object sender, EventArgs e)
        {
            string biaya = textBiayaDSPT.Text;
            string field_value = "dspt=" + biaya;
            string where = "biaya_id=1";
            koneksi.ubahData(tabel_biaya, field_value, where, "Biaya DSPT"); 
        }

        private void buttonEditDAT_Click(object sender, EventArgs e)
        {
            string biaya = textBiayaDAT.Text;
            string field_value = "dat=" + biaya;
            string where = "biaya_id=1";
            koneksi.ubahData(tabel_biaya, field_value, where, "Biaya DAT"); 
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            munculkanDashboard();
            tutupFormIni();
        }

        private void munculkanDashboard() {
            FormDashboard dashboard = new FormDashboard();

            dashboard.Show();
            dashboard.Activate();
        }

        private void tutupFormIni() {
            this.Close();
        }

        private void textBiayaDSPB_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

        private void textBiayaDAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

        private void textBiayaDSPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

        private void hanyaInputAngka(KeyPressEventArgs e) //hanya boleh input angka
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
