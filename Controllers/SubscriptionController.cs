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
    public class SubscriptionController : ControllerBase
    {
        private readonly ILogger<SubscriptionController> _logger;
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(ILogger<SubscriptionController> logger, SubscriptionService subscriptionService)
        {
            _logger = logger;
            _subscriptionService = subscriptionService;
        }
        [HttpGet]
        public IEnumerable<Subscription> Get() =>
            _subscriptionService.GetAll();

        [HttpGet("{Id}")]
        public Subscription GetSubscription(int id) => 
            _subscriptionService.GetSubscription(id);

        [HttpPost]
        public IEnumerable<Subscription> CreateSubscription(Subscription subscription){
            var tmpId = _subscriptionService.GetAll().Last().Id;
            subscription.Id = tmpId+1;
            return _subscriptionService.CreateSubscription(subscription);
        }

        [HttpPut("{Id}")]
        public IEnumerable<Subscription> UpdateSubscription(int id, Subscription subscription) =>
            _subscriptionService.UpdateSubscription(id, subscription);

        [HttpDelete("{Id}")]
        public IEnumerable<Subscription> DeleteSubscription(int id) =>
            _subscriptionService.DeleteSubscription(id);
    }
}