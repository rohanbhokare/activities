using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet] //api/activities
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Meadiator.Send(new List.Query()));
        }

        [HttpGet("{id}")] // api/activities/idddd
        public async Task<IActionResult> GetActivity(Guid id)
        {
            return HandleResult(await Meadiator.Send(new Details.Query { Id= id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActicity(Activity activity)
        {
            return HandleResult(await Meadiator.Send(new Create.Command {Activity = activity}));
        }

        [Authorize("IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity([FromRoute]Guid id, [FromBody]Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Meadiator.Send(new Edit.Command{Activity = activity}));
        }

        [Authorize("IsActivityHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute]Guid id)
        {
            return HandleResult(await Meadiator.Send(new Delete.Command{Id = id}));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            
            return HandleResult(await Meadiator.Send(new UpdateAttendance.Command{Id = id}));
        }
    }
}