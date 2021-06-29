using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc1.Models;
using System.Data;
namespace mvc1.Controllers
{
    public class studentController : Controller
    {
        studentVos stdvos = new studentVos();
        studentBll stdbll = new studentBll();
        // GET: student
        public ActionResult Index()
        {
            List<studentVos> stdlist = stdbll.gettotalstudents();
            return View(stdlist);

        }

        // GET: student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: student/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: student/Create
        [HttpPost]
        public ActionResult Create(studentVos stdvos)
        {
            try
            {
                string result = stdbll.InsertUserDtls(stdvos);
                if (result.Contains("Saved"))
                {
                    // ViewBag.result = "Saved Successfully .. Name: " + stdvos.STUDENT_FNAME + " " + stdvos.STUDENT_LNAME;
                    ViewBag.result = result;
                }
                else
                {
                    ViewBag.result = "Not Saved Successfully ..";
                }
                return View();
                // TODO: Add insert logic here
                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Edit/5
        public ActionResult Edit(int id)
        {
            studentVos objstd = stdbll.gettotalstudentsbySlno(id);
            return View(objstd);
        }

        // POST: student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, studentVos collection)
        {
            try
            {
                string result = stdbll.updstdDetailsbyslno(id, collection);
                if(result == "Y")
                {
                    ViewBag.result = "Updated Successfully";
                }
                return View();
                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
