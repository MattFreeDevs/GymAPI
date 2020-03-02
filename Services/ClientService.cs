using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using GymAPI.Models;

namespace GymAPI.Services
{
    public class ClientService
    {
        private readonly List<Client> _clients;

        public ClientService(){
            var jsonString = System.IO.File.ReadAllText("../GymAPI/Data/clientData.json");
            _clients = JsonSerializer.Deserialize<List<Client>>(jsonString);
        }

        public IEnumerable<Client> GetAll(){
            return _clients;
        }

        public Client GetClient(int id){
            return _clients.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Client> CreateClient(Client client){
            _clients.Add(client);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_clients,options);
            System.IO.File.WriteAllText("../GymAPI/Data/clientData.json",jsonString);
            return _clients;
        }

        public IEnumerable<Client> UpdateClient(int id, Client client){
            _clients.Remove(_clients.Where(x=> x.Id == id).FirstOrDefault());
            _clients.Add(client);
            _clients.OrderBy(x=>x.Id);
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_clients,options);
            System.IO.File.WriteAllText("../GymAPI/Data/clientData.json",jsonString);

            return _clients;
        }

        public IEnumerable<Client> DeleteClient(int id){
            _clients.Remove(_clients.Where(x=> x.Id == id).FirstOrDefault());
            var options = new JsonSerializerOptions{
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_clients,options);
            System.IO.File.WriteAllText("../GymAPI/Data/clientData.json",jsonString);

            return _clients;
        }
    }

}