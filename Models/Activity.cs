using System;

namespace GymAPI.Models{
    public class Activity{
        public int Id {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
    }
}