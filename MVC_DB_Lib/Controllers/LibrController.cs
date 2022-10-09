using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using BL;
using MVC_DB_Lib.Models;

namespace MVC_DB_Lib.Controllers
{
    public class LibrController : Controller
    {
        // GET: Libr
       

        BookOperation h = null;
        public LibrController()
        {
            h = new BookOperation();

        }
        List<Book> modelsList = new List<Book>();
        public ActionResult Index()
        {
            var emplist = h.GetAllBooks();
            List<Book> modelsList = new List<Book>();
            foreach (var item in emplist)
            {
                modelsList.Add(new Book { Bookid=item.Bookid,BookName=item.BookName,cost=item.cost,Author=item.Author,memberid=item.memberid });
            }

            return View(modelsList);

        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: NW_Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                BLClass1 bal = new BLClass1();
                bal.Bookid = Convert.ToInt32(Request["EmployeeID"]);
                bal.BookName = Request["Bookname"].ToString();
                bal.Author = Request["Author"].ToString();
              //  bal.Category = Request["Category"].ToString();
                bal.cost = Convert.ToInt32(Request["cost"]);
                 bal.memberid= Convert.ToInt32(Request["member_id"]);
                
                h.InsertBook(bal);
                /* if (ans)
                 {
                     return RedirectToAction("Index");
                 }
                 else
                 {
                     return View();
                 }*/
                Console.WriteLine("Record Inserted successfully...");
                Console.WriteLine("---------------");
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.exMsg = ex.Message;
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            //var emp = helper.SearchEmployee(id);
            
            Book model = new Book();
            BLClass1 b = new BLClass1();
            model.Bookid = id;
            model.BookName =b.BookName ;

            model.cost = b.cost;

            //only date
            //model.memberid = emp.BirthDate;


            model.memberid = b.memberid;

            

            return View(model);
        }

        // POST: NW_Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                // var emp = h.UpdateBook(id);


                BLClass1 bal = new BLClass1();
                bal.Bookid = Convert.ToInt32(Request["EmployeeID"]);
                bal.BookName = Request["Bookname"].ToString();
                bal.Author = Request["Author"].ToString();
                //  bal.Category = Request["Category"].ToString();
                bal.cost = Convert.ToInt32(Request["cost"]);
                bal.memberid = Convert.ToInt32(Request["member_id"]);

                h.UpdateBook(bal);

               
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Book foundData = modelsList.Find(customer => customer.Bookid == id);
            return View(foundData);
        }

        [HttpPost]
        public ActionResult Delete(int id, Book cust)
        {
           Book foundData = modelsList.Find(customer => customer.Bookid == id);
            modelsList.Remove(foundData);
            //return View(foundData);
            return RedirectToAction("Index");
        }

    }
}