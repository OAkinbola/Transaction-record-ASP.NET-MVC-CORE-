using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionsRecordFile.Models;
using Microsoft.EntityFrameworkCore;

namespace TransactionsRecordFile.Controllers
{
    public class TransactionsController : Controller
    {
        public TransactionsController(TransactionRecord transactionRecord)
        {
            _transactionRecord = transactionRecord;
        }
        public IActionResult Index(string sortOrder )
        {
            //   var transaction = _transactionRecord.Transactions.Include(t => t.TransactionType).Include(t => t.Company) .OrderBy(t => t.Company.CompanyName).ToList();
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name" : "";

            var transaction = from t in _transactionRecord.Transactions.Include(t => t.TransactionType).Include(t => t.Company) select t;

            switch (sortOrder)
            {
                case "name":
                    transaction = transaction.OrderByDescending(t => t.Company.CompanyName);
                    break;
                default:
                    transaction = transaction.OrderBy(t => t.Company.CompanyName);
                    break;
            }

            return View(transaction.ToList());
        }

        public IActionResult Record(int id)
        {
            var transaction = _transactionRecord.Transactions.Where( t=> t.CompanyId == id).Include(t => t.TransactionType).Include(c => c.Company).OrderBy(c => c.Company.CompanyName).ToList();
            var company = _transactionRecord.Companies.Find(id);

            ViewBag.Name = company.CompanyName;
            ViewBag.Ticker = company.Ticker;
            return View(transaction);
        }

        private TransactionRecord _transactionRecord;
    }
}
