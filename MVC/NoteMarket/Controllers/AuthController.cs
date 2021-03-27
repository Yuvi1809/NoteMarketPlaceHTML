using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteMarket.Models;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace NoteMarket.Controllers
{
    public class AuthController : Controller
    {

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        //Home
        public ActionResult HOME()
        {

            return View();
        }
        //Login
        [HttpGet]
        public ActionResult Login()
        {
            
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
                    Session["Id"] = usr.Id;
                    TempData["Success"] = "Loggin Successfully!";
                    return RedirectToAction("SearchNotes", "NoteDetails");
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
                var verifyUrl = "/Auth/ConfirmEmail?Email=" + md.EmailId;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

                var fromemail = new MailAddress("noteamarketplace@gmail.com");
                var toemail = new MailAddress(md.EmailId);
                MailMessage mm = new MailMessage("noteamarketplace@gmail.com", md.EmailId);
                mm.Subject = "  Note Marketplace - Email Verification ";
                mm.IsBodyHtml = true;
                mm.Body = "<a'"+link+"'>"+link+"</a>";


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromemail.Address, "Note@tatva");

                smtp.Send(mm);
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
        public ActionResult ConfirmEmail(string Email)
        {
            using (projectEntities1 db = new projectEntities1())
            {

                MembersData usr = db.MembersDatas.Where(u => u.EmailId == Email).FirstOrDefault();
                usr.IsEmailVerified = true;
                usr.CPassword = "123";
                db.SaveChanges();
                return View(usr);
            }
        }
       
        //ForgotPassword
        [HttpGet]
        public ActionResult ChangePass()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(ChangePassModel cpm)
        {
            if (Session["Id"] != null)
            {
                int id = Convert.ToInt32(Session["Id"].ToString());
                using (projectEntities1 db = new projectEntities1())
                {
                    MembersData usr = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
                    {
                        if (cpm.OldPassword == usr.Password)
                        {
                            usr.CPassword = cpm.CPassword;
                            usr.Password = cpm.CPassword;
                            db.SaveChanges();
                            TempData["Success"] = "Password  Successfully Changed!";
                            return RedirectToAction("Login", "Auth");
                        }
                        else
                        {
                            TempData["Success"] = "OldPassword miss match";
                            return RedirectToAction("Registration", "Auth");
                        }

                    }
                }
             }
            else
            {
                return RedirectToAction("Forgot", "Auth");
            }
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

        //ContactUs
        public ActionResult UserProfile(UserProfileModal userProfile)
        {
            int id = Convert.ToInt32(Session["Id"].ToString());
            using (projectEntities1 db = new projectEntities1())
            {
                MembersData usr = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
                {
                    userProfile.FirstName = usr.FirstName;
                    userProfile.LastName = usr.LastName;
                    userProfile.EmailId = usr.EmailId;

                    return View(userProfile);
                }
            }
        }
        [HttpPost]
        public ActionResult UserProfile(UserProfileModal userProfile, HttpPostedFileBase dp)
        {
         if(Session["Id"] != null)
            {
                int id = Convert.ToInt32(Session["Id"].ToString());
                using (projectEntities1 db = new projectEntities1())
                {
                    MembersData usr = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
                    {
                        string fileName = Path.GetFileName(dp.FileName);
                        userProfile.uploaddp= "~/images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                        dp.SaveAs(fileName);
                        
                        usr.AddLine1 = userProfile.add1;
                        usr.Addline2 = userProfile.add2;
                        usr.City = userProfile.city;
                        usr.Collage = userProfile.collage;
                        usr.Country = userProfile.country;
                        usr.State = userProfile.state;
                        usr.University = userProfile.university;
                        usr.ZipCode = userProfile.zipcode;
                        usr.DOB = userProfile.bdate;
                        usr.PhoneNo = userProfile.phone;
                        usr.IsDetailsSubmitted = true;
                        usr.CPassword = "123";
                        
                        usr.Gender = "Male";
                        
                        usr.ProfilePicture = userProfile.uploaddp;
                        db.SaveChanges();
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }
    }

}