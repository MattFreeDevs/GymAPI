using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;

namespace GymAPI.Utils
{
    public class DataUtils
    {
        // Writters
        public void WriteActivityJson(List<Activity> data){
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(data,options);
            System.IO.File.WriteAllText("../GymAPI/Data/activityData.json",jsonString);
        }
        public void WriteClientJson(List<Client> data){
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(data,options);
            System.IO.File.WriteAllText("../GymAPI/Data/clientData.json",jsonString);
        }
        public void WriteSessionJson(List<Session> data){
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(data,options);
            System.IO.File.WriteAllText("../GymAPI/Data/sessionData.json",jsonString);
        }
        public void WriteStaffJson(List<Staff> data){
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(data,options);
            System.IO.File.WriteAllText("../GymAPI/Data/staffData.json",jsonString);
        }
        public void WriteSubscriptionJson(List<Subscription> data){
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(data,options);
            System.IO.File.WriteAllText("../GymAPI/Data/subscriptionData.json",jsonString);
        }

        //Readers
        public List<Activity> ReadActivityJson(){
            List<Activity> tmpList = new List<Activity>();
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/activityData.json");
            return JsonSerializer.Deserialize<List<Activity>>(jsonString);
        }
        public List<Client> ReadClientJson(){
            List<Client> tmpList = new List<Client>();
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/clientData.json");
            return JsonSerializer.Deserialize<List<Client>>(jsonString);
        }
        public List<Session> ReadSessionJson(){
            List<Session> tmpList = new List<Session>();
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/sessionData.json");
            return JsonSerializer.Deserialize<List<Session>>(jsonString);
        }
        public List<Staff> ReadStaffJson(){
            List<Staff> tmpList = new List<Staff>();
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/staffData.json");
            return JsonSerializer.Deserialize<List<Staff>>(jsonString);
        }
        public List<Subscription> ReadSubscriptionJson(){
            List<Subscription> tmpList = new List<Subscription>();
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/subscriptionData.json");
            return JsonSerializer.Deserialize<List<Subscription>>(jsonString);
        }
    }
}