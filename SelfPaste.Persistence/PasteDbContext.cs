using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SelfPaste.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfPaste.Persistence
{
    public class PasteDbContext : DbContext
    {
        public DbSet<Paste> Pastes { get; private set; }

        public PasteDbContext(DbContextOptions<PasteDbContext> options)
            : base(options)
        {
            Pastes = Set<Paste>();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paste>().HasKey(p => new { p.Id, p.FriendlyId });
            modelBuilder.Entity<Paste>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
