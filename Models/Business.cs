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


        public string State{get;set;}

        public int Zip {get;set;}


        public string Description {get;set;}

        public string Site {get;set;}

        public string Phone{get;set;}

        public string Email {get;set;}



        public Guid CityId { get; set; }

        public virtual City City{ get; set; }

        public Guid CategoryId{get;set;}

        public virtual Category Category{get;set;}

    }
}