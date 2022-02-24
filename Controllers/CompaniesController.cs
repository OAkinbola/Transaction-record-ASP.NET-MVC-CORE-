using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionsRecordFile.Models;

namespace TransactionsRecordFile.Controllers
{
    public class CompaniesController : Controller
    {
        public CompaniesController(TransactionRecord company)
        {
            _company = company;
        }
        public IActionResult Index()
        {
            //Getting all the Companies from the Db  
            var companies = _company.Companies.OrderBy(c => c.CompanyName).ToList();

            //then pass the list object to the view
            return View(companies);
        }

        private TransactionRecord _company;
    }
}
