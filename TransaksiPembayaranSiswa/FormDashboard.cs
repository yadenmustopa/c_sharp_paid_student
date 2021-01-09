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
    public partial class FormDashboard : Form
    {
        Koneksi koneksi = new Koneksi();
        string tabel_siswa        = "data_siswa";
        string tabel_dat          = "dat";
        string tabel_dspb         = "dspb";
        string tabel_dspt         = "dspt";
        string tabel_histori_dspb = "history_dspb";
        string tabel_biaya        = "biaya";

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)//dijalankn pas load formDashboard
        {
            radioLaki_Siswa.Checked = true;
            awalSiswa();
            awalDSPB();
            awalDSPT();
            awalDAT();
        }

        private void button_keluar_Click(object sender, EventArgs e)
        {
            keluarDashboard();
        }

        private void keluarDashboard()
        {
            munculkanLogin();
            this.Close();
        }

        private void munculkanLogin()
        {
            FormLogin Login = new FormLogin();

            Login.Show();
            Login.Activate();
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


        private bool cekBayaran(string sisa_sebelumnya, string jumlah_bayar)
        {
            int int_sisa_sebelumnya = Int32.Parse(sisa_sebelumnya);
            int int_jumlah_bayar = Int32.Parse(jumlah_bayar);
            int sisa_sekarang = int_sisa_sebelumnya - int_jumlah_bayar;

            if (sisa_sekarang < 0)
            {
                MessageBox.Show("Pembayaran Anda Melebihi Iuran,Silahkan Masukan dengan benar");
                return false;
            }
            else
            {
                return true;
            }

        }

        private void masukanNilaiNisActive(string nis)
        {

            ParameterNisActive.nisActive = nis;
        }




















       
        //list code page data siswa
        private void awalSiswa()
        {
            masukanItemKelas();

            tampilkanDataSiswa();

            munculPilihanAgama();

            kosongkanInputSiswa();

            aktifkanButtonSimpanSiswa();
            aktifkanTextNisSiswa();

            disableButtonHapusSiswa();
            disableButtonEditSiswa();

            focusKeInputNIS();
        }


        private void masukanItemKelas() {
            textKelas_Siswa.Items.Add("X-A(FARMASI)");
            textKelas_Siswa.Items.Add("X-B(FARMASI)");
            textKelas_Siswa.Items.Add("X-A(TKJ)");
            textKelas_Siswa.Items.Add("X-B(TKJ)");
            textKelas_Siswa.Items.Add("XI-A(FARMASI)");
            textKelas_Siswa.Items.Add("XI-B(FARMASI)");
            textKelas_Siswa.Items.Add("XI-A(TKJ)");
            textKelas_Siswa.Items.Add("XI-B(TKJ)");
            textKelas_Siswa.Items.Add("XII-A(FARMASI)");
            textKelas_Siswa.Items.Add("XII-B(FARMASI)");
            textKelas_Siswa.Items.Add("XII-A(TKJ)");
            textKelas_Siswa.Items.Add("XII-B(TKJ)");
        }


        private void tampilkanDataSiswa(){
            string query = "SELECT * FROM " + tabel_siswa;
            DataSet ds = koneksi.tampilkanData( query , tabel_siswa);
            dataGridView_Siswa.DataSource = ds;
            dataGridView_Siswa.DataMember = tabel_siswa;
            dataGridView_Siswa.AutoResizeColumns();
            dataGridView_Siswa.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

        }


        private void munculPilihanAgama() {
            comboAgamaSiswa.Items.Add("Islam");
            comboAgamaSiswa.Items.Add("Protestan");
            comboAgamaSiswa.Items.Add("Katolik");
            comboAgamaSiswa.Items.Add("Buddha");
            comboAgamaSiswa.Items.Add("Hindu");
            comboAgamaSiswa.Items.Add("Konghucu");

            comboAgamaSiswa.Text = "Islam";
        }

        private void buttonSimpanSiswa_Click(object sender, EventArgs e)
        {
            string nama             = textNama_Siswa.Text;
            string kelas            = textKelas_Siswa.Text;
            string tahun_ajaran     = textTahunAjaran_Siswa.Text;
            string alamat           = textAlamat_Siswa.Text;

            bool cek_validasi = validateSimpanSiswa(nama, kelas, tahun_ajaran, alamat);

            if (cek_validasi)
            {
                simpanDataSiswaDSPB();
                simpanDataSiswa();
            }
            else {
                MessageBox.Show(" Nama , Kelas , Tahun Ajaran , Alamat tidak boleh ada yang kosong ");
            }

        }


        private bool validateSimpanSiswa( string nama, string kelas, string tahun_ajaran, string alamat ) {
            if (nama == "" || kelas == "" || tahun_ajaran == "" || alamat == "")
            {
                return false;
            }
            else {
                return true;
            }
        
        }


        private void simpanDataSiswa() {

            string nis          = textNIS_Siswa.Text;
            string nama         = textNama_Siswa.Text;
            string kelas        = textKelas_Siswa.Text;
            string tahun_ajaran = textTahunAjaran_Siswa.Text;
            string tempat_lahir = textTempatLAhir_siswa.Text;
            string agama        = comboAgamaSiswa.Text;
            string no_hp        = textNoHp_Siswa.Text;
            string alamat       = textAlamat_Siswa.Text;

            DateTime tanggal_lahir = textTanggalLahirSiswa.Value;

            string jenis_kelamin;

            if (radioLaki_Siswa.Checked == true)
            {
                jenis_kelamin = "Laki-Laki";
            }
            else
            {
                jenis_kelamin = "Perempuan";
            }

            string query = "INSERT INTO "+ tabel_siswa +" VALUES (" + nis + ",'" + nama ;

            query += "','" + kelas + "','" + jenis_kelamin + "','" + tahun_ajaran + "','" + tempat_lahir;
            query +=  "','" + tanggal_lahir.ToString() + "','" + agama + "'," + no_hp + ",'" + alamat+ "' )";

            koneksi.simpanData( query, tabel_siswa, "Siswa");

            awalSiswa();
        
        }

        private void simpanDataSiswaDSPB() {
            string nis = textNIS_Siswa.Text;

            string query = "INSERT INTO " + tabel_dspb + " ( nis,jul,agust,sept,okt,nov,des,jan,feb,mar,apr,mei,jun ) VALUES (" + nis;
 
            query += ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)";

            koneksi.simpanData( query, tabel_dspb, "");
        }



        private void kosongkanInputSiswa() {

            textNIS_Siswa.Text          = "";
            textNama_Siswa.Text         = "";
            textKelas_Siswa.Text        = "";
            textTahunAjaran_Siswa.Text  = "";
            textTempatLAhir_siswa.Text  = "";
            comboAgamaSiswa.Text        = "Islam";
            textNoHp_Siswa.Text         = "";
            textAlamat_Siswa.Text       = "";
        }

        private void dataGridView_Siswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row         = this.dataGridView_Siswa.Rows[e.RowIndex];
                textNama_Siswa.Text         = row.Cells["nama"].Value.ToString();
                textNIS_Siswa.Text          = row.Cells["nis"].Value.ToString();
                textKelas_Siswa.Text        = row.Cells["kelas"].Value.ToString();
                textTahunAjaran_Siswa.Text  = row.Cells["tahun_ajaran"].Value.ToString();
                string jenis_kelamin        = row.Cells["jenis_kelamin"].Value.ToString();

                if (jenis_kelamin == "Laki-Laki")
                {
                    radioLaki_Siswa.Checked      = true;
                    radioPerempuan_Siswa.Checked = false;
                }
                else
                {
                    radioLaki_Siswa.Checked      = false;
                    radioPerempuan_Siswa.Checked = true;
                }

                masukanNilaiTabelKeInput( row );

                disableButtonSimpanSiswa();
                disableTextNisSiswa();

                aktifkanButtonHapusSiswa();
                aktifkanButtonEditSiswa();
                


            }
            catch ( Exception reason ){
                MessageBox.Show("Pilih data Kolom yang ada");
                Console.WriteLine(reason);
            }
        }

        private void masukanNilaiTabelKeInput( DataGridViewRow row){

            textTempatLAhir_siswa.Text = row.Cells["tempat_lahir"].Value.ToString();
            textTanggalLahirSiswa.Text = row.Cells["tanggal_lahir"].Value.ToString();
            comboAgamaSiswa.Text       = row.Cells["agama"].Value.ToString();
            textNoHp_Siswa.Text        = row.Cells["no_hp"].Value.ToString();
            textAlamat_Siswa.Text      = row.Cells["alamat"].Value.ToString();

        }

        private void ubahDataSiswa(object sender, EventArgs e)
        {
            string nis = textNIS_Siswa.Text;
            string nama = textNama_Siswa.Text;
            string kelas = textKelas_Siswa.Text;
            string tahun_ajaran = textTahunAjaran_Siswa.Text;
            string tempat_lahir = textTempatLAhir_siswa.Text;
            string agama = comboAgamaSiswa.Text;
            string no_hp = textNoHp_Siswa.Text;
            string alamat = textAlamat_Siswa.Text;

            string jenis_kelamin;
            if (radioLaki_Siswa.Checked == true)
            {
                jenis_kelamin = "Laki-Laki";
            }
            else
            {
                jenis_kelamin = "Perempuan";
            }

            DateTime tanggal_lahir = textTanggalLahirSiswa.Value;

            string set = "nama = '" + nama + "', kelas = '" + kelas + "', jenis_kelamin ='"+ jenis_kelamin + "', tahun_ajaran = '" + tahun_ajaran;

            set += "', tempat_lahir = '" + tempat_lahir + "', agama = '" + agama + "', no_hp = " + no_hp + ", alamat = '" + alamat + "'";

            string where = "nis =" + nis;

            koneksi.ubahData(tabel_siswa, set, where, "siswa");

            awalSiswa();
        }

        private void buttonBatalSiswa_Click(object sender, EventArgs e)
        {
            awalSiswa();
        }

        private void focusKeInputNIS() {
            textNIS_Siswa.Focus();
        }

        private void buttonHapus_Siswa_Click(object sender, EventArgs e)
        {
            string nis = textNIS_Siswa.Text;
            string pengingat = "Apakah anda Yakin Menghapus data NIS" + nis + " ?";
            if (MessageBox.Show(pengingat, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                hapusDataSiswaDSPB(nis);
                hapusHistoriSiswaDSPB(nis);
                hapusDataSiswaDSPT(nis);
                hapusDataSiswaDAT(nis);
                hapusDataSiswa(nis);
            }

        }

        private void hapusDataSiswa( string nis ) {
            koneksi.hapusData(tabel_siswa, "nis=" + nis, "nis " + nis);

            awalSiswa();
        }


        private void hapusDataSiswaDSPB( string nis ) {
            koneksi.hapusData(tabel_dspb, "nis=" + nis, "");
        }

        private void hapusHistoriSiswaDSPB(string nis)
        {
            koneksi.hapusData(tabel_histori_dspb, "nis=" + nis, "nis " + nis);
        }

        private void hapusDataSiswaDSPT( string nis ) {
            koneksi.hapusData(tabel_dspt, "nis=" + nis, "");
        }       
        
        private void hapusDataSiswaDAT( string nis ) {
            koneksi.hapusData(tabel_dat, "nis=" + nis, "");
        }


        private void textCari_Siswa_TextChanged(object sender, EventArgs e)
        {
            cariSiswa();
        }

        private void cariSiswa() {
            string inputan  = textCari_Siswa.Text;
            string query = "";

            bool inputan_hanya_angka = isinyaHanyaAngka( inputan );
            Console.WriteLine("Hasil Inputan " + inputan_hanya_angka);
            if (inputan_hanya_angka)
            {
                query = "nis like '%" + Int32.Parse( inputan ) + "%'" ;
            }
            else {
                query = "nama like '%" + inputan + "%'";
            }

            DataSet ds = koneksi.cariData(tabel_siswa, query);
 
            dataGridView_Siswa.DataSource = ds;
            dataGridView_Siswa.DataMember = tabel_siswa;
            dataGridView_Siswa.AutoResizeColumns();
            //dataGridHistoriDSPB.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        private bool isinyaHanyaAngka(string inputan) { 
            
            int parsedValue;

            if (!int.TryParse( inputan , out parsedValue))
            {
                return false;
            }
            else {
                return true;
            }
        }

        private void textNIS_Siswa_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

        private void disableButtonSimpanSiswa()
        {
            buttonSimpan_Siswa.Enabled = false;
        }

        private void aktifkanButtonSimpanSiswa()
        {
            buttonSimpan_Siswa.Enabled = true;
        }

        private void disableButtonEditSiswa()
        {
            buttonEdit_Siswa.Enabled = false;
        }

        private void aktifkanButtonEditSiswa()
        {
            buttonEdit_Siswa.Enabled = true;
        }

        private void disableButtonHapusSiswa()
        {
            buttonHapus_Siswa.Enabled = false;
        }

        private void aktifkanButtonHapusSiswa()
        {
            buttonHapus_Siswa.Enabled = true;
        }

        private void disableTextNisSiswa()
        {
            textNIS_Siswa.Enabled = false;
        }

        private void aktifkanTextNisSiswa()
        {
            textNIS_Siswa.Enabled = true;
        }



















        //list code page DSPB---------------------------------------------------
        private void awalDSPB()
        {
            sembunyikanHistoriDSPB();
            textCariDSPB.Text = "";
            munculkanCaraDSPB();
        }


        private void textCariDSPB_TextChanged(object sender, EventArgs e)
        {
            sembunyikanHistoriDSPB();
            munculkanCaraDSPB();

            string inputan = textCariDSPB.Text;
            string query = "";

            bool inputan_hanya_angka = isinyaHanyaAngka(inputan);
            Console.WriteLine("Hasil Inputan " + inputan_hanya_angka);
            if (inputan_hanya_angka)
            {
                query = "nis like '%" + Int32.Parse(inputan) + "%'";
            }
            else
            {
                query = "nama like '%" + inputan + "%'";
            }

            DataSet ds = koneksi.cariData(tabel_siswa, query);
            dataGridCariDSPB.DataSource = ds;
            dataGridCariDSPB.DataMember = tabel_siswa;
            dataGridCariDSPB.AutoResizeColumns();
           
        }

        private void dataGridCariDSPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int nis;
                DataGridViewRow row = this.dataGridCariDSPB.Rows[e.RowIndex];

                string nis_row = row.Cells["nis"].Value.ToString();

                Int32.TryParse(nis_row, out nis);

                manageHistoriDSPB(nis);
                rubahJumlahSudahBayarDSPB(nis);
                munculkanHistoriDSPB();
                sembunyikanCaraDSPB();
                tempelkanBiayaDSPB();
            }
            catch (Exception) { 
            
            }
                

        }

        private void manageHistoriDSPB( int nis ) {
                
            string query = "SELECT tanggal_pembayaran , sebanyak FROM " + tabel_histori_dspb + " WHERE nis=" + nis;

            DataSet ds = koneksi.tampilkanData(query, tabel_histori_dspb);
            dataGridHistoriDSPB.DataSource = ds;
            dataGridHistoriDSPB.DataMember = tabel_histori_dspb;
            dataGridHistoriDSPB.AutoResizeColumns();
            dataGridHistoriDSPB.Columns[0].DefaultCellStyle.Format = "dd-MM-yyyy";

            ambilDataDSPB( nis );


            identitasHistoriSiswaDSPB( nis );
            tampilkanDataSiswa();
        }

        private void identitasHistoriSiswaDSPB( int nis ) { 
            string query = "SELECT nis,nama,kelas FROM " + tabel_siswa + " WHERE nis="+ nis;
            DataSet ds   = koneksi.tampilkanData(query, tabel_siswa);
           
            int value_nis      = Convert.ToInt32(ds.Tables[0].Rows[0]["nis"]);
            string value_nama  = ds.Tables[0].Rows[0]["nama"].ToString();
            string value_kelas = ds.Tables[0].Rows[0]["kelas"].ToString();

            textHistoriNis.Text   = value_nis.ToString();
            textHistoriNama.Text  = value_nama;
            textHistoriKelas.Text = value_kelas;

        }

        private void ambilDataDSPB( int nis ) {
            string query = "SELECT jul,agust,sept,okt,nov,des,jan,feb,mar,apr,mei,jun FROM " + tabel_dspb + " WHERE nis=" + nis;

            DataSet ds = koneksi.tampilkanData(query, tabel_dspb);

            manageDataDSPB( ds );
            
        }

        private void manageDataDSPB( DataSet ds){
            
            string bul_jul    = ds.Tables[0].Rows[0]["jul"].ToString();
            string bul_agust  = ds.Tables[0].Rows[0]["agust"].ToString();
            string bul_sept   = ds.Tables[0].Rows[0]["sept"].ToString();
            string bul_okt    = ds.Tables[0].Rows[0]["okt"].ToString();
            string bul_nov    = ds.Tables[0].Rows[0]["nov"].ToString();
            string bul_des    = ds.Tables[0].Rows[0]["des"].ToString();
            string bul_jan    = ds.Tables[0].Rows[0]["jan"].ToString();
            string bul_feb    = ds.Tables[0].Rows[0]["feb"].ToString();
            string bul_mar    = ds.Tables[0].Rows[0]["mar"].ToString();
            string bul_apr    = ds.Tables[0].Rows[0]["apr"].ToString();
            string bul_mei    = ds.Tables[0].Rows[0]["mei"].ToString();
            string bul_jun    = ds.Tables[0].Rows[0]["jun"].ToString();

            juli.Checked        = Convert.ToBoolean(bul_jul);
            agustus.Checked     = Convert.ToBoolean(bul_agust);
            september.Checked   = Convert.ToBoolean(bul_sept);
            oktober.Checked     = Convert.ToBoolean(bul_okt);
            november.Checked    = Convert.ToBoolean(bul_nov);
            desember.Checked    = Convert.ToBoolean(bul_des);
            januari.Checked     = Convert.ToBoolean(bul_jan);
            februari.Checked    = Convert.ToBoolean(bul_feb);
            maret.Checked       = Convert.ToBoolean(bul_mar);
            april.Checked       = Convert.ToBoolean(bul_apr);
            mei.Checked         = Convert.ToBoolean(bul_mei);
            juni.Checked        = Convert.ToBoolean(bul_jun);

        }

        private void rubahJumlahSudahBayarDSPB(int nis) {

            string jumlah = hitungJumlahHistoriBayarDSPB( nis );
            int sisa      = (12 - Convert.ToInt32(jumlah));
            labelSudahBayarDSPB.Text = jumlah+"X";
            labelSisaDSPB.Text       = sisa.ToString()+"X";
        }

        private string hitungJumlahHistoriBayarDSPB( int nis) {
            string query = "SELECT SUM(sebanyak) as jumlah FROM " + tabel_histori_dspb + " WHERE nis=" + nis;
            DataSet ds = koneksi.tampilkanData(query, tabel_histori_dspb);
            string jumlah;

            string sum = ds.Tables[0].Rows[0]["jumlah"].ToString();

            if (sum != "")
            {
                jumlah = sum;
            }
            else
            {
                jumlah = "0";
            }

            return jumlah;
        }


        private void tempelkanBiayaDSPB() {
            string biaya_DSPB      = ambilBiayaDSPB();
            labelDSPBperBulan.Text = "Rp." + biaya_DSPB;
        }

        private string ambilBiayaDSPB() {
            string query = "SELECT dspb  FROM "+ tabel_biaya + " WHERE biaya_id=1";
            DataSet ds = koneksi.tampilkanData(query, tabel_biaya );

            string biaya_DSPB;

            if( ds.Tables[0].Rows.Count > 0 ){
                biaya_DSPB = ds.Tables[0].Rows[0]["dspb"].ToString();
            }else{
                biaya_DSPB = "0";
            }

            return biaya_DSPB;
        }

        private void buttonSimpanDSPB_Click_1(object sender, EventArgs e)
        {
            int jumlah_bayar_iuran_baru = hitungJumlahMasukIuran();
            string nis = textHistoriNis.Text;

            masukanNilaiNisActive( nis );
            simpanDataDSPB(jumlah_bayar_iuran_baru);
            bukaReportKuitansiDSPB();
            awalDSPB();
        }

 


        private int hitungJumlahMasukIuran() {

            string nis_histori = textHistoriNis.Text;
            int nis            = Convert.ToInt32(nis_histori);

            string hitung_jumlah_iuran_dulu = hitungJumlahHistoriBayarDSPB( nis );

            int jumlah_ceklist       = hitungJumlahChecklistDSPB();

            int jumlah_iuran_dulu        = Convert.ToInt32(hitung_jumlah_iuran_dulu);

            int hasil = jumlah_ceklist - jumlah_iuran_dulu;

            return hasil;
        }

        private int hitungJumlahChecklistDSPB(){
            CheckBox[] bulans = { juli, agustus, september, oktober,november, desember, januari, februari, maret,april, mei, juni };

            int chechked = 0;
            foreach (CheckBox bulan in bulans) {
                if ( bulan.Checked == true) {
                    chechked += 1;
                }
            }

            return chechked;
        }

        private void simpanDataDSPB( int banyak_bayar_iuran ) {
            string nis_histori = textHistoriNis.Text;
            int nis = Convert.ToInt32(nis_histori);

            bool bul_jul = juli.Checked;
            bool bul_agust = agustus.Checked;
            bool bul_sept = september.Checked;
            bool bul_okt = oktober.Checked;
            bool bul_nov = november.Checked;
            bool bul_des = desember.Checked;
            bool bul_jan = januari.Checked;
            bool bul_feb = februari.Checked;
            bool bul_mar = maret.Checked;
            bool bul_apr = april.Checked;
            bool bul_mei = mei.Checked;
            bool bul_jun = juni.Checked;

            string query = "jul=" + bul_jul + ",agust=" + bul_agust + ",sept=" + bul_sept;
            query += ",okt=" + bul_okt + ",nov=" + bul_nov + ",des=" + bul_des + ",jan=" + bul_jan;
            query += ",feb=" + bul_feb + ",mar=" + bul_mar + ",apr=" + bul_apr+ ",mei=" + bul_mei;
            query += ",jun=" + bul_jun;

            koneksi.ubahData(tabel_dspb, query, "nis=" + nis, "");

            simpanKeHistoriDSPB( nis, banyak_bayar_iuran );
        }

        private void simpanKeHistoriDSPB( int nis, int banyak_bayar_iuran ) { 
            string tanggal_sekarang = DateTime.Now.ToString("dd-MM-yyyy");
            string query = "INSERT INTO "+ tabel_histori_dspb +" (nis,tanggal_pembayaran,sebanyak) VALUES (" + nis + ",'" + tanggal_sekarang + "'," + banyak_bayar_iuran + ")"; 

            koneksi.simpanData(query, tabel_histori_dspb, "DSPB");
        }


        private void bukaReportKuitansiDSPB(){
            ReportKuitansiDSPB report = new ReportKuitansiDSPB();

            report.Show();
            report.Activate();
            this.Hide();
        }

        private void buttonBatalDSPB_Click_1(object sender, EventArgs e)
        {
            awalDSPB();
        }

        private void buttonBatalDSPB_Click(object sender, EventArgs e)
        {
            awalDSPB();
        }

        private void textNoHp_Siswa_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

        private void sembunyikanHistoriDSPB(){
            groupHistoriDSPB.Visible = false;
        }
        
        private void munculkanHistoriDSPB(){
            groupHistoriDSPB.Visible = true;
        }

        private void sembunyikanCaraDSPB(){
            groupCaraDSPB.Visible = false;
        }
        
        private void munculkanCaraDSPB(){
            groupCaraDSPB.Visible = true;
        }
        private void ambilTotalDSPB() { 
        
        }














        //list code page DPST----------------------------------------
        private void textCariDSPT_TextChanged(object sender, EventArgs e)
        {
            sembunyikanHistoriDSPT();
            munculkanCaraDSPT();

            string inputan = textCariDSPT.Text;
            string query = "";

            bool inputan_hanya_angka = isinyaHanyaAngka(inputan);
            

            if (inputan_hanya_angka)
            {
                query = "nis like '%" + Int32.Parse(inputan) + "%'";
            }
            else
            {
                query = "nama like '%" + inputan + "%'";
            }

            DataSet ds = koneksi.cariData(tabel_siswa, query);
            dataGridCariDSPT.DataSource = ds;
            dataGridCariDSPT.DataMember = tabel_siswa;
            dataGridCariDSPT.AutoResizeColumns();
        }


        private void dataGridCariDSPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int nis;
                DataGridViewRow row = this.dataGridCariDSPT.Rows[e.RowIndex];

                string nis_row = row.Cells["nis"].Value.ToString();

                Int32.TryParse(nis_row, out nis);


                manageHistoriDSPT(nis);
                rubahJumlahSudahBayarDSPT(nis);
                munculkanHistoriDSPT();
                sembunyikanCaraDSPT();
                tempelkanBiayaDSPT();

            }
            catch (Exception)
            {

            }
        }

        private void manageHistoriDSPT(int nis)
        {

            string query = "SELECT tanggal_bayar , jumlah_bayar FROM " + tabel_dspt + " WHERE nis=" + nis;

            DataSet ds = koneksi.tampilkanData(query, tabel_dspt);
            dataGridHistoriDSPT.DataSource = ds;
            dataGridHistoriDSPT.DataMember = tabel_dspt;
            dataGridHistoriDSPT.AutoResizeColumns();
            dataGridHistoriDSPT.Columns[0].DefaultCellStyle.Format = "dd-MM-yyyy";

            identitasHistoriSiswaDSPT(nis);
            tampilkanDataSiswa();
        }


        private void identitasHistoriSiswaDSPT(int nis)
        {
            string query = "SELECT nis,nama,kelas FROM " + tabel_siswa + " WHERE nis=" + nis;
            DataSet ds   = koneksi.tampilkanData(query, tabel_siswa);

            int value_nis      = Convert.ToInt32(ds.Tables[0].Rows[0]["nis"]);
            string value_nama  = ds.Tables[0].Rows[0]["nama"].ToString();
            string value_kelas = ds.Tables[0].Rows[0]["kelas"].ToString();

            labelHistoriNisDSPT.Text   = value_nis.ToString();
            labelHistoriNamaDSPT.Text  = value_nama;
            labelHistoriKelasDSPT.Text = value_kelas;

        }

        private void rubahJumlahSudahBayarDSPT(int nis)
        {

            string jumlah = hitungJumlahHistoriBayarDSPT(nis);
            string total  = ambilBiayaDSPT();
            int sisa      = (Convert.ToInt32(total) - Convert.ToInt32(jumlah));

            if (sisa == 0)
            {
                lunasDSPT();
                labelSisaDSPT.Text = "Rp.0  (LUNAS)";
            }
            else {
                
                labelSisaDSPT.Text = "Rp." + sisa.ToString();
            }
            labelSudahBayarDSPT.Text = "Rp." + jumlah;
        }

        private void lunasDSPT() {
            textBayarDSPT.Enabled = false;
        }

        private string hitungJumlahHistoriBayarDSPT(int nis)
        {
            string query = "SELECT SUM(jumlah_bayar) as jumlah FROM " + tabel_dspt + " WHERE nis=" + nis;
            DataSet ds = koneksi.tampilkanData(query, tabel_dspt);
            string jumlah;

            string sum = ds.Tables[0].Rows[0]["jumlah"].ToString();

            if (sum != "")
            {
                jumlah = sum;
            }
            else
            {
                jumlah = "0";
            }

            return jumlah;
        }

        private void tempelkanBiayaDSPT() {
            string biaya_DSPT   = ambilBiayaDSPT();

            labelTotalDSPT.Text = "Rp." + biaya_DSPT;
        }


        private string ambilBiayaDSPT()
        {
            string query = "SELECT dspt  FROM " + tabel_biaya + " WHERE biaya_id=1";
            DataSet ds   = koneksi.tampilkanData(query, tabel_biaya);

            string biaya_DSPT;

            if (ds.Tables[0].Rows.Count > 0)
            {
                biaya_DSPT = ds.Tables[0].Rows[0]["dspt"].ToString();
            }
            else
            {
                biaya_DSPT = "0";
            }

            return biaya_DSPT;
        }

     

        private void buttonSimpanDSPT_Click(object sender, EventArgs e)
        {
            string sisa_sebelumnya = labelSisaDSPT.Text.Remove(0,3);
            string jumlah_bayar    = textBayarDSPT.Text;

            bool cek_bayaran_tidak_melebihi = cekBayaran( sisa_sebelumnya, jumlah_bayar );

            if (cek_bayaran_tidak_melebihi)
            {
                simpanBayarDSPT(jumlah_bayar);
            }
            else {
                textBayarDSPT.Text = "";
            }
            
        }


        private void simpanBayarDSPT( string jumlah_bayar ) {
            string nis = labelHistoriNisDSPT.Text;
            string tanggal_sekarang = DateTime.Now.ToString("dd-MM-yyyy");

            masukanNilaiNisActive(nis);
            
            string query = "INSERT INTO "+ tabel_dspt+" ( nis,tanggal_bayar, jumlah_bayar ) VALUES ("+nis+",'"+ tanggal_sekarang+"',"+jumlah_bayar +")";
            
            koneksi.simpanData(query, tabel_dspt, "Pembayaran DSPT");
            awalDSPT();
            bukaReportKwitansiDSPT();
        }

        private void bukaReportKwitansiDSPT()
        {
            ReportKwitansiDSPT report = new ReportKwitansiDSPT();

            report.Show();
            report.Activate();
            this.Hide();
        }

        private void sembunyikanHistoriDSPT()
        {
            groupHistoriDSPT.Visible = false;
        }

        private void munculkanHistoriDSPT()
        {
            groupHistoriDSPT.Visible = true;
        }

        private void sembunyikanCaraDSPT()
        {
            groupCaraDSPT.Visible = false;
        }

        private void munculkanCaraDSPT()
        {
            groupCaraDSPT.Visible = true;
        }

        private void awalDSPT(){
            sembunyikanHistoriDSPT();
            textCariDSPT.Text = "";
            textBayarDSPT.Text = "";
            textBayarDSPT.Enabled = true;
            munculkanCaraDSPT();
        }

        private void buttonBatalDSPT_Click(object sender, EventArgs e)
        {
            awalDSPT();
        }

        private void textBayarDSPB_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

      














        //list code page DAT=--------------------------------------------
        private void textCariDAT_TextChanged(object sender, EventArgs e)
        {
            sembunyikanHistoriDAT();
            munculkanCaraDAT();

            string inputan = textCariDAT.Text;
            string query = "";

            bool inputan_hanya_angka = isinyaHanyaAngka(inputan);
            

            if (inputan_hanya_angka)
            {
                query = "nis like '%" + Int32.Parse(inputan) + "%'";
            }
            else
            {
                query = "nama like '%" + inputan + "%'";
            }

            DataSet ds = koneksi.cariData(tabel_siswa, query);
            dataGridCariDAT.DataSource = ds;
            dataGridCariDAT.DataMember = tabel_siswa;
            dataGridCariDAT.AutoResizeColumns();
        }


        private void dataGridCariDAT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //awalDAT();

            try
            {
                int nis;
                DataGridViewRow row = this.dataGridCariDAT.Rows[e.RowIndex];

                string nis_row = row.Cells["nis"].Value.ToString();

                Int32.TryParse(nis_row, out nis);


                manageHistoriDAT(nis);
                rubahJumlahSudahBayarDAT(nis);
                munculkanHistoriDAT();
                sembunyikanCaraDAT();
                tempelkanBiayaDAT();

            }
            catch (Exception)
            {

            }
        }


        private void manageHistoriDAT(int nis)
        {
            string query = "SELECT tanggal_bayar,jumlah_bayar FROM " + tabel_dat + " WHERE nis=" + nis;

            DataSet ds = koneksi.tampilkanData(query, tabel_dat);
            dataGridHistoriDAT.DataSource = ds;
            dataGridHistoriDAT.DataMember = tabel_dat;
            dataGridHistoriDAT.AutoResizeColumns();
            dataGridHistoriDAT.Columns[0].DefaultCellStyle.Format = "dd-MM-yyyy";

            identitasHistoriSiswaDAT(nis);
            tampilkanDataSiswa();
        }


        private void rubahJumlahSudahBayarDAT(int nis)
        {

            string jumlah = hitungJumlahHistoriBayarDAT(nis);
            string total  = ambilBiayaDAT();
            int sisa = (Convert.ToInt32(total) - Convert.ToInt32(jumlah));

            if (sisa == 0)
            {
                lunasDAT();
                labelSisaTunggakDAT.Text = "Rp.0  (LUNAS)";
            }
            else
            {

                labelSisaTunggakDAT.Text = "Rp." + sisa.ToString();
            }
            labelSudahBayarDAT.Text = "Rp." + jumlah;
        }

        
        private void lunasDAT()
        {
            textBayarDAT.Enabled = false;
        }

        private string hitungJumlahHistoriBayarDAT(int nis)
        {
            string query = "SELECT SUM(jumlah_bayar) as jumlah FROM " + tabel_dat + " WHERE nis=" + nis;
            DataSet ds = koneksi.tampilkanData(query, tabel_dat);
            string jumlah;

            string sum = ds.Tables[0].Rows[0]["jumlah"].ToString();

            if (sum != "")
            {
                jumlah = sum;
            }
            else
            {
                jumlah = "0";
            }

            return jumlah;
        }


        private string ambilBiayaDAT()
        {
            string query = "SELECT dat  FROM " + tabel_biaya + " WHERE biaya_id=1";
            DataSet ds = koneksi.tampilkanData(query, tabel_biaya);

            string biaya_DAT;

            if (ds.Tables[0].Rows.Count > 0)
            {
                biaya_DAT = ds.Tables[0].Rows[0]["dat"].ToString();
            }
            else
            {
                biaya_DAT = "0";
            }

            return biaya_DAT;
        }


        private void tempelkanBiayaDAT()
        {
            string biaya_DAT = ambilBiayaDAT();

            labelTotalDAT.Text = "Rp." + biaya_DAT;
        }


        private void identitasHistoriSiswaDAT(int nis)
        {
            string query = "SELECT nis,nama,kelas FROM " + tabel_siswa + " WHERE nis=" + nis;
            DataSet ds = koneksi.tampilkanData(query, tabel_siswa);

            int value_nis      = Convert.ToInt32(ds.Tables[0].Rows[0]["nis"]);
            string value_nama  = ds.Tables[0].Rows[0]["nama"].ToString();
            string value_kelas = ds.Tables[0].Rows[0]["kelas"].ToString();

            labelHistoriNisDAT.Text   = value_nis.ToString();
            labelHistoriNamaDAT.Text  = value_nama;
            labelHistoriKelasDAT.Text = value_kelas;

        }


        private void textBayarDAT_TextChanged(object sender, EventArgs e)
        {
        }


        private void buttonSimpanDat_Click(object sender, EventArgs e)
        {
            string sisa_sebelumnya = labelSisaTunggakDAT.Text.Remove(0,3);
            string jumlah_bayar = textBayarDAT.Text;

            bool cek_bayaran_tidak_melebihi = cekBayaran(sisa_sebelumnya, jumlah_bayar);

            if (cek_bayaran_tidak_melebihi)
            {
                simpanBayarDAT(jumlah_bayar);
            }
            else
            {
                textBayarDAT.Text = "";
            }
            
        }


        private void simpanBayarDAT(string jumlah_bayar)
        {
            string nis = labelHistoriNisDAT.Text;
            string tanggal_sekarang = DateTime.Now.ToString("dd-MM-yyyy");

            masukanNilaiNisActive(nis);

            string query = "INSERT INTO " + tabel_dat + " ( nis,tanggal_bayar, jumlah_bayar ) VALUES (" + nis + ",'" + tanggal_sekarang + "'," + jumlah_bayar + ")";

            koneksi.simpanData(query, tabel_dat, "Pembayaran DAT");

            awalDAT();

            bukaReportKwitansiDAT();
        }

        private void bukaReportKwitansiDAT()
        {
            ReportKwitansiDAT report = new ReportKwitansiDAT();

            report.Show();
            report.Activate();
            this.Hide();
        }



        private void buttonBatalDAT_Click(object sender, EventArgs e)
        {
            awalDAT();
        }


        private void textBayarDAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            hanyaInputAngka(e);
        }

        private void awalDAT()
        {
            sembunyikanHistoriDAT();
            textCariDAT.Text        = "";
            textBayarDAT.Text       = "";
            textBayarDAT.Enabled    = true;
            munculkanCaraDAT();
        }

        private void sembunyikanHistoriDAT()
        {
            groupHistoriDAT.Visible = false;
        }

        private void munculkanHistoriDAT()
        {
            groupHistoriDAT.Visible = true;
        }

        private void sembunyikanCaraDAT()
        {
            groupCaraDAT.Visible = false;
        }

        private void munculkanCaraDAT()
        {
            groupCaraDAT.Visible = true;
        }

        //buka tentang aplikasi
        private void button_tentangAplikasi_Click(object sender, EventArgs e)
        {
            Tentang form_tentang = new Tentang();
            form_tentang.Show();
            this.Hide();
        }

        //buka pengaturan biaya

        private void buttonPengaturanBiaya_Click(object sender, EventArgs e)
        {
            UpdatePembayaran update_biaya = new UpdatePembayaran();

            update_biaya.Show();
            update_biaya.Activate();
            this.Hide();
        }

        //buka report dspb

        private void button_laporanDSPB_Click(object sender, EventArgs e)
        {
            FormReportDetailBulanan formReportTotalDSPB = new FormReportDetailBulanan();

            formReportTotalDSPB.Show();
            formReportTotalDSPB.Activate();
            this.Hide();
        }

        //buka report total dspt

        private void button_laporanDSPT_Click(object sender, EventArgs e)
        {
             FormDetailHarian formReportTotalDSPT = new FormDetailHarian();

            formReportTotalDSPT.Show();
            formReportTotalDSPT.Activate();
            this.Hide();
        }

        







        
       
        //list code group laporan

        //list code group utilities

        //list code keluar
      


  
    }
}
