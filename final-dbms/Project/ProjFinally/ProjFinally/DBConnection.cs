using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjFinally
{
    public class DBConnection
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        public static SqlConnection GetConnection(string user,string pass)
        {
            string connString = @"Data Source=(local)" + ";Initial Catalog=QuanLyCuaHangMyPham"
                        + ";Persist Security Info=True;User ID=" + user + ";Password=" + pass;
            SqlConnection conn = new SqlConnection(connString);
               
            return conn;
        }
        public DBConnection(string name,string pass)
        {
            cnn = GetConnection(name, pass);
            cmd = cnn.CreateCommand();
        }
        string conStr;
        public DBConnection()
        {
            conStr = "Data Source=(local);Initial Catalog=QuanLyCuaHangMyPham;Integrated Security=True";

        }

        public DataSet ExecuteQueryDataSet(
           string strSQL, CommandType ct, params SqlParameter[] p)
        {
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public SqlConnection GetConnection1()
        {
            return new SqlConnection(conStr);
        }


    }
}
