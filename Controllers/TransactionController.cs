using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionsRecordFile.Models;

namespace TransactionsRecordFile.Controllers
{
    public class TransactionController : Controller
    {
         /*
          * Name: Olayimika Akinbola 
          * student Number: 8714906
          * purpose of the Assignment:To build a basic database-driven ASP.NET Core MVC web app as a way of getting an overview of ASP.NET 
          * Submission Date: 15th october 2021.
          */


        public TransactionController(TransactionRecord transactionRecord)
        {
            _transactionRecord = transactionRecord;
        }


        // GET & POST action methods  for the "Add" request resource
        [HttpGet()]
        public IActionResult Add()
        {
            // First set the action to be "Add"
            ViewBag.Action = "Add";

            // Add the TransactionTypes to the viewbag:
            ViewBag.TransactionTypes = _transactionRecord.TransactionTypes.OrderBy(t => t.Name).ToList();

            // Add the Companies to the viewbag:
            ViewBag.Companies = _transactionRecord.Companies.OrderBy(t => t.CompanyName).ToList();

            return View("Edit", new Transaction());
        }



        // ASP.NET Core MVC serializes the incoming form data in the
        // POST request into a Transaction object
        [HttpPost()]
        public IActionResult Add(Transaction newTransaction)
        {
            //checking if the moved data is valid 
            if (ModelState.IsValid)
            {
                //if valid add to the Database 
                _transactionRecord.Transactions.Add(newTransaction);
                _transactionRecord.SaveChanges();

                TempData["transactionMessage"] = $"The transaction was added successfully";
                TempData["message"] = "Save Successful";

                //redirect back to the all transaction pages
                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                ViewBag.Action = "Add";

                //if invalid send the transaction back with validation warnings               
                ViewBag.TransactionTypes = _transactionRecord.TransactionTypes.OrderBy(t => t.Name).ToList();
                ViewBag.Companies = _transactionRecord.Companies.OrderBy(c => c.CompanyName).ToList();

                return View("Edit", newTransaction);
            }
        }

        // GET & POST action methods for the "Edit" request resource
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            // First set the action to be "Edit"
            ViewBag.Action = "Edit";

            //add the transactionTypes to the viewbag
            ViewBag.TransactionTypes = _transactionRecord.TransactionTypes.OrderBy(t => t.Name).ToList();

            //add the transactionTypes to the viewbag
            ViewBag.Companies = _transactionRecord.Companies.OrderBy(c => c.CompanyName).ToList();

            //first lookup the transaction by Id
            var transaction = _transactionRecord.Transactions.Find(id);

            //then pass the transaction to the view 
            return View(transaction);
        }


        // ASP.NET Core MVC serializes the incoming form data in the
        // POST request into a Transaction object for us
        [HttpPost()]
        public IActionResult Edit(Transaction transaction)
        {
            //checking to see if the move data sent is valid 
            if (ModelState.IsValid)
            {
                //if valid add update to the DB
                _transactionRecord.Transactions.Update(transaction);
                _transactionRecord.SaveChanges();

                //Message 
                TempData["transactionMessage"] = $"The transaction was succesfully Updated";
                TempData["message"] = "Save Successful";

                //redirect back to the all Transaction page
                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                ViewBag.Action = "Edit";

                //if invalid send Transaction back with validation warnings                
                ViewBag.TransactionTypes = _transactionRecord.TransactionTypes.OrderBy(g => g.Name).ToList();
                ViewBag.Companies = _transactionRecord.Companies.OrderBy(g => g.CompanyName).ToList();

                return View("Edit", transaction);
            }
        }


        // GET  action methodsfor the "Details" request resource
        [HttpGet()]
        public IActionResult Details(int id)
        {
            // First set the action to be "Details"
            ViewBag.Action = "Details";

            //first lookup the transaction by Id
            var transaction = _transactionRecord.Transactions.Find(id);

            ViewBag.TransactionTypes = _transactionRecord.TransactionTypes.OrderBy(g => g.Name).ToList();
            ViewBag.Companies = _transactionRecord.Companies.OrderBy(g => g.CompanyName).ToList();

            //then pass the transaction to the view 
            return View(transaction);
        }


        // GET & POST action methods for the "Delete" request resource
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // looking for the transaction by id
            var transaction = _transactionRecord.Transactions.Find(id);

            ViewBag.TransactionTypes = _transactionRecord.TransactionTypes.OrderBy(g => g.Name).ToList();
            ViewBag.Companies = _transactionRecord.Companies.OrderBy(g => g.CompanyName).ToList();

            //passing the transaction to the view 
            return View(transaction);
        }
        [HttpPost]
        public IActionResult Delete(Transaction transaction)
        {
            //if valid remove the data from DB
            _transactionRecord.Transactions.Remove(transaction);
            _transactionRecord.SaveChanges();

            //Message
            TempData["transactionMessage"] = $"The transaction was successfully deleted";
            TempData["message"] = "Save successful";

            //redirect back to the all Transaction page
            return RedirectToAction("Index", "Transactions");
        }

        private TransactionRecord _transactionRecord;
    }
}
