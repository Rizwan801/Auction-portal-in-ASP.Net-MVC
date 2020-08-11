using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace auction_portal.DAL
{
    public sealed class SqlHelper
    {

    
        //public static int SaveData(SqlConnection conn, string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandparameters)
        //{
        //using (SqlConnection con= new SqlConnection(connectionString))
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = commandType;
        //    cmd.CommandText = commandText;

        //    for (int i = 0; i < commandparameters.Length; i++)
        //    {
        //        cmd.Parameters.Add(commandparameters[i]);
        //    }
        //    cmd.Connection = con;
        //    return cmd.ExecuteNonQuery();

        //}
        
        public static int SaveData( CommandType storedProcedure, string v, SqlParameter[] parm)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-K3H36MO;Initial Catalog=db_auction;Integrated Security=True "))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = storedProcedure;
                cmd.CommandText = v;


                try
                {

                    for (int i = 0; i < parm.Length; i++)
                {
                        if (parm[i] != null)
                        {


                            cmd.Parameters.Add(parm[i]);
                        }
                        else
                        {

                        }
                    }

    }

    catch (Exception ex)
                {

                    throw ex;
                }
                cmd.Connection = con;
                return cmd.ExecuteNonQuery();
            }
            }
    }

    
}