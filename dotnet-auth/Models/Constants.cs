using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_auth.Models
{
    public class Constants
    {
        public static List<User> users = new List<User>()
        {
            new User
            {
                Id=1,
                Username="Waleed",
                Password="Salad",
                Email="mw@gmail.com",
                Role="CEO"
            },
             new User
            {
                Id=2,
                Username="Bajwa",
                Password="Salad",
                Email="mw@gmail.com",
                Role="Project Manager"
            },
              new User
            {
                Id=3,
                Username="Farhan",
                Password="Salad",
                Email="farhan@gmail.com",
                Role="Business Analyst"
            }
        };

    }
}
