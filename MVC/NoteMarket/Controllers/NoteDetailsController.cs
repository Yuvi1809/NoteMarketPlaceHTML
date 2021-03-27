using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteMarket.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace NoteMarket.Controllers
{
    public class NoteDetailsController : Controller
    {
        // GET: NoteDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNotes()
        {
            projectEntities1 db = new projectEntities1();
            ViewData["Category"] = db.Categories.ToList<Category>();
            ViewData["Type"] = db.Types.ToList();
            ViewData["Country"] = db.Countries.ToList();
            return View();
        }
        // GET: AddNotes
        [HttpPost]
        public ActionResult AddNotes(AddNotesModel notesModel, HttpPostedFileBase dp, HttpPostedFileBase uploadnote, HttpPostedFileBase notepreview)
        {
            if (Session["Id"] != null)
            {
                int id = Convert.ToInt32(Session["Id"].ToString());
                using (projectEntities1 db = new projectEntities1())
                {
                    MembersData usr = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
                    {

                        //projectEntities1 db = new projectEntities1();
                        NoteDetail notes = new NoteDetail();

                        ViewData["Category"] = db.Categories.ToList<Category>();
                        ViewData["Type"] = db.Types.ToList();
                        ViewData["Country"] = db.Countries.ToList();
                        notes.Category = notesModel.category;
                        notes.Type = notesModel.type;
                        notes.Country = notesModel.country;
                        notes.OwnerId = id;
                        notes.SellFor = false;
                        notes.ReqDate = DateTime.Now;
                        notes.ApprovedDate = DateTime.Now;
                        notes.IsActive = true;
                        notes.NoteTitle = notesModel.Title;
                        notes.NoOfPages = notesModel.Noofpage;
                        notes.Description = notesModel.Disc;
                        notes.University = notesModel.instituename;
                        notes.Course = notesModel.coursename;
                        notes.CourseCode = notesModel.coursecode;
                        notes.Professor = notesModel.professor;
                        notes.SellPrice = notesModel.price;
                        notes.Status = "Drafted";

                        string fileName = Path.GetFileName(dp.FileName);

                        notesModel.dppath = "~/images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                        dp.SaveAs(fileName);

                        db.NoteDetails.Add(notes);


                        string fileName1 = Path.GetFileName(uploadnote.FileName);


                        notesModel.uploadpath = "~/images/" + fileName1;
                        fileName = Path.Combine(Server.MapPath("~/images/"), fileName1);
                        uploadnote.SaveAs(fileName);

                        db.NoteDetails.Add(notes);

                        string fileName2 = Path.GetFileName(notepreview.FileName);

                        notesModel.notepath = "~/images/" + fileName2;
                        fileName = Path.Combine(Server.MapPath("~/images/"), fileName2);
                        notepreview.SaveAs(fileName);

                        db.NoteDetails.Add(notes);

                        notes.DisplayPic = notesModel.dppath;
                        notes.Preview = notesModel.notepath;
                        notes.note = notesModel.uploadpath;
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
        public ActionResult EditNotes(int noteid,AddNotesModel notesModel, HttpPostedFileBase dp, HttpPostedFileBase uploadnote, HttpPostedFileBase notepreview)
        {
            if (Session["Id"] != null)
            {
                int id = Convert.ToInt32(Session["Id"].ToString());
                using (projectEntities1 db = new projectEntities1())
                {

                    MembersData usr = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
                    {
                        NoteDetail nd = db.NoteDetails.Where(u => u.Id == noteid).FirstOrDefault();
                        {
                            //ViewData["Category"] = db.Categories.ToList<Category>();
                            //ViewData["Type"] = db.Types.ToList();
                            //ViewData["Country"] = db.Countries.ToList();

                            //notesModel.category = nd.Category;
                            //notesModel.country = nd.Country;
                            notesModel.coursecode = nd.CourseCode;
                            notesModel.coursename = nd.Course;
                            notesModel.Disc = nd.Description;
                            
                            notesModel.instituename = nd.University;
                            notesModel.Noofpage = nd.NoOfPages;
                           
                            notesModel.price = nd.SellPrice;
                            //notesModel.professor = nd.Professor;
                            notesModel.Title = nd.NoteTitle;
                            notesModel.type = nd.Type;
                            string fileName = Path.GetFileName(dp.FileName);

                            notesModel.dppath = "~/images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                            dp.SaveAs(fileName);

                            db.NoteDetails.Add(nd);


                            string fileName1 = Path.GetFileName(uploadnote.FileName);


                            notesModel.uploadpath = "~/images/" + fileName1;
                            fileName = Path.Combine(Server.MapPath("~/images/"), fileName1);
                            uploadnote.SaveAs(fileName);

                            

                            string fileName2 = Path.GetFileName(notepreview.FileName);

                            notesModel.notepath = "~/images/" + fileName2;
                            fileName = Path.Combine(Server.MapPath("~/images/"), fileName2);
                            notepreview.SaveAs(fileName);

                            db.NoteDetails.Add(nd);

                            nd.DisplayPic = notesModel.dppath;
                            nd.Preview = notesModel.notepath;
                            nd.note = notesModel.uploadpath;
                            db.SaveChanges();

                            return View(notesModel);
                        }
                    }
                }
            }
            else
            {
                return View(); 
            }
        
          }
       

        public ActionResult SearchNotes(string searchn, string country, string type, string category, string university, string course)
        {
            NoteDetail nm = new NoteDetail();
            Notedetailmodal sn = new Notedetailmodal();
            projectEntities1 db = new projectEntities1();
            ViewData["Category"] = db.Categories.ToList<Category>();
            ViewData["Type"] = db.Types.ToList();
            ViewData["Country"] = db.Countries.ToList();
            ViewData["Rate"] = db.Ratings.ToList();
            ViewData["Course"] = db.NoteDetails.ToList();
            ViewData["University"] = db.NoteDetails.ToList();
            
                List<NoteDetail> notes = db.NoteDetails.ToList();
                if (!string.IsNullOrEmpty(searchn))
                {
                    notes = notes.Where(e => e.NoteTitle.ToLower().Contains(searchn.ToLower())).ToList();

                }
                if (country != "Select country" && !string.IsNullOrEmpty(country))
                {
                    notes = notes.Where(e => e.Country != null && e.Country.ToLower().Contains(country.ToLower())).ToList();

                }
                if (type != "Select Type" && !string.IsNullOrEmpty(type))
                {
                    notes = notes.Where(e => e.Type != null && e.Type.ToLower().Contains(type.ToLower())).ToList();

                }

                if (category != "Select category" && !string.IsNullOrEmpty(category))
                {
                    notes = notes.Where(e => e.Category != null && e.Category.ToLower().Contains(category.ToLower())).ToList();

                }

                if (university != "Select University" && !string.IsNullOrEmpty(university))
                {
                    notes = notes.Where(e => e.University != null && e.University.ToLower().Contains(university.ToLower())).ToList();

                }

                if (course != "Select Course" && !string.IsNullOrEmpty(course))
                {
                    notes = notes.Where(e => e.Course != null && e.Course.ToLower().Contains(course.ToLower())).ToList();

                }



                return View(notes);
            
           
        }
        public ActionResult DashBoard(string searchn)
        {
            projectEntities1 db = new projectEntities1();
            List<NoteDetail> notes = db.NoteDetails.ToList();
            if (!string.IsNullOrEmpty(searchn))
            {
                notes = notes.Where(e => e.NoteTitle.ToLower().Contains(searchn.ToLower())).ToList();

            }

            return View(notes);
        }
        public ActionResult BuyReq()
        {
            if (Session["Id"] != null)
            {

                int id1 = Convert.ToInt32(Session["Id"].ToString());
                using (projectEntities1 db = new projectEntities1())
                {
                    Seller usr = db.Sellers.Where(u => u.Id == id1).FirstOrDefault();

                    return View(usr);
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult NoteDetail(int id, Notedetailmodal notedetailmodal)
        {

            projectEntities1 db = new projectEntities1();
            NoteDetail data = db.NoteDetails.Where(u => u.Id == id).FirstOrDefault();
            {
                
                return View(data);

            }
        }
        
        public ActionResult DownloadNotes(int noteid)
        {
                if (Session["Id"] != null)
                {
                    
                    int id1 = Convert.ToInt32(Session["Id"].ToString());
                    using (projectEntities1 db = new projectEntities1())
                    {
                       MembersData usr = db.MembersDatas.Where(u => u.Id == id1).FirstOrDefault();
                        {
                        NoteDetail nm = db.NoteDetails.Where(u => u.Id == noteid).FirstOrDefault();

                            if (nm.SellFor == true)
                            {
                            Seller sl = new Seller();
                            sl.MemberId = nm.OwnerId;
                            Buyer by = new Buyer();
                            by.MemberId = id1;
                            
                            var fromemail = new MailAddress("noteamarketplace@gmail.com");
                            var toemail = new MailAddress(usr.EmailId);
                            MailMessage mm = new MailMessage("noteamarketplace@gmail.com", usr.EmailId);
                            mm.Subject ="Check"+ usr.FirstName+" wants to purchase your notes  ";
                            mm.IsBodyHtml = true;
                            mm.Body = "Hello" + usr.LastName + "," + "<div>We would like to inform you that" + usr.FirstName+ " wants to purchase your notes. Please see Buyer Requests tab and allow download access to Buyer if you have received the payment from him."+ "<div>Regards,<div>Notes Marketplace ";


                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential(fromemail.Address, "Note@tatva");

                            smtp.Send(mm);

                            by.BookId = noteid;
                            by.ApprovedDate = DateTime.Now;
                            by.ReqDate = DateTime.Now;
                            by.IsActive = true;
                            db.Buyers.Add(by);
                            sl.BookId = noteid;
                            sl.IsActive = true;
                            sl.MemberId = nm.OwnerId;
                            sl.ModifiedBy = id1;
                            sl.ReqDate = DateTime.Now;
                            sl.ApprovedDate = DateTime.Now;
                            db.Sellers.Add(sl);
                            db.SaveChanges();

                            return RedirectToAction("SearchNotes", "NoteDetails");

                            }

                            else
                            {
                                Seller sl = new Seller();
                                Buyer by = new Buyer();
                                by.MemberId = id1;
                                by.BookId = noteid;
                                by.ApprovedDate = DateTime.Now;
                                by.ReqDate = DateTime.Now;
                                by.IsActive = true;
                                db.Buyers.Add(by);
                                sl.BookId = noteid;
                                sl.IsActive = true;
                                sl.MemberId = nm.OwnerId;
                                sl.ModifiedBy = id1;
                                sl.ReqDate = DateTime.Now;
                                sl.ApprovedDate = DateTime.Now;
                                db.Sellers.Add(sl);
                                db.SaveChanges();
                                TempData["Success"] = "Download sucsessfully";
                                return RedirectToAction("SearchNotes", "NoteDetails");
                        }

                        }
                    
                    }
                    
                }
                else
                {
                    TempData["Success"] = "Please sign in/register to download this note.";
                    return RedirectToAction("Registration", "Auth");
                }
        }

        public  ActionResult MyDownload()
        {
            if (Session["Id"] != null)
            {

                int id1 = Convert.ToInt32(Session["Id"].ToString());
                using(projectEntities1 db = new projectEntities1())
                {

                    List<Buyer> user = db.Buyers.Where(u => u.MemberId == id1).ToList();
                    return View(user.ToList());
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult MySold()
        {
            if (Session["Id"] != null)
            {

                int id1 = Convert.ToInt32(Session["Id"].ToString());
                using (projectEntities1 db = new projectEntities1())
                {
                    List<Seller> user = db.Sellers.Where(u => u.MemberId == id1).ToList();

                    return View(user.ToList());
                }
            }
            else
            {
                return View();
            }
        }
    }
}