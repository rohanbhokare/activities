using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Followers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FollowController: BaseApiController
    {
        [HttpPost("{username}")]
        public async Task<IActionResult> Follow(String username)
        {
            return HandleResult(await Meadiator.Send(new FollowToggle.Command{TargetUsername = username}));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetFollowing(String username, string predicate)
        {
            return HandleResult(await Meadiator.Send(new List.Query{Username = username, Predicate = predicate}));
        }

    }
}