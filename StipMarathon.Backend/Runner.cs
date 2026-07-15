using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StipMarathon.Backend.Enums;

namespace StipMarathon.Backend
{
    public class Runner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Category Category { get; set; }

        public Runner (int Id, string FirstName,string LastName,string Email,int Age, Category Category)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Age = Age;
            this.Category = Category;

        }
    }
}
