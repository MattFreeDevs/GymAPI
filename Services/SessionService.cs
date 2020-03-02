using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;

namespace GymAPI.Services
{
    public class SessionService
    {
        private readonly List<Session> _sessions;

        public SessionService(){
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/sessionData.json");
            _sessions = JsonSerializer.Deserialize<List<Session>>(jsonString);
        }

        public IEnumerable<Session> GetAll(){
            return _sessions;
        }

        public Session GetSession(int id){
            return _sessions.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Session> CreateSession(Session session){
            _sessions.Add(session);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_sessions,options);
            System.IO.File.WriteAllText("../GymAPI/Data/sessionData.json",jsonString);
            return _sessions;
        }

        public IEnumerable<Session> UpdateSession(int id, Session session){
            _sessions.Remove(_sessions.Where(x=> x.Id == id).FirstOrDefault());
            _sessions.Add(session);
            _sessions.OrderBy(x=>x.Id);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_sessions,options);
            System.IO.File.WriteAllText("../GymAPI/Data/sessionData.json",jsonString);

            return _sessions;
        }

        public IEnumerable<Session> DeleteSession(int id){
            _sessions.Remove(_sessions.Where(x=> x.Id == id).FirstOrDefault());
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_sessions,options);
            System.IO.File.WriteAllText("../GymAPI/Data/sessionData.json",jsonString);

            return _sessions;
        }
    }

}