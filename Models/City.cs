using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace HackOHIO2017.Models
{
    [Table("Cities")]
    public class City
    {

     
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public virtual string PrettyName => String.Format("{0}, {1}", Name, State);

        public virtual IEnumerable<Investor> Investors {get;set;}

        public virtual IEnumerable<Business> Businesses { get; set; }




    }
}