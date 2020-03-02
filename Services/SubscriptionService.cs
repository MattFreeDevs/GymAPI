using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;

namespace GymAPI.Services
{
    public class SubscriptionService
    {
        private readonly List<Subscription> _subscription;

        public SubscriptionService(){
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/subscriptionData.json");
            _subscription = JsonSerializer.Deserialize<List<Subscription>>(jsonString);
        }

        public IEnumerable<Subscription> GetAll(){
            return _subscription;
        }

        public Subscription GetSubscription(int id){
            return _subscription.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Subscription> CreateSubscription(Subscription subscription){
            _subscription.Add(subscription);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_subscription,options);
            System.IO.File.WriteAllText("../GymAPI/Data/subscriptionData.json",jsonString);
            return _subscription;
        }

        public IEnumerable<Subscription> UpdateSubscription(int id, Subscription subscription){
            _subscription.Remove(_subscription.Where(x=> x.Id == id).FirstOrDefault());
            _subscription.Add(subscription);
            _subscription.OrderBy(x=>x.Id);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_subscription,options);
            System.IO.File.WriteAllText("../GymAPI/Data/subscriptionData.json",jsonString);

            return _subscription;
        }

        public IEnumerable<Subscription> DeleteSubscription(int id){
            _subscription.Remove(_subscription.Where(x=> x.Id == id).FirstOrDefault());
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_subscription,options);
            System.IO.File.WriteAllText("../GymAPI/Data/subscriptionData.json",jsonString);

            return _subscription;
        }
    }

}