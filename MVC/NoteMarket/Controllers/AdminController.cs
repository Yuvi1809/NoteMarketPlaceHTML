using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteMarket.Models;

namespace NoteMarket.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Addcountry() { return View(); }
        [HttpPost]
        public ActionResult Addcountry(AddCountrymodel add)
        {
            using (projectEntities1 db = new projectEntities1())
            {
                if (Session["Id"] != null)
                {
                    int id = Convert.ToInt32(Session["Id"].ToString());
                    MembersData usr = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
                    {
                        admin a = db.admins.Where(u => u.CreatedBy == id).FirstOrDefault();
                        {
                            Country c = new Country();
                            c.Country1 = add.country;
                            c.Description = add.dis;
                            c.Date = DateTime.Now;
                            c.AdminId =a.Id ;
                            c.IsActive = true;
                            db.Countries.Add(c);
                            db.SaveChanges(); }
                     
                    }
                    return View();
                }
            }
            return View();
        }
        public ActionResult DashBoard()
        {
            projectEntities1 db = new projectEntities1();
            List<NoteDetail> notes = db.NoteDetails.ToList();

            return View(notes);
        }
        public ActionResult PublishNote(string seller)
        {
            projectEntities1 db = new projectEntities1();
            List<NoteDetail> notes = db.NoteDetails.ToList();
            ViewData["Notedetail"] = db.NoteDetails.ToList();
            //if (seller != "Seller Name" && !string.IsNullOrEmpty(seller))
            //{
            //    notes = notes.Where(e => e.OwnerId!=0 && e.Contains(seller)).ToList();

            //}

            return View(notes);
        }
        public ActionResult Members() 
        {
            projectEntities1 db = new projectEntities1();
            List<MembersData> members = db.MembersDatas.ToList();
            return View(members);

        }
        public ActionResult UnderReview()
        {
            projectEntities1 db = new projectEntities1();
            List<NoteDetail> notes = db.NoteDetails.ToList();

            return View(notes);
        }
        public ActionResult Approve(int id)
        {
            projectEntities1 db = new projectEntities1();
            NoteDetail data = db.NoteDetails.Where(u => u.Id == id).FirstOrDefault();
            {
                data.Status = "Published";
                db.SaveChanges();
                return View();
            }
        }
        public ActionResult Reject(int id) 
        {
            projectEntities1 db = new projectEntities1();
            NoteDetail data = db.NoteDetails.Where(u => u.Id == id).FirstOrDefault();
            {
                data.Status = "Rejected";
                db.SaveChanges();
                return View();
            }
        }
        public ActionResult Rejected()
        {
            projectEntities1 db = new projectEntities1();
            List<NoteDetail> notes = db.NoteDetails.ToList();

            return View(notes);

        }
        public ActionResult DownloadNotes()
        {
            using (projectEntities1 db = new projectEntities1())
            {
                AddownloadView adddownloads = new AddownloadView
                {

                    Adddownload = (from buyer in db.Buyers

                                 join member in db.MembersDatas on buyer.MemberId equals member.Id
                                 join seller in db.Sellers on buyer.MemberId equals seller.ModifiedBy
                                 join note in db.NoteDetails on buyer.BookId equals note.Id
                                   where note.OwnerId==seller.MemberId
                                 select new Addownload
                                 {                                 

                                     category = note.Category,
                                     title = note.NoteTitle,
                                     buyer=buyer.MembersData.FirstName,
                                     seller=seller.MembersData.FirstName,
                                     selltype=note.SellFor,
                                     sellprice=note.SellPrice,
                                     downloadate=seller.ApprovedDate
                                 }
                                 ).ToList()
                };
                ViewData["Notedetail"] = db.NoteDetails.ToList();
                ViewData["Buyer"] = db.Buyers.ToList();
                ViewData["Seller"] = db.Sellers.ToList();

                //List<Buyer> user = db.Buyers.Where(u => u.MemberId == id1).ToList();

                return View(adddownloads);
            }
        }
        public ActionResult MembersDetails(int id,MemberDetailfull md)
        {
            projectEntities1 db = new projectEntities1();
            MembersData mb = db.MembersDatas.Where(u => u.Id == id).FirstOrDefault();
            {

                ViewData["Notedetail"] = db.NoteDetails.ToList();
                    md.id = id;
                    md.ad1 = mb.AddLine1;
                    md.ad2 = mb.Addline2;
                    md.bd = mb.DOB.ToString();
                    md.city = mb.City;
                    md.country = mb.Country;
                    md.emailid = mb.EmailId;
                    md.fn = mb.FirstName;
                    md.ln = mb.LastName;
                    md.phone = mb.PhoneNo;
                    md.state = mb.State;
                    md.uni = mb.University;
                    md.zip = mb.ZipCode;
                    md.img = mb.ProfilePicture;
                return View(md);            
                
               
            }
        }
    }
}