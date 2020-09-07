using System;
using System.Collections.Generic;
using System.Text;

namespace PetworldApp.Core.Entity
{
    public class Pet
    {

        public int Id { get; set; }

        public String Name { get; set; }
        public String Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public String Color { get; set; }
        public String PreviousOwner { get; set; }
        public double Price { get; set; }



    }
}
