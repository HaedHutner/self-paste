using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfPaste.Data.Dtos;
using SelfPaste.Data.Entities;
using SelfPaste.Service;

namespace SelfPaste.Controllers
{
    [Route("api/pastes")]
    [ApiController]
    public class PastesController : ControllerBase
    {

        private readonly PasteService pasteService;
        private readonly IMapper mapper;

        public PastesController(PasteService pasteService, IMapper mapper)
        {
            this.pasteService = pasteService;
            this.mapper = mapper;
        }

        // GET api/pastes/5
        [HttpGet("{friendlyId}")]
        public async Task<IActionResult> GetAsync(string friendlyId)
        {
            Paste paste = await pasteService.GetPasteFromIdAsync(friendlyId);

            return await Task.Run<IActionResult>(() => Ok(mapper.Map<PasteDto>(paste)));
        }

        // POST api/pastes
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreatePasteDto value)
        {
            var paste = await pasteService.CreatePasteAsync(value.Content);

            return await Task.Run<IActionResult>(() => CreatedAtAction(
                actionName:  "GetAsync", 
                routeValues: new { friendlyId = paste.FriendlyId },
                value:       mapper.Map<PasteDto>(paste))
            );
        }

    }
}
