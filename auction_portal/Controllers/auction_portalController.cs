using auction_portal.BLL;
using auction_portal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace auction_portal.Controllers
{
    public class auction_portalController : Controller
    {
        // GET: auction_portal

        public ActionResult Loginone()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loginone(tb_login objUser)
        {


       

         
            if (ModelState.IsValid)
            {
                using (db_auctionEntities db1 = new db_auctionEntities())
                {
                    var obj = db1.tb_logins.Where(a => a.Email.Equals(objUser.Email) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {

                        Session["Email"] = obj.Email.ToString();
                        return RedirectToAction("Account_selecter", "auction_portal");

                    }
                    //else
                    //{
                    //    ViewBag.message("email or password is incorrect");
                    //}

                }
            }
            return View(objUser);
        }

           

        public ActionResult Index()
        {
            
            return View();
        }
       
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public int AddSignupdata(List<auctionMdl> li)
        {

            bllclass obj = new bllclass();
            obj.bllgetdata(li);



            return 0;
        }

        //for BLOG page
        [HttpGet]
         public ActionResult Viewuser()
        {
            return View();
        }
        //list record

        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<tb_user> GetAllEmployee()
        {
            using (db_auctionEntities db = new db_auctionEntities())
            {
                return db.Employees.ToList<tb_user>();

            }
        }

            //insert and update

            [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            

            tb_user emp = new tb_user();
            if(Session["Email"] != null)
            {
                if (id != 0)
                {
                    using (db_auctionEntities db = new db_auctionEntities())
                    {

                        emp = db.Employees.Where(x => x.ID == id).FirstOrDefault<tb_user>();
                        //return RedirectToAction("Viewuser", this);
                    }

                   
                }

            }
            else
            {
                //return RedirectToAction("Loginone");
            }

            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(tb_user emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (db_auctionEntities db = new db_auctionEntities())
                {
                    if (emp.ID == 0)
                    {
                        db.Employees.Add(emp);
                        db.SaveChanges();
                       
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                       

                    }
                     return View(emp);
                }
                 
                
               // return Json(new { success =true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (db_auctionEntities db = new db_auctionEntities())
                {
                    tb_user emp = db.Employees.Where(x => x.ID == id).FirstOrDefault<tb_user>();
                    db.Employees.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Account_selecter()
        {
            return View();
        }

        public ActionResult Bidder()
        {
            
            return View(GetAllEmployee());
        }



        public ActionResult Logout()

        {

            FormsAuthentication.SignOut();


            Session.Abandon();
            return RedirectToAction("Account_selecter", "auction_portal");


        }

    }
}