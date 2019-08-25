using System;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Driver;

namespace TableauxApi.Models
{
    public class ApplicationUser : MongoIdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        

    }
}