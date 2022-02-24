using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TransactionsRecordFile.Models;

namespace TransactionsRecordFile.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController(TransactionRecord transactionRecord)
        {
            _transactionRecord = transactionRecord;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private TransactionRecord _transactionRecord;
    }
}
