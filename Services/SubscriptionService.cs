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
            return _subscription.OrderBy(x=>x.Id);
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
            List<Subscription> orderedList = new List<Subscription>(_subscription.OrderBy(x=>x.Id));
            dataUtils.WriteSubscriptionJson(orderedList);
            return _subscription;
        }

        public IEnumerable<Subscription> DeleteSubscription(int id){
            _subscription.Remove(_subscription.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteSubscriptionJson(_subscription);
            return _subscription;
        }
    }

}