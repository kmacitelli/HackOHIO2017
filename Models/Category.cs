using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackOHIO2017.Models
{
    [Table("Categories")]
    public class Category
    {
        public Guid Id { get; set; }

        public string Name {get;set;}


        public virtual IEnumerable<InvestorCategory> InvestorCategories {get;set;}
    

        public virtual IEnumerable<Business> Businesses {get;set;}
        
    }
}