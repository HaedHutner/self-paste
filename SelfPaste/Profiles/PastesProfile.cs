using AutoMapper;
using SelfPaste.Data.Dtos;
using SelfPaste.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfPaste.Profiles
{
    public class PastesProfile : Profile
    {
        public PastesProfile()
        {
            CreateMap<Paste, PasteDto>();
        }
    }
}
