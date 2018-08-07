using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExamAdo
{
    class Config
    {
        public static string strcon = @"Data Source=MATRIX\S2012;Initial Catalog=GET_Etude;Integrated Security=True";
        public static SqlConnection cnx = new SqlConnection(strcon);
        public static SqlCommand cm = new SqlCommand("", cnx);
        public static DataTable dt = new DataTable();
        public static SqlDataReader dr;
    }
}
