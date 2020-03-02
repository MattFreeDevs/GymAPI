using System;

namespace GymAPI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Activity Activity { get; set; }
        public DateTime Datetime { get; set; }
        public Staff Trainer { get; set; }
        public int CurrentUsers { get; set; }
        public bool Status { get; set; } // true: Open, false: Closed
    }
}