using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransactionsRecordFile.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required (ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Company Address is Required")]
        public string CompanyAddress { get; set; }


        [Required(ErrorMessage = "Ticker symbol is Required")]
        public string Ticker { get; set; }
    }
}
