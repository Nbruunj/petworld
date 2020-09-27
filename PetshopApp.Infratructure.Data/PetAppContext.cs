using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;

namespace PetshopApp.Infratructure.Data
{
    public class PetAppContext: DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
