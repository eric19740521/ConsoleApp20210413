
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using Models;

using System.Text;


namespace test03
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "Server=192.168.1.101;Database=testdb;User Id=SA;Password=<YourNewStrong@Passw0rd>;";

            /*SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "172.17.0.2";
            builder.UserID = "sa";
            builder.Password = "YourNewStrong@Passw0rd";
            builder.InitialCatalog = "testdb";*/



            using (var cn = new SqlConnection(connStr))
            {
                cn.Open();

                string sql = "select * from member ";
                var members = cn.Query<Member>(sql);

                foreach (var _m in members)
                {
                    Console.WriteLine(_m.mem_no+"->"+_m.mem_name);
                }
            }
        }
    }
}







