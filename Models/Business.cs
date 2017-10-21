using System;
using System.ComponentModel.DataAnnotations;

namespace HackOHIO2017.Models
{         
    public class Business
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State{get;set;}

        public int Zip {get;set;}

    }
}