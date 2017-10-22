using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackOHIO2017.Models
{
    [Table("InvestorCategories")]
    public class InvestorCategory
    {
        public Guid InvestorId{get;set;}
        public virtual Investor Investor { get; set; }

        public Guid CategoryId{get;set;}

        public  virtual Category Category { get; set; }
    }
}