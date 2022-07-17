using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLiSinhVien
{
    class Connect
    {
     private static   string str = @"Data Source=DESKTOP-ISGCAJJ;Initial Catalog=QuanLiSinhVien;User ID=sa;Password=sa";
   public static   SqlConnection connect()
        {
            return new SqlConnection(str);
        }
        
    }
}
