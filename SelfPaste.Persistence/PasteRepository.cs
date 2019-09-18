using SelfPaste.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SelfPaste.Persistence
{
    public class PasteRepository
    {
        private readonly PasteDbContext context;

        public PasteRepository(PasteDbContext context)
        {
            this.context = context;
        }

        public async Task<Paste> SavePasteAsync(Paste paste)
        {
            paste = context.Paste.Add(paste).Entity;
            context.SaveChanges();

            return paste;
        }

        public async Task<Paste> FindPasteByFriendlyIdAsync(string friendlyId)
        {
            return context.Paste.Where(paste => paste.FriendlyId.Equals(friendlyId)).SingleOrDefault();
        }
    }
}
