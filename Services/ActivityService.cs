using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;

namespace GymAPI.Services
{
    public class ActivityService
    {
        private readonly List<Activity> _activities;

        public ActivityService(){
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/jsonData.json");
            _activities = JsonSerializer.Deserialize<List<Activity>>(jsonString);
        }

        public IEnumerable<Activity> GetAll(){
            return _activities;
        }

        public Activity GetActivity(int id){
            return _activities.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Activity> CreateActivity(Activity activity){
            _activities.Add(activity);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_activities,options);
            System.IO.File.WriteAllText("../GymAPI/Data/jsonData.json",jsonString);
            return _activities;
        }

        public IEnumerable<Activity> UpdateActivity(int id, Activity activity){
            _activities.Remove(_activities.Where(x=> x.Id == id).FirstOrDefault());
            _activities.Add(activity);
            _activities.OrderBy(x=>x.Id);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_activities,options);
            System.IO.File.WriteAllText("../GymAPI/Data/jsonData.json",jsonString);

            return _activities;
        }

        public IEnumerable<Activity> DeleteActivity(int id){
            _activities.Remove(_activities.Where(x=> x.Id == id).FirstOrDefault());
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_activities,options);
            System.IO.File.WriteAllText("../GymAPI/Data/jsonData.json",jsonString);

            return _activities;
        }
    }

}