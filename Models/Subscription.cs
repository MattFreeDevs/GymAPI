using System;
using System.Collections.Generic;

namespace GymAPI.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public List<Activity> ListActivities { get; set; }
        public string Gender { get; set; }
        public int Days { get; set; }
        public double Price { get; set; }
    }
}