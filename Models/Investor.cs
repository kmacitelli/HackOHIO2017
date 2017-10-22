using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackOHIO2017.Models
{
[Table("Investors")]    
    public class Investor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email {get;set;}
    

        public string Phone{get; set;}

        public string Description {get;set;}

        public string Address {get;set;}

        public int Zip {get;set;}

        public virtual City City {get;set;}

        public Guid CityId { get; set; }


        public string Site { get; set; }

        public virtual IEnumerable<InvestorCategory> InvestorCategories{get;set;}


        
    }
}