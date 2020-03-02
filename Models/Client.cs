using System;

namespace GymAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Subscription Subscription { get; set; }
        public int CurrentSessionsCount { get; set; }
    }
}