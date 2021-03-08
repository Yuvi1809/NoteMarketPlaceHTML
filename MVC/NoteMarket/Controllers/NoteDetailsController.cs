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

                projectEntities1 db = new projectEntities1();
            NoteDetail notes = new NoteDetail();
                     
                ViewData["Category"] = db.Categories.ToList<Category>();
                ViewData["Type"] = db.Types.ToList();
                ViewData["Country"] = db.Countries.ToList();
            notes.Category = notesModel.category;
            notes.Type = notesModel.type;
            notes.Country = notesModel.country;
            notes.OwnerId = 11;
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
            notes.Status = "Published";
            string fileName = Path.GetFileName(dp.FileName);
          
            notesModel.dppath = "~/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"),fileName);
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

        public ActionResult SearchNotes() 
        {
            projectEntities1 db = new projectEntities1();
            ViewData["Category"] = db.Categories.ToList<Category>();
            ViewData["Type"] = db.Types.ToList();
            ViewData["Country"] = db.Countries.ToList();
            ViewData["Rate"] = db.Ratings.ToList();
            ViewData["Course"] = db.NoteDetails.ToList();
            ViewData["University"] = db.NoteDetails.ToList();
            ViewData["Note"] = db.NoteDetails.ToList();
           
            return View();
        }
        [HttpPost]
        public ActionResult SearchNotes(SearchNotes searchNotes)
        {
            NoteDetail nm = new NoteDetail();
            SearchNotes sn = new SearchNotes();
            projectEntities1 db = new projectEntities1();
            ViewData["Category"] = db.Categories.ToList<Category>();
            ViewData["Type"] = db.Types.ToList();
            ViewData["Country"] = db.Countries.ToList();
            ViewData["Rate"] = db.Ratings.ToList();
            ViewData["Course"] = db.NoteDetails.ToList();
            ViewData["University"] = db.NoteDetails.ToList();
            ViewData["Note"] = db.NoteDetails.ToList();
           
     
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult BuyReq()
        {
            return View();
        }
    }
    }