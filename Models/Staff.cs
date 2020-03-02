using System;
using System.Collections.Generic;


namespace GymAPI.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Salary { get; set; }
        public List<string> Activities { get; set; }
    }
}