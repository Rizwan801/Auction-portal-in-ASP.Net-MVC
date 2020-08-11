using auction_portal.DAL;
using auction_portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auction_portal.BLL
{
    public class bllclass
    {
        public int bllgetdata(List<auctionMdl> li)
        {
            dalclass obj = new dalclass();
            obj.Dllsavedata(li);
            return 0;
        }
    }
}