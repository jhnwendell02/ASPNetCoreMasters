using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class ItemDBContext : IdentityDbContext
    {
        public ItemDBContext(DbContextOptions options) : base(options)
        {

        }
       public  DbSet<Item> Item { get; set; }
    }
}
