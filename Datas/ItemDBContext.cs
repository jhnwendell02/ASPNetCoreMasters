using Datas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Datas
{
    public class ItemDBContext : IdentityDbContext
    {
        public ItemDBContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Item> Item { get; set; }
    }
}
