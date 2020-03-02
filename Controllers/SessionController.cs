using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GymAPI.Models;
using GymAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly SessionService _sessionService;

        public SessionController(ILogger<SessionController> logger, SessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }
        [HttpGet]
        public IEnumerable<Session> Get() =>
            _sessionService.GetAll();

        [HttpGet("{Id}")]
        public Session GetSession(int id) => 
            _sessionService.GetSession(id);

        [HttpPost]
        public IEnumerable<Session> CreateSession(Session session){
            var tmpId = _sessionService.GetAll().Last().Id;
            session.Id = tmpId+1;
            return _sessionService.CreateSession(session);
        }

        [HttpPut("{Id}")]
        public IEnumerable<Session> UpdateSession(int id, Session session) =>
            _sessionService.UpdateSession(id, session);

        [HttpDelete("{Id}")]
        public IEnumerable<Session> DeleteSession(int id) =>
            _sessionService.DeleteSession(id);
    }
}