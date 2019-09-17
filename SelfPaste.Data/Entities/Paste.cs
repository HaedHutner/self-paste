using System;
using System.Collections.Generic;
using System.Text;

namespace SelfPaste.Data.Entities
{
    public class Paste
    {
        public long Id { get; set; }

        public string FriendlyId { get; set; }

        public string Content { get; set; }
    }
}
