using Microsoft.EntityFrameworkCore;
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
    }
}
