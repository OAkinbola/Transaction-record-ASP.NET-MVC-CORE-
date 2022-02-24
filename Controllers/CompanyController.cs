using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionsRecordFile.Models;

namespace TransactionsRecordFile.Controllers
{
    public class CompanyController : Controller
    {
       
        public CompanyController(TransactionRecord company)
        {
            _companyRecord = company;
        }

        // GET & POST action methods  for the "Add" request resource
        [HttpGet()]
        public IActionResult Add()
        {
            // First set the action to be "Add"
            ViewBag.Action = "Add";

            return View("Edit", new Company());
        }


        [HttpPost()]
        public IActionResult Add(Company newCompany)
        {
            //checking if the moved data is valid 
            if (ModelState.IsValid)
            {
                //if valid add to the Database 
                _companyRecord.Companies.Add(newCompany);
                _companyRecord.SaveChanges();

                TempData["companyMessage"] = $"Save Successful";
                TempData["message"] = $"Company '{newCompany.CompanyName}' Has been added";

                //redirect back to the all companies pages
                return RedirectToAction("Index", "Companies");
            }
            else
            {
                //if invalid send the company back with validation warnings 
                ViewBag.Action = "Add";
                return View("Edit", newCompany);
            }
        }


        // GET & POST action methods for the "Edit" request resource
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            // First set the action to be "Edit"
            ViewBag.Action = "Edit";

            //lookup the company by Id
            var company = _companyRecord.Companies.Find(id);

            //then pass the transaction to the view 
            return View(company);
        }

        [HttpPost()]
        public IActionResult Edit(Company newCompany)
        {
            //checking to see if the move data sent is valid 
            if (ModelState.IsValid)
            {
                //if valid add update to the DB
                _companyRecord.Companies.Update(newCompany);
                _companyRecord.SaveChanges();

                TempData["companyMessage"] = TempData["message"] = $"Save Successful";
                TempData["message"] = $"Company '{newCompany.CompanyName}' Has been edited"; ;

                //redirect back to the all Transaction page
                return RedirectToAction("Index", "Companies");
            }
            else
            {
                ViewBag.Action = "Edit";
                //if invalid send company back with validation warnings 
                return View("Edit", newCompany);
            }
        }



        // GET action methods for the "Details" request resource
        [HttpGet()]
        public IActionResult Detail(int id)
        {
            // looking for the Company by id
            var company = _companyRecord.Companies.Find(id);

            //redirect back to the all Company page
            return View(company);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var company = _companyRecord.Companies.Find(id);
            return View(company);
        }
        [HttpPost]
        public IActionResult Delete(Company company)
        {
            //if valid remove the data from DB
            _companyRecord.Companies.Remove(company);
            _companyRecord.SaveChanges();

            TempData["companyMessage"] = $"A company has been delete";
            TempData["message"] = $"Save Successful";

            //redirect back to the all Transaction page
            return RedirectToAction("Index", "Companies");
        }

        private TransactionRecord _companyRecord;
    }
}
