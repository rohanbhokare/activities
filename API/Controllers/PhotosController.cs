using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Photos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class PhotosController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Meadiator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Meadiator.Send(new Delete.Command { Id = id}));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> SetMain(string id)
        {
            return HandleResult(await Meadiator.Send(new SetMain.Command {Id = id}));
        }
    }
}