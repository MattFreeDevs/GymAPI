using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;
using GymAPI.Utils;

namespace GymAPI.Services
{
    public class SessionService
    {
        private readonly List<Session> _sessions;
        DataUtils dataUtils = new DataUtils();

        public SessionService(){
            _sessions = dataUtils.ReadSessionJson();
        }

        public IEnumerable<Session> GetAll(){
            return _sessions;
        }

        public Session GetSession(int id){
            return _sessions.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Session> CreateSession(Session session){
            _sessions.Add(session);
            dataUtils.WriteSessionJson(_sessions);
            return _sessions;
        }

        public IEnumerable<Session> UpdateSession(int id, Session session){
            _sessions.Remove(_sessions.Where(x=> x.Id == id).FirstOrDefault());
            session.Id = id;
            _sessions.Add(session);
            _sessions.OrderBy(x=>x.Id);
            dataUtils.WriteSessionJson(_sessions);
            return _sessions;
        }

        public IEnumerable<Session> DeleteSession(int id){
            _sessions.Remove(_sessions.Where(x=> x.Id == id).FirstOrDefault());
            dataUtils.WriteSessionJson(_sessions);
            return _sessions;
        }
    }

}