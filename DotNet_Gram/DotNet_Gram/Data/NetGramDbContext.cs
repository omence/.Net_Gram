using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Gram.Models;

namespace DotNet_Gram.Data
{
    public class NetGramDbContext : DbContext
    {
        public NetGramDbContext(DbContextOptions<NetGramDbContext> options) : base(options)
        {

        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NetGram>().HasData(
                new NetGram
                {
                    ID = 1,
                    NamePoster = "Jason",
                    Caption = "pic",
                    ImageURL = "url"
                },

                new NetGram
                {
                    ID = 2,
                    NamePoster = "Jennifer",
                    Caption = "pic",
                    ImageURL = "URL"
                }
                );
        }

        public DbSet<NetGram> NetGrams { get; set; }
    }

   
}
