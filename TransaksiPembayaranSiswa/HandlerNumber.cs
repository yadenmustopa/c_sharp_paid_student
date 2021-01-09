using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransaksiPembayaranSiswa
{
    class HandlerNumber
    {

        public int hitungSisa( int nomor_awal, int nomor_akhir ) { 
            int hasil = nomor_awal - nomor_akhir;

            return hasil;
        }
    }
}
