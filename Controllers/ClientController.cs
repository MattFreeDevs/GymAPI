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
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientService _clientService;

        public ClientController(ILogger<ClientController> logger, ClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }
        [HttpGet]
        public IEnumerable<Client> Get() =>
            _clientService.GetAll();

        [HttpGet("{Id}")]
        public Client GetClient(int id) => 
            _clientService.GetClient(id);

        [HttpPost]
        public IEnumerable<Client> CreateClient(Client client){
            var tmpId = _clientService.GetAll().Last().Id;
            client.Id = tmpId+1;
            return _clientService.CreateClient(client);
        }

        [HttpPut("{Id}")]
        public IEnumerable<Client> UpdateClient(int id, Client client) =>
            _clientService.UpdateClient(id, client);

        [HttpDelete("{Id}")]
        public IEnumerable<Client> DeleteClient(int id) =>
            _clientService.DeleteClient(id);
    }
}