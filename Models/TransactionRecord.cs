using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TransactionsRecordFile.Models
{
    /// <summary>
    /// This class defines the way we interact with the DB by inheriting
    /// from EF's DbContext class
    /// </summary>
    public class TransactionRecord:DbContext
    {

        /// <summary>
        /// Here we define the constructor that passes the required options 
        /// param up to the base class constructor.
        /// </summary>
        public TransactionRecord(DbContextOptions options)
            : base (options)
        {
        }

        /// <summary>
        /// This property is how we access all the transactions in the Transaction
        /// table in the DB from the code
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// A way of accessing the TransactionTypes table in the DB
        /// </summary>
        public DbSet<TransactionType>TransactionTypes { get; set; }

        /// <summary>
        /// A way of accessing the Companies table in the Db
        /// </summary>
        public DbSet<Company> Companies { get; set; }


        /// <summary>
        /// This is where we can do some DB initialization
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add new company
            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    CompanyId = 1,
                    CompanyName = "Google",
                    CompanyAddress = " 123 Google Way",
                    Ticker = "GOOG"
                },

                 new Company()
                 {
                     CompanyId = 2,
                     CompanyName = "Microsoft",
                     CompanyAddress = "423 Bill Gate Drive",
                     Ticker = "MSFT"
                 }
                );



            //Add Transaction Types
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType() { TransactionTypeId = "S", Name ="Sell", Fee=5.99},
                new TransactionType() { TransactionTypeId = "B", Name = "Buy", Fee = 5.40 }
                );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction() 
                { 
                   
                    TransactionId =1,
                    Quantity =100,
                    SharePrice =2701.76,
                    CompanyId = 1,
                    TransactionTypeId ="B"

                },

                 new Transaction()
                 {
                     TransactionId =2, 
                     Quantity = 100,
                     SharePrice = 123.45,
                     CompanyId = 2,
                     TransactionTypeId = "S"
                 }

                );
        }
    }
}
