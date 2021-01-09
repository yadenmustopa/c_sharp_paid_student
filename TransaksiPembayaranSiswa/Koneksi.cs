


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TransaksiPembayaranSiswa
{
    class Koneksi
    {
        private OleDbCommand cmd;
        private DataSet ds;
        private OleDbDataAdapter da;
        private OleDbDataReader reader = null;
        //private Koneksi connection = this;


        public OleDbConnection getConnection()
        {
            //menghubungkan ke koneksi database;
            OleDbConnection cn  = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OleDB.4.0;Data source=|DataDirectory|/TA.mdb";
            return cn;
        }

        

        public bool identifikasiData( string tabel, string where ) {
            OleDbConnection conn = this.getConnection();
            try
            {
                conn.Open();
                string query = "SELECT * FROM " + tabel + " WHERE " + where;
                cmd = new OleDbCommand(query, conn);
                reader = cmd.ExecuteReader();

                reader.Read();
                

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                conn.Close();
            }
            finally {
                conn.Close();
            }
          
        }


        public DataSet tampilkanData(string query , string tabel)
        {
            Console.WriteLine(query);
            OleDbConnection conn = this.getConnection();
            conn.Open();
            cmd = new OleDbCommand( query , conn);
            ds  = new DataSet();
            da  = new OleDbDataAdapter(cmd);
            
            da.Fill(ds, tabel);
            conn.Close();
            return ds;
        }


        public void simpanData ( string query, string tabel , string name ) {
            Console.WriteLine(query);
            OleDbConnection conn = this.getConnection();
         
                cmd = new OleDbCommand( query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                if ( name != "" ) {
                    MessageBox.Show(" Data " + name + " sudah disimpan");
                }


           
        }


        public void ubahData( string tabel, string kolom_samadengan_value, string where, string data_dari  )
        {
            OleDbConnection conn = this.getConnection();
            
            try
            {
                cmd = new OleDbCommand("UPDATE " + tabel + " SET " + kolom_samadengan_value + " WHERE " + where, conn);

                conn.Open();
                cmd.ExecuteNonQuery();

                if (data_dari != "") {
                    MessageBox.Show(" Data " + data_dari + " sudah diubah");
                }
                
            }
            catch (Exception reason)
            {
                Console.WriteLine(reason);

            }
            finally {
                conn.Close();
            }

        }



        public void hapusData( string tabel , string where, string name ){
            OleDbConnection conn = this.getConnection();

            try
            {
                cmd = new OleDbCommand("DELETE * FROM " + tabel + " WHERE " + where, conn);
                conn.Open();
                cmd.ExecuteNonQuery();

                if (name != "") {
                    MessageBox.Show("Data " + name + " sudah hapus");
                }
                
            }
            catch (Exception reason)
            {

                Console.WriteLine(reason);
            }
            finally {
                conn.Close();
            }
                

           
        }

        public DataSet cariData( string tabel, string query_search_like ){
            OleDbConnection conn = this.getConnection();
            conn.Open();
            cmd = new OleDbCommand( "SELECT * FROM " + tabel + " where " + query_search_like, conn);
            ds  = new DataSet();
            da  = new OleDbDataAdapter(cmd);

            da.Fill(ds, tabel);
            conn.Close();
            return ds;
            
        }

        public int hitungData( string kolom, string tabel) {
            OleDbConnection conn = this.getConnection();
            conn.Open();

            try
            {
                cmd = new OleDbCommand("SELECT sum (" + kolom + " FROM " + tabel + " AS total", conn);

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception reason)
            {
                Console.WriteLine(reason);
                return 0;
            }
            finally {
                conn.Close();
            }
        }
    }
}
