using auction_portal.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace auction_portal.DAL
{
    public class dalclass
    {
        private string _ConnString;
      //  private string conn;
        public dalclass()
        {
             _ConnString = ConfigurationManager.AppSettings["EProdbConnection"];
            
             //conn = new SqlConnection("Data Source=DESKTOP-K3H36MO;Initial Catalog=auction_portal;Integrated Security=True");
        }

     

        public void Dllsavedata(List<auctionMdl> li)
        {
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@Fname", SqlDbType.VarChar);
            parm[0].Value = li[0].Fname;

            parm[1] = new SqlParameter("@Lname", SqlDbType.VarChar);
            parm[1].Value = li[0].Lname;

            parm[2] = new SqlParameter("@Email", SqlDbType.VarChar);
            parm[2].Value = li[0].Email;

            parm[3] = new SqlParameter("@password", SqlDbType.VarChar);
            parm[3].Value = li[0].password;

            parm[4] = new SqlParameter("@phone", SqlDbType.VarChar);
            parm[4].Value = li[0].phone;

            parm[5] = new SqlParameter("@city", SqlDbType.VarChar);
            parm[5].Value = li[0].city;


            SqlHelper.SaveData(  CommandType.StoredProcedure, "Insert", parm);




        }

    }
}