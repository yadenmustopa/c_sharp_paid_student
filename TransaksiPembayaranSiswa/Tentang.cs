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
    public partial class Tentang : Form
    {
        public Tentang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tampilkanDashboard();
            keluarTentang();
        }

        private void keluarTentang() {
            this.Close();
        }

        private void tampilkanDashboard() {
            FormDashboard dashboard = new FormDashboard();

            dashboard.Show();
            dashboard.Activate();
        }
    }
}
