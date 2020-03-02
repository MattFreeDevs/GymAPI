using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;
using GymAPI.Utils;

namespace GymAPI.Services
{
    public class ActivityService
    {
        private readonly List<Activity> _activities;
        DataUtils dataUtils = new DataUtils(); 

        public ActivityService(){
            _activities = dataUtils.ReadActivityJson();
        }

        public IEnumerable<Activity> GetAll(){
            return _activities;
        }

        public Activity GetActivity(int id){
            return _activities.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Activity> CreateActivity(Activity activity){
            _activities.Add(activity);
            dataUtils.WriteActivityJson(_activities);
            return _activities;
        }

        public IEnumerable<Activity> UpdateActivity(int id, Activity activity){
            _activities.Remove(_activities.Where(x=> x.Id == id).FirstOrDefault());
            activity.Id= id;
            _activities.Add(activity);
            _activities.OrderBy(x=>x.Id);
            dataUtils.WriteActivityJson(_activities);
            return _activities;
        }

        public IEnumerable<Activity> DeleteActivity(int id){
            _activities.Remove(_activities.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteActivityJson(_activities);
            return _activities;
        }
    }

}