using SelfPaste.Data.Entities;
using SelfPaste.Persistence;
using System;
using System.Threading.Tasks;

namespace SelfPaste.Service
{
    public class PasteService
    {
        private readonly UniqueIdService uniqueIdService;
        private readonly PasteRepository pasteRepository;

        public PasteService(UniqueIdService uniqueIdService, PasteRepository pasteRepository)
        {
            this.uniqueIdService = uniqueIdService;
            this.pasteRepository = pasteRepository;
        }

        public async Task<Paste> CreatePasteAsync(string content)
        {
            return await pasteRepository.SavePasteAsync(new Paste {
                FriendlyId = uniqueIdService.GenerateUniqueId(),
                Content = content
            });
        }

        public async Task<Paste> GetPasteFromIdAsync(string friendlyId)
        {
            return await pasteRepository.FindPasteByFriendlyIdAsync(friendlyId);
        }
    }
}
