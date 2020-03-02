using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;
using GymAPI.Utils;

namespace GymAPI.Services
{
    public class SubscriptionService
    {
        private readonly List<Subscription> _subscription;
        DataUtils dataUtils = new DataUtils();

        public SubscriptionService(){
            _subscription = dataUtils.ReadSubscriptionJson();
        }

        public IEnumerable<Subscription> GetAll(){
            return _subscription;
        }

        public Subscription GetSubscription(int id){
            return _subscription.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Subscription> CreateSubscription(Subscription subscription){
            _subscription.Add(subscription);
            dataUtils.WriteSubscriptionJson(_subscription);
            return _subscription;
        }

        public IEnumerable<Subscription> UpdateSubscription(int id, Subscription subscription){
            _subscription.Remove(_subscription.Where(x=> x.Id == id).FirstOrDefault());
            subscription.Id = id;
            _subscription.Add(subscription);
            _subscription.OrderBy(x=>x.Id);
            dataUtils.WriteSubscriptionJson(_subscription);
            return _subscription;
        }

        public IEnumerable<Subscription> DeleteSubscription(int id){
            _subscription.Remove(_subscription.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteSubscriptionJson(_subscription);
            return _subscription;
        }
    }

}