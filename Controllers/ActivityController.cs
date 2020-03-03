using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GymAPI.Models;
using GymAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly ActivityService _activityService;

        public ActivityController(ILogger<ActivityController> logger, ActivityService activityService)
        {
            _logger = logger;
            _activityService = activityService;
        }
        [HttpGet]
        public IEnumerable<Activity> Get() =>
            _activityService.GetAll();

        [HttpGet("{Id}")]
        public Activity GetActivity(int id) => 
            _activityService.GetActivity(id);

        [HttpPost]
        public Activity CreateActivity(Activity activity){
            var tmpId = _activityService.GetAll().Last().Id;
            activity.Id = tmpId+1;
            return _activityService.CreateActivity(activity);
        }

        [HttpPut("{Id}")]
        public Activity UpdateActivity(int id, Activity activity) =>
            _activityService.UpdateActivity(id, activity);

        [HttpDelete("{Id}")]
        public bool DeleteActivity(int id) =>
            _activityService.DeleteActivity(id);
    }
}