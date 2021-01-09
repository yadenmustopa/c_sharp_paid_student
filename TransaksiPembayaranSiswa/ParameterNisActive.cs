using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransaksiPembayaranSiswa
{
    class ParameterNisActive
    {
        public static string nis;
        public static string nisActive
        { 
            get { return nis; }
            set { nis = value; }
        }
    }
}
