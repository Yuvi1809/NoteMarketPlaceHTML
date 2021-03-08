using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteMarket.Models;
using System.Net;
using System.Net.Mail;


namespace NoteMarket.Controllers
{
    public class AuthController : Controller
    {

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }


        //Login
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Id"] != null)
            {
                return RedirectToAction("Login", "Auth", new { Id = Session["Id"].ToString() });
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(MembersData ml)
        {
            using (projectEntities1 db = new projectEntities1())
            {

                MembersData usr = db.MembersDatas.Where(u => u.EmailId == ml.EmailId && u.Password == ml.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    TempData["Success"] = "Loggin Successfully!";
                    return RedirectToAction("Registration", "Auth");
                }
                else
                {
                    TempData["Success"] = "EmailId or Password is wrong";
                    ModelState.AddModelError("", "EmailId or Password is wrong");
                    return RedirectToAction("Login", "Auth");
                }

            }
        }

        //Registration
        [HttpGet]
        public ActionResult Registration()
        {
            MembersData md = new MembersData();
            return View(md);
        }

        [HttpPost]
        public ActionResult Registration(MembersData md)
        {

            projectEntities1 db = new projectEntities1();
            db.MembersDatas.Add(md);
            if (md.Password == md.CPassword)
            {

                db.SaveChanges();
      
                TempData["Success"] = "Registration Successfully Done!";
               return RedirectToAction("Login", "Auth");
            }
            else
            {
                TempData["Success"] = "Password and Confirm password miss match";
                return RedirectToAction("Registration", "Auth");
            }

        }


        //ForgotPassword
        [HttpGet]
        public ActionResult Forgot()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Forgot(MembersData ml)
        {
            using (projectEntities1 db = new projectEntities1())
            {
                MembersData usr = db.MembersDatas.Where(u => u.EmailId == ml.EmailId).FirstOrDefault();
                if (usr != null)
                {
                    usr.CPassword = "Note@123";
                    usr.Password= "Note@123";

                    var fromemail = new MailAddress("noteamarketplace@gmail.com");
                    var toemail = new MailAddress(ml.EmailId);
                    MailMessage mm = new MailMessage("noteamarketplace@gmail.com", ml.EmailId);
                    mm.Subject = "New temporory password has been genrated for you";
                    mm.IsBodyHtml = true;
                    mm.Body = "<div>Hello,</div> <div>We have genrated a new password for you .</div> <div>Password : notemarketplace@123<div>------</div><div> Regards,<div> NoteMarketplace</div>";


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromemail.Address, "Note@tatva");
                   
                    smtp.Send(mm);
                    db.SaveChanges();
                    TempData["Success"] = "Email sent Successfully Done!";


                    
                    return RedirectToAction("ChangePass", "Auth");
                }
                else
                {
                    TempData["Success"] = "EmailId is wrong";
                    ModelState.AddModelError("", "EmailId is wrong");
                    return RedirectToAction("Forgot", "Auth");
                }

            }
        }

        //ConfirmEmailid
        [HttpGet]
        public ActionResult ConfirmEmail()
        {
            return View();
        }
       
        //ForgotPassword
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();
        }
        
        //FAQ
        [HttpGet]
        public ActionResult FAQ()
        {
            return View();
        }

        //ContactUs
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(ContactUsModel model)
        {

            MailMessage mm = new MailMessage("noteamarketplace@gmail.com",model.EmaiId)
            {

                Subject = model.FirstName,
                Body = "Hello,"+"<div>-----"+"<div>Subject:  "+model.Subject+"<div>Cmment/Questions:  " + model.comment+ "<div><div>-----<div>Regards,"+"<div>"+model.FirstName,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("noteamarketplace@gmail.com", "Note@tatva"); 
            smtp.Send(mm);

            projectEntities1 db = new projectEntities1();
            comment c = new comment();
            c.FullName = model.FirstName;
            c.EmailId = model.EmaiId;
            c.Comment1 = model.comment;
            c.Subject = model.Subject;
            db.comments.Add(c);
            db.SaveChanges();

            TempData["Success"] = "Email sent Successfully Done!";
            return RedirectToAction("ContactUs", "Auth");
        }
    }
    
}